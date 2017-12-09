using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.Config
{
    public class TicketConfig:IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Price)
                .IsRequired();

            builder.Property(e => e.TripId)
                .IsRequired();

            builder.HasOne(e => e.CustomerCard)
                .WithMany(e => e.BoughtTickets)
                .HasForeignKey(e => e.CustomerCardId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
