﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Order.Dtos
{
    //Creating OrderDto
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime? OrderDate { get; set; }

        public decimal TotalAmount {  get; set; }

        public List<OrderProductDto> Products { get; set; }
    }
}
