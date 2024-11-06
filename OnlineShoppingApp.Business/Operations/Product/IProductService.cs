using OnlineShoppingApp.Business.Operations.Product.Dtos;
using OnlineShoppingApp.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Product
{
    public interface IProductService
    {
        Task<ServiceMessage> AddProduct(AddProductDto product);
    }
}
