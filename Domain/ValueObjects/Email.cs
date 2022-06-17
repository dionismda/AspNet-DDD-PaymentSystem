using Shared.ValueObjects;

namespace Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string addressEmail)
        {
            AddressEmail = addressEmail;
        }

        public string AddressEmail { get; private set; }
    }
}
