using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Data.Entities
{
    public class OrderEntity : BaseEntity
    {
        public DateTime? OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public int UserId { get; set; }


        // Relational Property
        public UserEntity User { get; set; }   // DIKKAT bu olmaya bilir


        // Relational Property
        public ICollection<OrderProductEntity> OrderProducts { get; set; }

    }

    public class OrderConfiguration : BaseConfiguration<OrderEntity> 
    {
        public override void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.Property(x => x.TotalAmount)
                   .HasColumnType("decimal(16,2)");


            base.Configure(builder);
        }
    }
}
