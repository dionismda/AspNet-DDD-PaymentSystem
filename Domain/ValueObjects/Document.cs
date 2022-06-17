using Flunt.Br;
using Flunt.Br.Extensions;
using Shared.Enums;
using Shared.ValueObjects;

namespace Domain.ValueObjects
{
    public class Document : BaseValueObject
    {
        public Document(EDocumentType type, string number)
        {
            Type = type;
            Number = number;
        }

        public EDocumentType Type { get; private set; }
        public string Number { get; private set; }

        public override void Validate()
        {
            if (Type == EDocumentType.CPF)
            {
                AddNotifications(
                    new Contract()
                            .IsCpf(Number, "Number", "Invalid document")
                    );
            } else {
                AddNotifications(
                    new Contract()
                            .IsCnpj(Number, "Number", "Invalid document")
                    );
            }
        }
    }
}
