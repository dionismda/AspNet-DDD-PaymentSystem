using Flunt.Notifications;
using Shared.Interfaces;

namespace Shared.ValueObjects
{
    public abstract class BaseValueObject : Notifiable<Notification>, INotifiableValidate<BaseValueObject>
    {
        public abstract void Validate();
    }
}
