using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using NUnit.Framework;

using webtest.Controllers;
using webtest.Models;
using webtest.Repositories;
using webtest.Tests.Models;

namespace webtest.Tests
{
    [TestFixture]
    public class CustomerControllerTest
    {
        CustomerController controller;
        InMemCustomerRepository repository;

        #region SetUp / TearDown

        [SetUp]
        public void Init()
        {
            repository = new InMemCustomerRepository();
            controller = GetCustomerController();
        }

        [TearDown]
        public void Dispose()
        { }

        #endregion

        #region Tests

        [Test]
        public void IndexView()
        {
            LoadTestData();

            ViewResult result = controller.Index() as ViewResult;
            Assert.AreEqual((result.ViewData.Model as IEnumerable<customer>).Count(), 3);
        }

        [Test]
        public void CreatePost()
        {
            LoadTestData();
            customer cust4 = GetCustomerName(4, "Jack", "McJack", "CM4", "test@email.com", "999-666-6666", "1010 Tenth Rd", "Weathorford", "TX", "74000");
            Assert.AreEqual(cust4.lastname, "Jack");

            FormCollection coll = new FormCollection();
            coll.Add("image", "1");
            ActionResult result = controller.Create(coll, cust4);
            Assert.IsNotNull(result);

            if (result is RedirectToRouteResult)
            {
                Assert.AreEqual((result as RedirectToRouteResult).RouteName, "Index");
            }
        }

        [Test]
        public void EditView()
        {
            LoadTestData();
            ViewResult result = controller.Edit(2) as ViewResult;
            Assert.AreEqual((result.ViewData.Model as customer).id, 2);
        }

        [Test]
        public void EditPost()
        {
            LoadTestData();
            customer cust2 = repository.GetById(2);
            cust2.lastname = "testlast";
            RedirectToRouteResult result = controller.Edit(2, null, cust2) as RedirectToRouteResult;
            cust2 = repository.GetById(2);
            Assert.AreEqual(cust2.lastname, "testlast");
        }

        [Test]
        public void DeletePost()
        {
            LoadTestData();
            RedirectToRouteResult result = controller.Delete(2) as RedirectToRouteResult;
            Assert.AreEqual(repository.GetAll().Count(), 2);
        }

        [Test]
        public void AddNoteView()
        {
            LoadTestData();
            ViewResult result = controller.AddNote(2) as ViewResult;
            Assert.AreEqual((result.ViewData.Model as customer).id, 2);
        }

        #endregion

        private CustomerController GetCustomerController()
        {
            CustomerController custController = new CustomerController(this.repository);
            custController.ControllerContext = new ControllerContext()
            {
                Controller = custController,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };
            return custController;
        }
        
        private void LoadTestData()
        {
            repository.Add(GetCustomerName(1, "Joe", "McJoe", "CM1", "test@email.com", "999-999-9999", "1010 Tenth Ave", "Fort Worth", "TX", "76200"));
            repository.Add(GetCustomerName(2, "Jon", "McJon", "CM2", "test@email.com", "999-888-8888", "1010 Tenth St", "Dallas", "TX", "75200"));
            repository.Add(GetCustomerName(3, "Jim", "McJim", "CM3", "test@email.com", "999-777-7777", "1010 Tenth Blvd", "Arlington", "TX", "77200"));
        }

        private customer GetCustomerName(int id, string lName, string fName, string cmpny, string eml, string phn, string address, string city, string region, string postalCode)
        {
            return new customer
            {
                id = id,
                lastname = lName,
                firstname = fName,
                companyname = cmpny,
                email = eml,
                phone = phn,
                street = address,
                city = city,
                state = region,
                postalcode = postalCode
            };
        }
    }
}
