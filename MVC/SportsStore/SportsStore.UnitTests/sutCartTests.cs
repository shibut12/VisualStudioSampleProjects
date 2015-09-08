using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Controllers;
using System.Web.Mvc;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class sutCartTests
    {

        [TestMethod]
        public void Can_Add_To_Cart()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name="P1", Category = "Apples" }
            }.AsQueryable());

            //Arrange
            Cart cart = new Cart();
            CartController target = new CartController(mock.Object);

            //Act
            target.AddToCart(cart, 1, null);

            //Assert
            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.ToArray()[0].Product.ProductID, 1);
        }

        [TestMethod]
        public void Adding_Product_To_Cart_Goes_To_Cart_Screen()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID=1, Name="P1", Category="Apples" }
            }.AsQueryable());

            //Arrange
            Cart cart = new Cart();
            CartController target = new CartController(mock.Object);

            //Act
            RedirectToRouteResult result = target.AddToCart(cart, 2, "myUrl");

            //Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");

        }

        [TestMethod]
        public void Can_View_Cart_Contents()
        {
            //Arrange
            Cart cart = new Cart();
            CartController target = new CartController(null);

            //Act
            CartIndexViewModel result = (CartIndexViewModel)target.Index(cart, "myUrl").ViewData.Model;

            //Assert
            Assert.AreSame(result.Cart, cart);
            Assert.AreEqual(result.ReturnUrl, "myUrl");
        }

        [TestMethod]
        public void Can_Add_New_Lines()
        {
            //Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1"};
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            Cart target = new Cart();

            //Act
            target.AddItem(p1,1);
            target.AddItem(p2,1);
            CartLine[] results = target.Lines.ToArray();

            //Asssert
            Assert.AreEqual(results.Length,2,"Length test");
            Assert.AreEqual(results[0].Product, p1,"P1 product test");
            Assert.AreEqual(results[1].Product, p2, "P2 product test");
        }

        [TestMethod]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            //Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            Cart target = new Cart();

            //Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 10);
            CartLine[] results = target.Lines.OrderBy(c => c.Product.ProductID).ToArray();

            //Asssert
            Assert.AreEqual(results.Length, 2, "Length test");
            Assert.AreEqual(results[0].Quantity, 11, "P1 product quanityt 10 +1 ");
            Assert.AreEqual(results[1].Quantity, 1, "P2 product quantity 1");
        }

        [TestMethod]
        public void Can_Removeg_Line()
        {
            //Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };

            Cart target = new Cart();

            //Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);

            target.RemoveLine(p2);

            //Asssert
            Assert.AreEqual(target.Lines.Where(c=>c.Product == p2).Count(), 0, "P2 should have removed");
            Assert.AreEqual(target.Lines.Count(), 2, "remaining lines ");
        }

        [TestMethod]
        public void Calculate_Cart_Total()
        {
            //Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M};
            Product p2 = new Product { ProductID = 2, Name = "P2" , Price = 50M};

            Cart target = new Cart();

            //Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 3);
            decimal result = target.ComputeTotalValue();

            //Asssert
            Assert.AreEqual(result, 450M);
        }

        [TestMethod]
        public void Can_Clear_Contents()
        {
            //Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            Cart target = new Cart();

            //Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.Clear();

            //Asssert
            Assert.AreEqual(target.Lines.Count(),0);
        }

    }


}
