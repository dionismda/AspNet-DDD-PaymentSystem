using Flunt.Validations;
using Shared.Entities;

namespace Domain.Entities
{
    public class Subscription : BaseEntity
    {
        private IList<Payment> _payments;
        public Subscription(DateTime? expireDate = null)
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = expireDate;
            Active = true;

            _payments = new List<Payment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }
        public void AddPayment(Payment payment)
        {
            payment.Validate();
            if (payment.IsValid)
            {
                _payments.Add(payment);
            }            
        }

        public void ToggleActive(bool active)
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        public override void Validate()
        {
            AddNotifications(
                new Contract<Subscription>()
                        .Requires()
                        .AreEquals(DateTime.Now, CreateDate, "CreateDate")
                        .AreEquals(DateTime.Now, LastUpdateDate, "LastUpdateDate")
            );
        }
    }
}
