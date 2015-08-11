using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cutomer;
using myEmailLibrary;
using Moq;

namespace Customers.unitTests
{
    [TestClass]
    public class sutCustomer
    {
        [TestMethod]
        public void addCutomer()
        {
            Customer obj = new Customer(new MyEmail());
            Assert.AreEqual(obj.AddCutomer(), true);
        }

        [TestMethod]
        public void TestAddCutomerWithMoqSuccess()
        {
            //cretae an object
            Mock<IMyEmail> objEmail = new Mock<IMyEmail>();

            //specify which function to bypass
            objEmail.Setup(x => x.sendEmail()).Returns(true);

            Customer cust = new Customer(objEmail.Object);
            bool isInserted = cust.AddCutomer();
            Assert.AreEqual(isInserted, true);

        }

        [TestMethod]
        public void TestAddCutomerWithMoqFail()
        {
            //cretae an object
            Mock<IMyEmail> objEmail = new Mock<IMyEmail>();

            //specify which function to bypass
            objEmail.Setup(x => x.sendEmail()).Returns(false);

            Customer cust = new Customer(objEmail.Object);
            bool isInserted = cust.AddCutomer();
            Assert.AreEqual(isInserted, false);

        }
    }
}
