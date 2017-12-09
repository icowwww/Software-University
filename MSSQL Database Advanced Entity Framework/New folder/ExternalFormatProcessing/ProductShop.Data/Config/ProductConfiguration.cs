using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShop.Models;

namespace ProductShop.Data.Config
{
    public class ProductConfiguration :IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e=>e.Id);

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.Price)
                .IsRequired();

            builder.Property(e => e.BuyerId)
                .IsRequired(false);

            builder.Property(e => e.SellerId)
                .IsRequired();

            builder.HasOne(e => e.Seller)
                .WithMany(e => e.ProductsSold)
                .HasForeignKey(e => e.SellerId);

            builder.HasOne(e => e.Buyer)
                .WithMany(e => e.ProductsBought)
                .HasForeignKey(e => e.BuyerId);
        }
    }
}
