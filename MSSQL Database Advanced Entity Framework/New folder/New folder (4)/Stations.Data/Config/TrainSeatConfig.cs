using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.Config
{
    public class TrainSeatConfig:IEntityTypeConfiguration<TrainSeat>
    {
        public void Configure(EntityTypeBuilder<TrainSeat> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.TrainId)
                .IsRequired();


            builder.Property(e => e.SeatingClassId)
                .IsRequired();


            builder.Property(e => e.Quantity)
                .IsRequired();

            builder.HasOne(e => e.Train)
                .WithMany(e => e.TrainSeats)
                .HasForeignKey(e => e.TrainId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
