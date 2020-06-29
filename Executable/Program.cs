using System;
using System.Linq;
using Executable.LogicLayer.BusinessObject;


namespace Executable
{
    class Program
    {


        //Product prodE = new Product("Product5", 50, "A");
        // add items to the cart



        static void Main(string[] args)
        {
            Order order1 = CreateOrder1();
            Console.WriteLine("scenario1 : Order Amount : " + string.Format("{0:0.00}", order1.Products.Sum(p => p.DiscountedPrice)));

            Order order2 = CreateOrder2();
            Console.WriteLine("scenario2 : Order Amount : " + string.Format("{0:0.00}", order2.Products.Sum(p => p.DiscountedPrice)));

            Order order3 = CreateOrder3();
            Console.WriteLine("scenario3 : Order Amount : " + string.Format("{0:0.00}", order3.Products.Sum(p => p.DiscountedPrice)));
            Console.ReadLine();
        }

        private static Order CreateOrder1()
        {
            Order order = new Order();
            //Product prodA = new Product("Product1", 50, "A");
            // add items to the cart
            Product prodA = new Product("Product1", 50, "A");
            Product prodB = new Product("Product2", 30, "B");
            Product prodC = new Product("Product3", 20, "C");
            // Product prodD = new Product("Product4", 15, "D");

            order.AddProduct(prodA);
            order.AddProduct(prodB);
            order.AddProduct(prodC);
            //order.AddProduct(new Product("Product1", 50, "A"));
            //order.AddProduct(new Product("Product1", 50, "A"));

            applyAllDiscounts(order);


            return order;
        }

       
        private static Order CreateOrder2()
        {
            Order order = new Order();
            //Product prodA = new Product("Product1", 50, "A");
            // add items to the cart

            Product prodB = new Product("Product2", 30, "B");
            Product prodC = new Product("Product3", 20, "C");
            // Product prodD = new Product("Product4", 15, "D");

            order.AddProduct(new Product("Product1", 50, "A"));
            order.AddProduct(new Product("Product1", 50, "A"));
            order.AddProduct(new Product("Product1", 50, "A"));
            order.AddProduct(new Product("Product1", 50, "A"));
            order.AddProduct(new Product("Product1", 50, "A"));

            order.AddProduct(new Product("Product2", 30, "B"));
            order.AddProduct(new Product("Product2", 30, "B"));
            order.AddProduct(new Product("Product2", 30, "B"));
            order.AddProduct(new Product("Product2", 30, "B"));
            order.AddProduct(new Product("Product2", 30, "B"));

            order.AddProduct(new Product("Product3", 20, "C"));
            //Product prodC = ;

            //order.AddProduct(prodB);
            //order.AddProduct(prodC);
            //order.AddProduct(new Product("Product1", 50, "A"));
            //order.AddProduct(new Product("Product1", 50, "A"));

            applyAllDiscounts(order);


            return order;
        }

        private static Order CreateOrder3()
        {
            Order order = new Order();
            //Product prodA = new Product("Product1", 50, "A");
            // add items to the cart
            // 3 A Product
            order.AddProduct(new Product("Product1", 50, "A"));
            order.AddProduct(new Product("Product1", 50, "A"));
             order.AddProduct(new Product("Product1", 50, "A"));

            // 5 B Product
            order.AddProduct(new Product("Product2", 30, "B"));
              order.AddProduct(new Product("Product2", 30, "B"));
               order.AddProduct(new Product("Product2", 30, "B"));
                order.AddProduct(new Product("Product2", 30, "B"));
                order.AddProduct(new Product("Product2", 30, "B"));
            
            // 1 C & 1 D
            order.AddProduct(new Product("Product3", 20, "C"));
            order.AddProduct(new Product("Product4", 15, "D"));
          
            //order.AddProduct(new Product("Product1", 50, "A"));
            //order.AddProduct(new Product("Product1", 50, "A"));


            applyAllDiscounts(order);

            return order;
        }

        private static void applyAllDiscounts(Order order)
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
}
