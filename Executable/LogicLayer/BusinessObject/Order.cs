using System;
using System.Collections.Generic;
using System.Text;

namespace Executable.LogicLayer.BusinessObject
{
    public abstract class OrderBase
    {
        private IList<ProductBase> _Products = new List<ProductBase>();
        private IList<Discount> _Discounts = new List<Discount>();

        public void AddDiscount(Discount discount)
        {
            discount.Order = this;
            discount.ApplyDiscount();
            _Discounts.Add(discount);
        }

        public IList<ProductBase> Products
        {
            get
            {
                return _Products;
            }
        }

        public void  AddProduct(ProductBase p)
        {
            _Products.Add(p);
        }

    }

    public class Order : OrderBase
    {
       
    }
}
