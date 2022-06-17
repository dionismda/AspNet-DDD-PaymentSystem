using Domain.ValueObjects;
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
            foreach (var sub in Subscriptions)
            {
                sub.ToggleActive(false);
            }

            _subscriptions.Add(subscription);
        }

    }
}
