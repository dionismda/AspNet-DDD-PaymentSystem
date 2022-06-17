using Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        [TestCategory("ValueObject")]
        public void Dado_um_novo_nome_deve_ser_valido()
        {
            Name name = new Name("UserTest", "LastNameTest");
            name.Validate();
            Assert.AreEqual(name.IsValid, true);
        }

        [TestMethod]
        [TestCategory("ValueObject")]
        public void Dado_um_sobrenome_vazio_deve_ser_invalido()
        {
            Name name = new Name("UserTest", "");
            name.Validate();
            Assert.AreEqual(name.IsValid, false);
        }
    }
}
