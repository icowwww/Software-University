using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P01_BillsPaymentSystem.Data;

namespace P01_BillsPaymentSystem
{
    public class UserDetails
    {
        public string DisplayInfo(BillsPaymentSystemContext context, int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user ==null)
            {
                return $"User with id {userId} not found!";
            }
            var sb = new StringBuilder();
            sb.AppendLine($"User {user.FirstName} {user.LastName}");
            var bankAccounts = context.BankAccounts.Where(b => b.PaymentMethod.UserId == userId);
            if (bankAccounts.Any())
            {
                sb.AppendLine("Bank Accounts:");
                foreach (var bankAccount in bankAccounts)
                {
                    sb.AppendLine($"-- ID: {bankAccount.BankAccountId}");
                    sb.AppendLine($"--- Balance: {bankAccount.Balance:F2}");
                    sb.AppendLine($"--- Bank: {bankAccount.BankName}");
                    sb.AppendLine($"--- SWIFT: {bankAccount.SwiftCode}");
                }
            }
            else
            {
                sb.AppendLine("User does not have any Bank accounts!");
            }
            var creditCards = context.CreditCards.Where(c => c.PaymentMethod.UserId == userId);
            if (creditCards.Any())
            {
                sb.AppendLine("Credit Cards:");
                foreach (var creditCard in creditCards)
                {
                    sb.AppendLine($"-- ID: {creditCard.CreditCardId}");
                    sb.AppendLine($"--- Limit: {creditCard.Limit:F2}");
                    sb.AppendLine($"--- Money Owed: {creditCard.MoneyOwed:F2}");
                    sb.AppendLine($"--- Limit Left: {creditCard.LimitLeft:F2}");
                    sb.Append($"--- Expiration Date: {creditCard.ExpirationDate.Year}/{creditCard.ExpirationDate.Month}");
                }
            }
            else
            {
                sb.Append("User does not have any Credit Cards!");
            }

            return sb.ToString();
        }
    }
}
