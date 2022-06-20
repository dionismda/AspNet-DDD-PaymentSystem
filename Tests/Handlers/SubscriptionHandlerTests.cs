using Domain.Commands;
using Domain.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Enums;
using System;
using Tests.Mocks;

namespace Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void Dado_um_documento_que_existe_retorna_error()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository());
            var command = new CreatePayPalSubscriptionCommand();
            command.FirstName = "Teste";
            command.LastName = "Teste LastName";
            command.Document = "04927487059";
            command.DocumentType = EDocumentType.CPF;
            command.Email = "teste@teste.com.br";
            command.TransactionCode = "0123456789";
            command.PaymentNumber = "123121";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Teste";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "teste@teste.com.br";
            command.Street = "asdas";
            command.Number = "asdd";
            command.Neighborhood = "asdasd";
            command.City = "as";
            command.State = "as";
            command.Country = "as";
            command.ZipCode = "12345678";

            handler.Handle(command);
            Assert.AreEqual(false, handler.IsValid);
        }
    }
}
