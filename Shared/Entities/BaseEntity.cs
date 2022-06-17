using Flunt.Notifications;
using Shared.Interfaces;
using Shared.ValueObjects;

namespace Shared.Entities
{
    public abstract class BaseEntity : Notifiable<Notification>, INotifiableValidate<BaseValueObject>
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public abstract void Validate();

        public Guid Id { get; private set; }
    }
}
