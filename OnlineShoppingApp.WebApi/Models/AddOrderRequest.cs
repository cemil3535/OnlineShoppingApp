using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingApp.WebApi.Models
{
    public class AddOrderRequest
    {
        // AddOrderRequest property definition
        public DateTime? OrderDate { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public List<int> ProductIds { get; set; }

        public int CustomerId { get; set; } 

        public int Quantity { get; set; } 
    }
}


