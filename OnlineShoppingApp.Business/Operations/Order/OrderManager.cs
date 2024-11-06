using Microsoft.EntityFrameworkCore;
using OnlineShoppingApp.Business.Operations.Order.Dtos;
using OnlineShoppingApp.Business.Types;
using OnlineShoppingApp.Data.Entities;
using OnlineShoppingApp.Data.Repositories;
using OnlineShoppingApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Order
{
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<OrderEntity> _orderRepository;
        private readonly IRepository<OrderProductEntity> _orderProductRepository;

        private readonly IRepository<UserEntity> _userRepository;

        public OrderManager(IUnitOfWork unitOfWork, IRepository<OrderEntity> orderRepository, IRepository<OrderProductEntity> orderProductRepository, IRepository<UserEntity> userRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _orderProductRepository = orderProductRepository;
            _userRepository = userRepository; //silinecek
        }

        // AddOrder and Transation progress
        public async Task<ServiceMessage> AddOrder(AddOrderDto order)
        {

            await _unitOfWork.BeginTransaction();
            var orderEntity = new OrderEntity
            {
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                
                UserId = order.UserId,
            };

            _orderRepository.Add(orderEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Order kaydi sirasinda bir sorunla karsilasildi.");

            }

            foreach (var productId in order.ProductIds)
            {
                var orderProduct = new OrderProductEntity
                {
                    OrderId = orderEntity.Id,
                    ProductId = productId,
                };

                _orderProductRepository.Add(orderProduct);
            }

            try
            {
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransaction();
                throw new Exception("Order Product eklenirken bir hatayla karsilasildi. Surec basa sardi.");
            }

            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        //AddOrderTotalAmounts 

        public async Task<ServiceMessage> AddOrderTotalAmounts(int id, decimal changeAmount)
        {
            var order = _orderRepository.GetById(id);

            if (order is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu Id ile eslesen Order bulunamadi."

                };
            }

            order.TotalAmount = changeAmount;

            _orderRepository.Update(order);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("TotalAmount miktari degistirilirken bir hata olustu.");
            }

            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        // DeleteOrder and catch exception
        public async Task<ServiceMessage> DeleteOrder(int id)
        {
            var order = _orderRepository.GetById(id);

            if (order is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Silinmek istenen Order bulunamadi."
                };
            }

            _orderRepository.Delete(order);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Silme islemi sirasinda bir hata olustu.");
            }

            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        // I got id the orders
        public async Task<OrderDto> GetOrder(int id)
        {
            var order = await _orderRepository.GetAll(x => x.Id == id)
                .Select(x => new OrderDto
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate,
                    TotalAmount = x.TotalAmount,
                    Products = x.OrderProducts.Select(f => new OrderProductDto
                    {
                        Id = f.Id,
                        ProductName = f.Product.ProductName
                    }).ToList()
                }).FirstOrDefaultAsync();

            return order;
        }

        // I got all the orders
        public async Task<List<OrderDto>> GetOrders()
        {
            var orders = await _orderRepository.GetAll()
                .Select(x => new OrderDto
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate,
                    TotalAmount = x.TotalAmount,
                    Products = x.OrderProducts.Select(f => new OrderProductDto
                    {
                        Id = f.Id,
                        ProductName = f.Product.ProductName
                    }).ToList()
                }).ToListAsync();

            return orders;
        }


        // UpdateOrder and use Transaction
        public async Task<ServiceMessage> UpdateOrder(UpdateOrderDto order)
        {
            var orderEntity = _orderRepository.GetById(order.Id);

            if ( orderEntity is null )
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Order bulunamadi."
                };
            }

            await _unitOfWork.BeginTransaction();

            orderEntity.OrderDate = order.OrderDate;
            orderEntity.TotalAmount = order.TotalAmount;
            orderEntity.UserId= order.UserId;

            _orderRepository.Update(orderEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransaction();
                throw new Exception("Order bilgileri guncellenirken bir hata ile karsilasildi.");
            }

            var orderProducts = _orderProductRepository.GetAll(x => x.OrderId == x.OrderId).ToList();
            foreach (var orderProduct in orderProducts)
            {
                _orderProductRepository.Delete(orderProduct,false);
            }

            foreach(var productId in order.ProductIds)
            {
                var orderProduct = new OrderProductEntity
                {
                    OrderId = orderEntity.Id,
                    ProductId = productId,
                };

                _orderProductRepository.Add(orderProduct);
            }

            try
            {
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransaction();
                throw new Exception("Order bilgileri guncellenirken bir hata olustu. Islemler geriye aliniyor.");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
            };
        }
    }
}
