using Microsoft.EntityFrameworkCore;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTask.DataAccess.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x=> x.FirstName).HasMaxLength(1000);
            builder.Property(x=> x.LastName).HasMaxLength(1000);
            builder.Property(x => x.MiddleName).HasMaxLength(1000);
            builder.HasAlternateKey(x => x.Email);
        }
    }
}
