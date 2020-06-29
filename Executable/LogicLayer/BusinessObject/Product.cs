using System;
using System.Collections.Generic;
using System.Text;

namespace Executable.LogicLayer.BusinessObject
{
    public abstract class ProductBase
    {

        public ProductBase(string name, decimal price, string sku)
        {
            Name = name;
            SellingPrice = price;
            SKU = sku;
            DiscountedPrice = price;
        }

        public string Name {get;set;}

        public string SKU { get; set; }

        public decimal SellingPrice { get; set; }

        public bool PromotionApplied { get; set; }

        public decimal DiscountedPrice { get; set; }
    }

    public class Product : ProductBase
    {

        public Product(String name, Decimal price, string sku) : base(name, price, sku)
        {
        }
        // Add specific product or product type here like medicine, food, staples etc

    }
}
