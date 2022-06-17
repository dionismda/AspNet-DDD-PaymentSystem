using Flunt.Notifications;

namespace Shared.Interfaces
{
    public interface INotifiableValidate<TNotifiableValidate> where TNotifiableValidate : Notifiable<Notification>
    {
        void Validate();
    }
}
