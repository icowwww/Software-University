﻿using System;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Functionality
{
    public static class SeedDatabase
    {
        public static string Seed(BillsPaymentSystemContext context)
        {
            var user = new User
            {
                FirstName = "Georgi",
                LastName = "Ivanov",
                Email = "givanov@abv.bg",
                Password = "111111111"
            };

            var firstCreditCard = new CreditCard(8000M, 1000M)
            {
                ExpirationDate = DateTime.ParseExact("01.01.2021", "dd.MM.yyyy", null)
            };

            var secondCreditCard = new CreditCard(5000M, 2500M)
            {
                ExpirationDate = DateTime.ParseExact("07.02.2021", "dd.MM.yyyy", null)
            };

            var bankAccount = new BankAccount(5000M)
            {
                BankName = "ASD bank",
                SwiftCode = "ASDBGN1022"
            };

            var firstPayment = new PaymentMethod
            {
                User = user,
                CreditCard = firstCreditCard,
                Type = PaymentType.CreditCard
            };

            var secondPayment = new PaymentMethod
            {
                User = user,
                CreditCard = secondCreditCard,
                Type = PaymentType.CreditCard
            };

            var thirdPayment = new PaymentMethod
            {
                User = user,
                BankAccount = bankAccount,
                Type = PaymentType.BankAccount
            };

            try
            {
                context.Users.Add(user);
                context.CreditCards.Add(firstCreditCard);
                context.CreditCards.Add(secondCreditCard);
                context.BankAccounts.Add(bankAccount);
                context.PaymentMethods.Add(firstPayment);
                context.PaymentMethods.Add(secondPayment);
                context.PaymentMethods.Add(thirdPayment);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                const string possibleError2 = "Cannot open database \"BillsPaymentSystem\" requested by the login";
                const string possibleError3 = "Verify that the instance name is correct and that SQL Server" +
                                              " is configured to allow remote connections.";

                if (e.ToString().Contains(possibleError2))
                    return
                        $"Failed seeding the database! {possibleError2}! Create database first using the create command!";
                if (!e.ToString().Contains(possibleError3)) return $"Failed seeding the database! {e}";
                SettingUpConnection.SetUp();
                return "";
            }
            return "Successfull database seed! If you seed more than once the entries are not going to be unique.";
        }
    }
}
