using Domain.Core.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDBContext.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x=>x.ManufacturerPhoneNumber)
                .IsRequired()
                .HasMaxLength(11);
            builder.Property(x=>x.ManufacturerEmail)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.ProduceDate);
        }
    }
}
