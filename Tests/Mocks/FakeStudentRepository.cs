using Domain.Entities;
using Domain.Repository;
using Shared.Enums;

namespace Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {

        }

        public bool DocumentExists(string document, EDocumentType documentType)
        {
            if (document == "04927487059")
                return true;

            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "teste@teste.com.br")
                return true;

            return false;
        }
    }
}
