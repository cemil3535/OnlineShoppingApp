using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShoppingApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        // Relational Property
        public ICollection<OrderEntity> Orders { get; set; }
    }

    public class UserConfiguration : BaseConfiguration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasIndex(x => x.Email)
                   .IsUnique();

            base.Configure(builder);    
        }

    }
}
