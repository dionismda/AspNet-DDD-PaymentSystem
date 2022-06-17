using Flunt.Validations;
using Shared.ValueObjects;

namespace Domain.ValueObjects
{
    public class Email : BaseValueObject
    {
        public Email(string addressEmail)
        {
            AddressEmail = addressEmail;
        }

        public string AddressEmail { get; private set; }

        public override void Validate()
        {
            AddNotifications(
                new Contract<Email>()
                        .Requires()
                        .IsEmail(AddressEmail, "AddressEmail")
                );
        }
    }
}
