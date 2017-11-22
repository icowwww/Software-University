using System;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }
        public decimal MoneyOwed { get; private set; }
        public decimal Limit { get; private set; }
        public decimal LimitLeft => this.Limit - this.MoneyOwed;
        public DateTime ExpirationDate { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public CreditCard()
        {
        }

        public CreditCard(decimal limitAmount, decimal moneyOwed)
        {
            this.Limit = limitAmount;
            this.MoneyOwed = moneyOwed;
        }

        public void Withdraw(decimal amount)
        {
            this.MoneyOwed += amount;
        }

        public void Deposit(decimal amount)
        {
            this.MoneyOwed -= amount;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"-- ID: {this.CreditCardId}");
            sb.AppendLine($"--- Limit: {this.Limit:F2}");
            sb.AppendLine($"--- Money Owed: {this.MoneyOwed:F2}");
            sb.AppendLine($"--- Limit Left: {this.LimitLeft:F2}");
            sb.AppendLine($"--- Expiration Date: {this.ExpirationDate.Year}/{this.ExpirationDate.Month}");
            return sb.ToString();
        }
    }
}
