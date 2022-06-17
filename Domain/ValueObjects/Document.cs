using Shared.Enums;
using Shared.ValueObjects;

namespace Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(EDocumentType type, string number)
        {
            Type = type;
            Number = number;
        }

        public EDocumentType Type { get; private set; }
        public string Number { get; private set; }
    }
}
