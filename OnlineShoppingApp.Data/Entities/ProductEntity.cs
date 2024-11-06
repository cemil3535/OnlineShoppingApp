using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Data.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int StockQantity { get; set; }

        // Relational Property

        public ICollection<OrderProductEntity> OrderProducts { get; set; }

    }

    public class ProductConfiguration : BaseConfiguration<ProductEntity>
    {
        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(x => x.Price)
                   .HasColumnType("decimal(16,2)");

            base.Configure(builder);    
        }
    }
}
