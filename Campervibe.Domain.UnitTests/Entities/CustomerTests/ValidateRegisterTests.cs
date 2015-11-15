using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Campervibe.Domain.Requests;
using Campervibe.Domain.Entities;

namespace Campervibe.Domain.UnitTests.Entities.CustomerTests
{
    [TestClass]
    public class ValidateRegisterTests
    {
        [TestMethod]
        public void ValidRequestPasses()
        {
            var request = new RegisterCustomerRequestFactory().GetRequest();
            var validationMessages = Customer.ValidateRegister(request);
            Assert.AreEqual(0, validationMessages.Count);
        }

        [TestMethod]
        public void InvalidRequestFails()
        {
            var request = new RegisterCustomerRequest();
            var validationMessages = Customer.ValidateRegister(request);
            Assert.AreEqual(4, validationMessages.Count);
            Assert.IsTrue(validationMessages.Any(x => x.Text.Equals("ApplicationUser not supplied")));
            Assert.IsTrue(validationMessages.Any(x => x.Text.Equals("CustomerRole not supplied")));
            Assert.IsTrue(validationMessages.Any(x => x.Text.Equals("Email not supplied")));
            Assert.IsTrue(validationMessages.Any(x => x.Text.Equals("Post code not supplied")));
        }
    }
}
