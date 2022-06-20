using Flunt.Notifications;
using Shared.Interfaces;

namespace Shared.Entities
{
    public abstract class BaseEntity : Notifiable<Notification>, INotifiableValidate<BaseEntity>
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public abstract void Validate();

        public Guid Id { get; private set; }
    }
}
