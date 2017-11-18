﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.Config
{
    public class PaymentMethodConfiguration:IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasIndex(e => new
            {
                e.UserId,
                e.BankAccountId,
                e.CreditCardId
            }).IsUnique();

            builder.HasOne(e => e.User)
                .WithMany(e => e.PaymentMethods)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.BankAccount)
                .WithOne(e => e.PaymentMethod)
                .HasForeignKey<PaymentMethod>(e => e.BankAccountId);

            builder.HasOne(e => e.CreditCard)
                .WithOne(e => e.PaymentMethod)
                .HasForeignKey<PaymentMethod>(e => e.CreditCardId);
        }
    }
}
