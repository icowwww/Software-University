using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.Config
{
    public class TripConfig:IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.OriginStationId)
                .IsRequired();

            builder.Property(e => e.DestinationStationId)
                .IsRequired();

            builder.Property(e => e.DepartureTime)
                .IsRequired();

            builder.Property(e => e.ArrivalTime)
                .IsRequired();

            builder.Property(e => e.TrainId)
                .IsRequired();

            builder.HasOne(e => e.Train)
                .WithMany(e => e.Trips)
                .HasForeignKey(e => e.TrainId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.OriginStation)
                .WithMany(e => e.TripsFrom)
                .HasForeignKey(e => e.OriginStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.DestinationStation)
                .WithMany(e => e.TripsTo)
                .HasForeignKey(e => e.DestinationStationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
