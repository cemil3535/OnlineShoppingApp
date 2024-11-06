﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Product.Dtos
{
    // AddProductDto make property
    public class AddProductDto
    {
        
        public string ProductName { get; set; }
        
        public decimal Price { get; set; }
        
        public int StockQantity { get; set; }
    }
}
