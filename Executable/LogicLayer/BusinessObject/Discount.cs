using System;
using System.Collections.Generic;
using System.Text;

namespace Executable.LogicLayer.BusinessObject
{
    public abstract class Discount
    {
        public Discount(string name)
        {
            Name = name;
        }

        // There can be different ways in which applicable products can be communicated, like List of SKU's
        // Also we have kept in base class so that Promotions can be applied on combination of specific products
        protected List<string> _skuList = new List<String>();

       public abstract OrderBase ApplyDiscount();
       public virtual OrderBase Order { get; set; }
        public virtual string Name { get; private set; }

        public void AddApplicableProducts(string sku)
        {
            _skuList.Add(sku);
        }

        // public abstract Order ApplyDiscount();
    }


}
