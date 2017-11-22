using System.Linq;
using System.Text;
using P01_BillsPaymentSystem.Data;

namespace P01_BillsPaymentSystem.Functionality
{
    public class UserDetails
    {
        public string DisplayInfo(BillsPaymentSystemContext context, int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
                return $"User with id {userId} not found!";
            var sb = new StringBuilder();
            sb.AppendLine($"User {user.FirstName} {user.LastName}");
            var bankAccounts = context.BankAccounts.Where(b => b.PaymentMethod.UserId == userId);
            if (bankAccounts.Any())
            {
                sb.AppendLine("Bank Accounts:");
                foreach (var bankAccount in bankAccounts)
                    sb.AppendLine(bankAccount.ToString());
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
                    sb.Append(creditCard);
            }
            else
            {
                sb.Append("User does not have any Credit Cards!");
            }

            return sb.ToString();
        }
    }
}
