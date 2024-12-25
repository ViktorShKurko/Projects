using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTask.DataAccess.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Price);
            builder.Property(x => x.Name);
            builder.HasMany(x=> x.OrderProducts).WithOne(x => x.Product).HasForeignKey(x=> x.ProductId);
        }
    }
}
