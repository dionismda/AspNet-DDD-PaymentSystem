using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Enums;

namespace Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _nomeCorreto= new Name("FirstName", "LastName") ;
        private readonly Document _documentoCorreto = new Document(EDocumentType.CPF, "131.247.380-04");
        private readonly Email _emailCorreto = new Email("estudando@teste.com.br");

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_estudante_completo_deve_ser_valido()
        {
            Student student = new Student(_nomeCorreto, _documentoCorreto, _emailCorreto);
            student.AddAddress(new Address("Rua endereço de testes", "208", "Bairro de teste", "Cidade de teste", "Estado de teste", "Pais de teste", "13465000"));
            student.Validate();
            Assert.AreEqual(student.IsValid, true);
        }

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_estudante_sem_endereco_deve_ser_valido()
        {
            Student student = new Student(_nomeCorreto, _documentoCorreto, _emailCorreto);
            student.Validate();
            Assert.AreEqual(student.IsValid, true);
        }

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_estudante_sem_endereco_o_mesmo_deve_ser_nulo()
        {
            Student student = new Student(_nomeCorreto, _documentoCorreto, _emailCorreto);
            Assert.AreEqual(student.Address, null);
        }

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_estudante_cem_endereco_invalido_mesmo_deve_ser_nulo()
        {
            Student student = new Student(_nomeCorreto, _documentoCorreto, _emailCorreto);
            student.AddAddress(new Address("", "208", "Bairro de teste", "Cidade de teste", "Estado de teste", "Pais de teste", "13465000"));
            Assert.AreEqual(student.Address, null);
        }

    }
}
