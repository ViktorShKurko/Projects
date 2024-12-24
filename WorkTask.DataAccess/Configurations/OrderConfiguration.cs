using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace WorkTask.DataAccess.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.HasAlternateKey(x => x.InnerId);
            builder.Property(x => x.Sum);
            builder.Property(x => x.Reistered);
            builder.HasOne(x=> x.User).WithMany(x=> x.Orders).HasForeignKey(x => x.UserId).IsRequired();
            builder.HasMany(x => x.Products).WithOne(x => x.Order).HasForeignKey(x=> x.OrderId).IsRequired();
        }
    }
}
