using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingApp.WebApi.Models
{
    public class AddProductRequest
    {
        //  // AddProductRequest property definition
        [Required]
        public string ProductName { get; set; }
     
        public decimal Price { get; set; }

        public int StockQantity { get; set; }
    }
}

