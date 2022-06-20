using Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Enums;

namespace Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        [TestCategory("ValueObject")]
        public void Dado_um_novo_cpf_com_marcara_deve_ser_valido()
        {
            Document document = new Document(EDocumentType.CPF, "395.912.270-51");
            document.Validate();
            Assert.IsTrue(document.IsValid);
        }

        [TestMethod]
        [TestCategory("ValueObject")]
        public void Dado_um_novo_cpf_sem_marcara_deve_ser_valido()
        {
            Document document = new Document(EDocumentType.CPF, "39591227051");
            document.Validate();
            Assert.IsTrue(document.IsValid);
        }

        [TestMethod]
        [TestCategory("ValueObject")]
        public void Dado_um_novo_cpf_invalido_deve_ser_falso()
        {
            Document document = new Document(EDocumentType.CPF, "39591227050");
            document.Validate();
            Assert.IsFalse(document.IsValid);
        }

        [TestMethod]
        [TestCategory("ValueObject")]
        public void Dado_um_novo_cnpj_com_marcara_deve_ser_valido()
        {
            Document document = new Document(EDocumentType.CNPJ, "89.761.929/0001-47");
            document.Validate();
            Assert.IsTrue(document.IsValid);
        }

        [TestMethod]
        [TestCategory("ValueObject")]
        public void Dado_um_novo_cnpj_sem_marcara_deve_ser_valido()
        {
            Document document = new Document(EDocumentType.CNPJ, "89761929000147");
            document.Validate();
            Assert.IsTrue(document.IsValid);
        }

        [TestMethod]
        [TestCategory("ValueObject")]
        public void Dado_um_novo_cnpj_invalido_deve_ser_falso()
        {
            Document document = new Document(EDocumentType.CNPJ, "89761929000148");
            document.Validate();
            Assert.IsFalse(document.IsValid);
        }

    }
}
