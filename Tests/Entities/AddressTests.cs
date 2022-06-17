using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Entities
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_endereco_completo_deve_ver_valido()
        {
            Address address = new Address("Rua endereço de testes", "208", "Bairro de teste", "Cidade de teste", "Estado de teste", "Pais de teste", "13465000");
            address.Validate();
            Assert.AreEqual(address.IsValid, true);
        }

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_endereco_sem_rua_deve_ver_invalido()
        {
            Address address = new Address("", "208", "Bairro de teste", "Cidade de teste", "Estado de teste", "Pais de teste", "13465000");
            address.Validate();
            Assert.AreEqual(address.IsValid, false);
        }

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_endereco_com_rua_de_5_caracteres_ver_invalido()
        {
            Address address = new Address("Rua 5", "208", "Bairro de teste", "Cidade de teste", "Estado de teste", "Pais de teste", "13465000");
            address.Validate();
            Assert.AreEqual(address.IsValid, false);
        }

    }
}
