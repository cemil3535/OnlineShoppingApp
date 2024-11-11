using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Order.Dtos
{
    //Creating AddOrderDto

    public class AddOrderDto
    {
        public DateTime? OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public List<int> ProductIds { get; set; }

        public int CustomerId{ get; set; }

        public int Quantity { get; set; } 
    }
}
