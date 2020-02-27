using System.Collections.Generic;
using ExamFereshteh.Controllers;
using ExamFereshteh.Models;
using ExamFereshteh.Services.Factory;
using ExamFereshteh.Services.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamFereshteh.Tests.Controllers
{
    [TestClass()]
    public class TransactionControllerTest
    {
        private List<Transaction> _transactions;
        private TransactionController _transactionController;
        private FakeRepository<Transaction> _repository;
        private GetTransactionsList _getTransactionsList;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new FakeRepository<Transaction>();
          

            _getTransactionsList= new GetTransactionsList();
            _transactionController = new TransactionController(_repository, _getTransactionsList);
           
            _transactions = new List<Transaction>
            {
                new Transaction {Id = 1, Sku = "T2006", Amount = 10, Currency = "USD"},
                new Transaction {Id = 2,Sku = "M2007", Amount = (decimal) 34.57, Currency = "CAD"},
                new Transaction {Id =3,Sku = "R2008", Amount = (decimal) 17.95, Currency = "USD"},
                new Transaction {Id=4, Sku = "T2006", Amount = (decimal) 7.63, Currency = "USD"},
                new Transaction {Id =5, Sku = "B2009", Amount = (decimal) 21.23, Currency = "USD"},

            };

        }
        [TestMethod]
        public void Index_CheckNull_returnTrue()
        {
          
           //Act
            var actual = _transactionController.Index();
            //Assert
            Assert.IsNotNull(actual);
           
        }

        [TestMethod]
        public void DetailsTest()
        {
            var id = 1;
            var actual = _transactionController.Details(1);
            Assert.IsNotNull(actual);
        }
    }
}
