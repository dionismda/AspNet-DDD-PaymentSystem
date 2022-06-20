using Domain.Entities;
using Shared.Enums;

namespace Domain.Repository
{
    public interface IStudentRepository
    {
        bool DocumentExists(string document, EDocumentType documentType);
        bool EmailExists(string email);
        void CreateSubscription(Student student);
    }
}
