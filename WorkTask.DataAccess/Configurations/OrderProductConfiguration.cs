using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTask.DataAccess.Configurations
{
    internal class OrderProductConfiguration: IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.OrderId });
            builder.HasOne(x => x.Product).WithOne().HasForeignKey<OrderProduct>(x => x.ProductId);
            //builder.HasOne(x => x.Order).WithMany(x=> x.Products).HasForeignKey(x => x.OrderId);
            builder.Property(x => x.Quantity);
            //builder.Property(x=> x.ProductId);
        }
    }
}
