using OnlineShoppingApp.Business.Operations.Order.Dtos;
using OnlineShoppingApp.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Order
{
    //Creating IOrderService
    public interface IOrderService
    {
        Task<ServiceMessage> AddOrder(AddOrderDto order);

        Task<OrderDto> GetOrder(int id);

        Task<List<OrderDto>> GetOrders();

        Task<ServiceMessage> AddOrderTotalAmounts(int id, decimal changeAmount);

        Task<ServiceMessage> DeleteOrder(int id);

        Task<ServiceMessage> UpdateOrder(UpdateOrderDto order);
    }
}
