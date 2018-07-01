using System;
using System.Collections.Generic;
using System.Text;
using KittenApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KittenApp.Data.EntityConfiguration
{
    class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Username)
                .IsRequired(true);
            builder.Property(e => e.PasswordHash)
                .IsRequired(true);
        }
    }
}
