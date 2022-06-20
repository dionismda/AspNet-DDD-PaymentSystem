using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Enums;
using System;

namespace Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _nomeCorreto;
        private readonly Document _documentoCorreto;
        private readonly Email _emailCorreto;
        private readonly Address _addressCorreto;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _nomeCorreto = new Name("FirstName", "LastName");
            _documentoCorreto = new Document(EDocumentType.CPF, "131.247.380-04");
            _emailCorreto = new Email("estudante@teste.com.br");
            _addressCorreto = new Address("Rua endereço de testes", "208", "Bairro de teste", "Cidade de teste", "Estado de teste", "Pais de teste", "13465000");
            _subscription = new Subscription(null);
            _student = new Student(_nomeCorreto, _documentoCorreto, _emailCorreto);
        }

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_estudante_completo_deve_ser_valido()
        {
            _student.AddAddress(_addressCorreto);
            _student.Validate();
            Assert.AreEqual(_student.IsValid, true);
        }

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_estudante_sem_endereco_deve_ser_valido()
        {
            _student.Validate();
            Assert.AreEqual(_student.IsValid, true);
        }

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_estudante_sem_endereco_o_mesmo_deve_ser_nulo()
        {
            Assert.AreEqual(_student.Address, null);
        }

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_estudante_com_endereco_invalido_mesmo_deve_ser_nulo()
        {
            _student.AddAddress(new Address("", "208", "Bairro de teste", "Cidade de teste", "Estado de teste", "Pais de teste", "13465000"));
            Assert.AreEqual(_student.Address, null);
        }

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_estudante_com_subscription_com_pagamento()
        {
            PayPalPayment payPalPayment = new PayPalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Teste Teste Teste Teste", _documentoCorreto, _addressCorreto, new Email("teste@teste.com.br"), "0123456789");
            _subscription.AddPayment(payPalPayment);

            _student.AddAddress(_addressCorreto);
            _student.AddSubscription(_subscription);

            Assert.AreEqual(_student.IsValid, true);
        }

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_estudante_com_subscription_sem_pagamento()
        {
            _student.AddSubscription(_subscription);

            Assert.AreEqual(_student.IsValid, false);
        }

    }
}
