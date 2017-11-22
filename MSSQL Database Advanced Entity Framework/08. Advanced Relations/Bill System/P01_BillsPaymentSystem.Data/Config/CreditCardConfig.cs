using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.Config
{
    public class CreditCardConfig:IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(e => e.CreditCardId);

            builder.Property(e => e.Limit)
                .IsRequired();

            builder.Property(e => e.MoneyOwed)
                .IsRequired();

            builder.Property(e => e.ExpirationDate)
                .IsRequired();

            builder.Ignore(c => c.LimitLeft);

            builder
                .Ignore(b => b.PaymentMethodId);
        }
    }
}
