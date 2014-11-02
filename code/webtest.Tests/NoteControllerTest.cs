using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using webtest.Controllers;
using webtest.Models;

namespace webtest.Tests
{
    [TestFixture]
    public class NoteControllerTest
    {
        #region SetUp / TearDown

        [SetUp]
        public void Init()
        { }

        [TearDown]
        public void Dispose()
        { }

        #endregion

        #region Tests

        [Test]
        public void Test_CreateGet()
        {
            note testnote = new note();
            testnote.customerid = 1;

            NoteController ctrlr = GetController();
            ViewResult result = ctrlr.Create(1) as ViewResult;
            Assert.AreEqual(testnote.customerid, (result.Model as note).customerid);
        }

        [Test]
        public void Test_CreatePost()
        {

        }

        #endregion

        protected NoteController GetController()
        {
            return new NoteController();
        }
    }
}
