using System;
using System.Collections.Generic;
using System.Text;
using KittenApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KittenApp.Data.EntityConfiguration
{
    class KittenConfiguration:IEntityTypeConfiguration<Kitten>
    {
        public void Configure(EntityTypeBuilder<Kitten> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Age);

            builder.HasOne(e => e.User)
                .WithMany(e => e.Kittens)
                .HasForeignKey(e=> e.UserId);
        }
    }
}
