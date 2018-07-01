using System;
using System.Collections.Generic;
using System.Text;
using MeTube.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeTube.Data.EntityConfiguration
{
    class TubeConfiguration:IEntityTypeConfiguration<Tube>
    {
        public void Configure(EntityTypeBuilder<Tube> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Author).HasMaxLength(15).IsRequired();
            builder.Property(e => e.Views).HasDefaultValue(0);
            builder.HasOne(e => e.User).WithMany(e => e.Tubes);
        }
    }
}
