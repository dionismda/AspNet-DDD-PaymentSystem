using Domain.ValueObjects;
using Flunt.Validations;
using Shared.Entities;

namespace Domain.Entities
{
    public abstract class Payment : BaseEntity
    {
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Document document, Address address, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Document = document;
            Address = address;
            Email = email;
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Payer { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }

        public override void Validate()
        {

            AddNotifications(Document, Address, Email);

            AddNotifications(
                new Contract<Payment>()
                        .Requires()
                        .IsGreaterThan(DateTime.Now, PaidDate, "PaidDate")
                        .IsGreaterThan(Total, 0, "Total")
                        .IsGreaterOrEqualsThan(Total, TotalPaid, "TotalPaid")
                        .IsGreaterThan(Payer.Length, 10, "Payer")
                        .AreEquals(Number.Length, 10, "Number")
            );
        }

    }
}
