using Flunt.Br.Extensions;
using Flunt.Validations;
using Shared.Entities;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode) : base()
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public override void Validate()
        {
            AddNotifications(
                new Contract<Address>()
                        .IsNotNullOrEmpty(Street, "Street")
                            .IsGreaterOrEqualsThan(Street, 10, "Street")
                        .IsNotNullOrEmpty(Number, "Number")
                        .IsNotNullOrEmpty(Neighborhood, "Neighborhood")
                            .IsGreaterOrEqualsThan(Neighborhood, 10, "Street")
                        .IsNotNullOrEmpty(City, "City")
                            .IsGreaterOrEqualsThan(City, 10, "Street")
                        .IsNotNullOrEmpty(State, "State")
                        .IsNotNullOrEmpty(Country, "Country")
                        .IsNotNullOrEmpty(ZipCode, "ZipCode")
            );
        }
    }
}
