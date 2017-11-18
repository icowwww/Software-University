using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem
{
    public class BillPayer
    {
        public string PayBills(int userId, decimal amount, BillsPaymentSystemContext context)
        {
            var user = context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return $"User with id {userId} not found!";
            }
            var bankAccounts = context.BankAccounts.Where(b => b.PaymentMethod.UserId == userId).ToList();
            var creditCards = context.CreditCards.Where(c => c.PaymentMethod.UserId == userId).ToList();
            var allMoney = bankAccounts.Sum(b => b.Balance) + creditCards.Sum(c => c.LimitLeft);
            if (allMoney <amount)
            {
                return "Insufficient funds!";
            }
            var isPayed = false;
            foreach (var bankAccount in bankAccounts.OrderBy(b=> b.BankAccountId))
            {
                if (amount<= bankAccount.Balance)
                {
                    bankAccount.Withdraw(amount);
                    isPayed = true;
                }
                else
                {
                    amount = amount - bankAccount.Balance;
                    Console.WriteLine(amount);
                    bankAccount.Withdraw(bankAccount.Balance);
                }
                if (!isPayed) continue;
                context.SaveChanges();
                return "Bills payed!";
            }
            foreach (var creditCard in creditCards)
            {
                if (amount <= creditCard.LimitLeft)
                {
                    creditCard.Withdraw(amount);
                    isPayed = true;
                }
                else
                {
                    amount -= creditCard.LimitLeft;
                    creditCard.Withdraw(creditCard.LimitLeft);
                }
                if (!isPayed) continue;
                context.SaveChanges();
                return "Bills payed!";
            }
            return "Problem with the method logic.";

        }
    }
}
