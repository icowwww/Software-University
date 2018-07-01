using System;
using System.Collections.Generic;
using System.Text;
using MeTube.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeTube.Data.EntityConfiguration
{
    class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Username)
                .HasMaxLength(15)
                .IsRequired();
            builder.Property(e => e.PasswordHash)
                .HasMaxLength(15).IsRequired();
                builder.Property(e=> e.Email).HasMaxLength(15).IsRequired();
        }
    }
}
