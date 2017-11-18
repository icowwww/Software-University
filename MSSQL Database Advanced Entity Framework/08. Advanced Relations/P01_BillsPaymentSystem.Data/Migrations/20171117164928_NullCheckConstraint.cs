using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace P01_BillsPaymentSystem.Data.Migrations
{
    public partial class NullCheckConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE PaymentMethods " +
                                 "ADD CONSTRAINT CH_CreditCard_BankAccount " +
                                 "CHECK(" +
                                 "(CreditCardId IS NULL AND BankAccountId IS NOT NULL) OR " +
                                 "(CreditCardId IS NOT NULL AND BankAccountId IS NULL))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
