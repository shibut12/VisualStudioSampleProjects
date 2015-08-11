using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eStore;
using EmailManager;
using Moq;

namespace emanager.Tests
{
    [TestClass]
    public class suteManager
    {
        [TestMethod]
        public void TestNotification()
        {
            Customer testCustomer = new Customer {
                ID=1,
                name="Shibu Thannikkunnath",
                department="CSE",
                emailAddress ="shibu@hotmail.co.in"
            };
            eStore.eStore estoreObj = new eStore.eStore(new EmailLibrary());
            bool isAddedUser = estoreObj.addUser(testCustomer);
            Assert.AreEqual(isAddedUser, true);
        }

        [TestMethod]
        public void TestFailedNotification()
        {
            Mock<IEmailLibrary> mockEmailLib = new Mock<IEmailLibrary>();

            mockEmailLib.Setup(x => x.sendEmail("from email","to email", "test sub","test body")).Returns(false);
            Customer testCustomer = new Customer
            {
                ID = 1,
                name = "Shibu Thannikkunnath",
                department = "CSE",
                emailAddress = "shibu@hotmail.co.in"
            };
            eStore.eStore estoreObj = new eStore.eStore(mockEmailLib.Object);
            bool isAddedUser = estoreObj.addUser(testCustomer);
            Assert.AreEqual(isAddedUser, false);
        }

        [TestMethod]
        public void addUserTestAnyValue()
        {
            Mock<IEmailLibrary> mockEmailLib = new Mock<IEmailLibrary>();

            mockEmailLib.Setup(x => x.sendEmail("from email", "to email", "test sub", "test body")).Returns(false);
            Mock<eStore.eStore> mockStore = new Mock<eStore.eStore>();
            mockStore.Setup(x => x.addUser(It.IsAny<Customer>())).Returns(true);
            eStore.eStore estoreObj = new eStore.eStore(mockEmailLib.Object);

            bool isAddedUser = estoreObj.addUser(It.IsAny<Customer>());

            Assert.AreEqual(isAddedUser, false);

            //mockStore.VerifyAll();
        }
    }
}
