using System;
using System.Collections.Generic;
using System.Text;
using Instagraph.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Instagraph.Data.Config
{
    public class UserConfig:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasAlternateKey(e => e.Username);

            builder.Property(e => e.Username)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.Password)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasOne(e => e.ProfilePicture)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.ProfilePictureId);
        }
    }
}
