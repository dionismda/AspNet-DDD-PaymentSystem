using Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Commands
{
    [TestClass]
    public class CreatePayPalSubscriptionCommandTests
    {
        [TestMethod]
        [TestCategory("Commands")]
        public void Dado_um_nome_invalido_retorna_error()
        {
            CreatePayPalSubscriptionCommand command = new CreatePayPalSubscriptionCommand();
            command.FirstName = "";
            command.Validate();
            Assert.AreEqual(command.IsValid, false);
        }
    }
}
