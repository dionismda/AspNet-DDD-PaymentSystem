using Domain.ValueObjects;
using Flunt.Validations;
using Shared.Entities;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email) : base()
        {
            Name = name;
            Document = document;
            Email = email;

            _subscriptions = new List<Subscription>();
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address? Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }
        public void AddSubscription(Subscription subscription)
        {
            bool hasSubscriptionActive = false;
            foreach (var sub in _subscriptions)
            {
                if (sub.Active)
                {
                    hasSubscriptionActive = true;
                }
            }

            AddNotifications(
                new Contract<Student>()
                        .Requires()
                        .IsFalse(hasSubscriptionActive, "Student.Subscriptions")
                        .IsGreaterThan(subscription.Payments.Count, 0, "Student.Subscriptions.Payments")
            );

            subscription.Validate();
            if (subscription.IsValid && IsValid)
                _subscriptions.Add(subscription);
        }

        public void AddAddress(Address address)
        {
            address.Validate();

            Address = address.IsValid ? address : null;
        }

        public override void Validate()
        {
            AddNotifications(Name, Document, Email);
        }
    }
}
