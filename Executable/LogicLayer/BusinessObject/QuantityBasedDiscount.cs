using Executable.LogicLayer.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Executable.LogicLayer.BusinessObject
{
    // This discount shoulkd be use when you want to give fixed prices for prescribe quantity
    public class QuantityBasedDiscount : Discount
    {

        // If Min quanity condition meets then use fixed price and apply it on all applicable products

        public virtual int Quantity { get; set; }
        public virtual int FlatRate { get; set; }

        public virtual string SKU { get; set; }

        public QuantityBasedDiscount(string name, int quantity, int flatRate, string sku)
            : base(name)
        {
            Quantity = quantity;
            FlatRate = flatRate;
            SKU = sku;
            
            //X = x;
            //  Y = y;
        }

        public override OrderBase ApplyDiscount()
        {
            decimal finalPrice = 0;
            int counter = 0;
            int groupcounter = 0;
            int groupCounts = 0;
            List<ProductBase> applicableProducts = Order.Products.ToList<ProductBase>().FindAll(p => p.SKU.Equals(SKU));
               
                //OrderDetails.Products.Count(p => p.SKU.Equals(SKU));

            if (applicableProducts.Count >= Quantity)
            {
                    groupCounts = applicableProducts.Count / Quantity;

                    finalPrice = (decimal)FlatRate / (decimal)Quantity;

                    foreach (ProductBase P in applicableProducts)
                    {
                        if (groupcounter < groupCounts)
                        {
                            P.DiscountedPrice = finalPrice;
                            counter++;
                        }
                        else
                        {
                            break;
                        }

                             if (counter >= Quantity)
                             {
                                // Increase groupcounter and reset counter
                                counter = 0;
                                groupcounter++;
                             }
                   
                    }
            }
            return Order;
        }

    }
}
