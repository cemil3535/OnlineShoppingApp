using OnlineShoppingApp.Business.Operations.Product.Dtos;
using OnlineShoppingApp.Business.Types;
using OnlineShoppingApp.Data.Entities;
using OnlineShoppingApp.Data.Repositories;
using OnlineShoppingApp.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Product
{
    // product add
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProductEntity> _repository;

        public ProductManager(IUnitOfWork unitOfWork, IRepository<ProductEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<ServiceMessage> AddProduct(AddProductDto product)
        {
            var hasProduct = _repository.GetAll(x => x.ProductName.ToLower() == product.ProductName.ToLower()).Any();

            if (hasProduct)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Urun zaten bulunuyor."
                };
            }

            var productEntity = new ProductEntity
            {
                ProductName = product.ProductName,
                Price = product.Price,
                StockQantity = product.StockQantity,
            };

            _repository.Add(productEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Urun kaydi sirasinda bir hata olustu.");
            }

            return new ServiceMessage
            {
                IsSucceed = true
            };
        }
    }
}
