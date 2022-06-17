using Flunt.Validations;
using Shared.ValueObjects;

namespace Domain.ValueObjects
{
    public class Name : BaseValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override void Validate()
        {
            AddNotifications(
                new Contract<Name>()
                        .Requires()
                        .IsGreaterOrEqualsThan(FirstName, 3, "FirstName")
                            .IsLowerThan(FirstName, 40, "FirstName")
                        .IsGreaterOrEqualsThan(LastName, 3, "FirstName")                        
            );
        }
    }
}
