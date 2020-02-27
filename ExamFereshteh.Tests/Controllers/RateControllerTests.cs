using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ExamFereshteh.Models;
using ExamFereshteh.Services.Factory;
using ExamFereshteh.Services.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ExamFereshteh.Controllers.Tests
{
    [TestClass()]
    public class RateControllerTests
    {
        private List<Rate> _rates;
        private RateController _rateController;
        private FakeRateRepository _repository;
        private GetRatesList _getRatesList;

        [TestInitialize]
        public void TestInitialize()
        {
           _getRatesList=new GetRatesList();
            _repository= new FakeRateRepository();
            _rateController = new RateController(_repository, _getRatesList);
            _rates = new List<Rate>
            {
                new Rate {Id = 1, From = "EUR", To = "USD", RateAmount =(decimal)1.359},
                new Rate {Id= 2, From = "CAD", To = "EUR", RateAmount =(decimal)0.732},
                new Rate {Id= 3 ,From = "USD", To = "EUR", RateAmount =(decimal)0.736},
                new Rate {Id= 4, From = "EUR", To = "CAD", RateAmount =(decimal)1.366},


            };

        }

        [TestMethod]
        public void Index_CheckNull_returnTrue()
        {
            //Act
            var actual = _rateController.Index();
            //Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void DetailsTest()
        {
            var id = 1;
            var actual = _rateController.Details(1);
            Assert.IsNotNull(actual);
        }

        






    }


}