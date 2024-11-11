using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingApp.Business.Operations.Order;
using OnlineShoppingApp.Business.Operations.Order.Dtos;
using OnlineShoppingApp.WebApi.Filters;
using OnlineShoppingApp.WebApi.Models;
using System.Diagnostics.Eventing.Reader;

namespace OnlineShoppingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        
        

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        //Receiving orders with id
        [HttpGet("{id}")]

        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetOrder(id);

            if (order is null)
                return NotFound();
            else
                return Ok(order);
        }


        //taking all orders
        [HttpGet]

        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrders();

            return Ok(orders);
        }


        //add orders
        [HttpPost]

        public async Task<IActionResult> AddOrder(AddOrderRequest request)
        {
           

            var addorderDto = new AddOrderDto
            {
                OrderDate = request.OrderDate,
                TotalAmount = request.TotalAmount,
                ProductIds = request.ProductIds,
                CustomerId = request.CustomerId,
                Quantity = request.Quantity,          

            };

            var result = await _orderService.AddOrder(addorderDto);

            if (!result.IsSucceed)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok();    
            }

        }


        // Changing the total amount of the admin authority
        [HttpPatch("{id}/totalAmount")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AddOrderTotalAmounts(int id, decimal changeAmount)
        {
            var result = await _orderService.AddOrderTotalAmounts(id, changeAmount);

            if (!result.IsSucceed) 
                return NotFound(result.Message);
            else
                return Ok();
            
        }


        //Admin authorized person can change or delete the order.
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrder(id);

            if (!result.IsSucceed)
                return NotFound(result.Message);
            else
                return Ok();
        }


        // Limiting the time for sending requests
        [HttpPut("{id}")]
        //[Authorize(Roles ="Admin")]
        [TimeControlFilter]

        public async Task<IActionResult> UpdateOrder(int id, UpdateOrderRequest request)
        {
            var updateOrderDto = new UpdateOrderDto
            {
                Id = id,
                OrderDate = request.OrderDate,
                TotalAmount = request.TotalAmount,
                CustomerId = request.CustomerId
            };

            var result = await _orderService.UpdateOrder(updateOrderDto);

            if (!result.IsSucceed)
                return NotFound(result.Message);
            else
                return await GetOrder(id);
        }

    }
}
