using Microsoft.VisualStudio.TestTools.UnitTesting;
using Executable.UnitTest;
using System;
using System.Collections.Generic;
using System.Text;
using Executable.LogicLayer.BusinessObject;
using System.Linq;

namespace Executable.UnitTest.Tests
{
    [TestClass()]
    public class PromotionTest
    {
        [TestMethod()]
        public void CreateOrder1()
        {
            OrderBase order = PromotionTests.CreateOrder1();


            Assert.AreEqual(order.Products.ToList().Sum(p => p.DiscountedPrice), 100);
            //Assert.Fail();
        }

        [TestMethod()]
        public void CreateOrder2()
        {
            OrderBase order = PromotionTests.CreateOrder2();


            Assert.AreEqual(order.Products.ToList().Sum(p => p.DiscountedPrice), 370);
            //Assert.Fail();
        }

        [TestMethod()]
        public void CreateOrder3()
        {
            OrderBase order = PromotionTests.CreateOrder3();


            Assert.AreEqual(order.Products.ToList().Sum(p => p.DiscountedPrice), 280);
           // Assert.Fail();
        }
    }



    public static class PromotionTests
    { 
        public static OrderBase CreateOrder1()
        {
            OrderBase order = new MockOrder();
            //MockProduct prodA = new MockProduct("Product1", 50, "A");
            // add items to the cart
            MockProduct prodA = new MockProduct("Product1", 50, "A");
            MockProduct prodB = new MockProduct("Product2", 30, "B");
            MockProduct prodC = new MockProduct("Product3", 20, "C");
            // MockProduct prodD = new MockProduct("Product4", 15, "D");

            order.AddProduct(prodA);
            order.AddProduct(prodB);
            order.AddProduct(prodC);
            //order.AddProduct(new MockProduct("Product1", 50, "A"));
            //order.AddProduct(new MockProduct("Product1", 50, "A"));

            applyAllDiscounts(order);


            return order;
        }


        public static OrderBase CreateOrder2()
        {
            OrderBase order = new MockOrder();
            //MockProduct prodA = new MockProduct("Product1", 50, "A");
            // add items to the cart

            MockProduct prodB = new MockProduct("Product2", 30, "B");
            MockProduct prodC = new MockProduct("Product3", 20, "C");
            // MockProduct prodD = new MockProduct("Product4", 15, "D");

            order.AddProduct(new MockProduct("Product1", 50, "A"));
            order.AddProduct(new MockProduct("Product1", 50, "A"));
            order.AddProduct(new MockProduct("Product1", 50, "A"));
            order.AddProduct(new MockProduct("Product1", 50, "A"));
            order.AddProduct(new MockProduct("Product1", 50, "A"));

            order.AddProduct(new MockProduct("Product2", 30, "B"));
            order.AddProduct(new MockProduct("Product2", 30, "B"));
            order.AddProduct(new MockProduct("Product2", 30, "B"));
            order.AddProduct(new MockProduct("Product2", 30, "B"));
            order.AddProduct(new MockProduct("Product2", 30, "B"));

            order.AddProduct(new MockProduct("Product3", 20, "C"));
            //MockProduct prodC = ;

            //order.AddProduct(prodB);
            //order.AddProduct(prodC);
            //order.AddProduct(new MockProduct("Product1", 50, "A"));
            //order.AddProduct(new MockProduct("Product1", 50, "A"));

            applyAllDiscounts(order);


            return order;
        }

        public static OrderBase CreateOrder3()
        {
            OrderBase order = new MockOrder();
            //MockProduct prodA = new MockProduct("Product1", 50, "A");
            // add items to the cart
            // 3 A MockProduct
            order.AddProduct(new MockProduct("Product1", 50, "A"));
            order.AddProduct(new MockProduct("Product1", 50, "A"));
            order.AddProduct(new MockProduct("Product1", 50, "A"));

            // 5 B MockProduct
            order.AddProduct(new MockProduct("Product2", 30, "B"));
            order.AddProduct(new MockProduct("Product2", 30, "B"));
            order.AddProduct(new MockProduct("Product2", 30, "B"));
            order.AddProduct(new MockProduct("Product2", 30, "B"));
            order.AddProduct(new MockProduct("Product2", 30, "B"));

            // 1 C & 1 D
            order.AddProduct(new MockProduct("Product3", 20, "C"));
            order.AddProduct(new MockProduct("Product4", 15, "D"));

            //order.AddProduct(new MockProduct("Product1", 50, "A"));
            //order.AddProduct(new MockProduct("Product1", 50, "A"));


            applyAllDiscounts(order);

            return order;
        }

        private static void applyAllDiscounts(OrderBase order)
        {
            Discount quantiyDisount1 = new QuantityBasedDiscount("Buy 3A for 130", 3, 130, "A");
            Discount quantiyDisount2 = new QuantityBasedDiscount("Buy 2B for 45", 2, 45, "B");
            order.AddDiscount(quantiyDisount1);
            order.AddDiscount(quantiyDisount2);

            Discount combinedDisount = new CombinedProductsDiscount("BUY C AND D FOR 30 ONLY", 30);
            combinedDisount.AddApplicableProducts("C");
            combinedDisount.AddApplicableProducts("D");
            order.AddDiscount(combinedDisount);
        }

    }

    public class MockOrder : OrderBase
    {

    }

    public class MockProduct : ProductBase
    {
        public MockProduct(String name, Decimal price, string sku) : base(name, price, sku)
        {

        }

    }
}
