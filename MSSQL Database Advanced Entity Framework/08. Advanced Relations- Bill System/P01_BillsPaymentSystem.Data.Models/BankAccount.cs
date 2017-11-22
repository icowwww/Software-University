using System.Text;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public decimal Balance { get; private set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public BankAccount()
        {
        }

        public BankAccount(decimal balance)
        {
            this.Balance = balance;
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            this.Balance = amount;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"-- ID: {this.BankAccountId}");
            sb.AppendLine($"--- Balance: {this.Balance:F2}");
            sb.AppendLine($"--- Bank: {this.BankName}");
            sb.Append($"--- SWIFT: {this.SwiftCode}");
            return sb.ToString();
        }
    }
}
