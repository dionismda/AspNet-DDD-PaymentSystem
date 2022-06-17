using Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        [TestCategory("ValueObject")]
        public void Dado_um_novo_email_deve_ser_valido()
        {
            Email email = new Email("teste@teste.com.br");
            email.Validate();
            Assert.AreEqual(email.IsValid, true);
        }

        [TestMethod]
        [TestCategory("ValueObject")]
        public void Dado_um_email_vazio_deve_ser_invalido()
        {
            Email email = new Email("");
            email.Validate();
            Assert.AreEqual(email.IsValid, false);
        }

        [TestMethod]
        [TestCategory("ValueObject")]
        public void Dado_um_email_invalido_deve_ser_falso()
        {
            Email email = new Email("teste.com.br");
            email.Validate();
            Assert.AreEqual(email.IsValid, false);
        }
    }
}
