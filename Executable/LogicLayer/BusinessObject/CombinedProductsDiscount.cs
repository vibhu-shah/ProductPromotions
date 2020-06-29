using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Executable.LogicLayer.BusinessObject
{
    public class CombinedProductsDiscount : Discount
    {


        
        public virtual decimal CombinedRate { get; set; }
        public CombinedProductsDiscount(string name, decimal promotionalrate)
            : base(name)
        {
            CombinedRate = promotionalrate;
        }

        public override OrderBase ApplyDiscount()
        {
            if (_skuList.Count <= 0)
                return Order;

            decimal discountedprice = (decimal)CombinedRate / (decimal)_skuList.Count;

            //_ProductsApplicable.Co
            //HashSet<string> skuList = new HashSet<string>(_skuList.Select(s => s.SKU));

            //var iterateList = Order.Products.Where(m => skuList.Contains(m.SKU) && !m.PromotionApplied).ToList();

            List<List<ProductBase>> group = new List<List<ProductBase>>();
            int minNumProductsinGroup = 0;

            //Create Group of identical products from applicable SKU's
            foreach (string sku in _skuList)
            {
                var iterateList = Order.Products.Where(m => m.SKU.Equals(sku) && !m.PromotionApplied).ToList();
                if (minNumProductsinGroup == 0)
                    minNumProductsinGroup = iterateList.Count;

                if(iterateList.Count > 0)
                    group.Add(iterateList);
                
                if (iterateList.Count < minNumProductsinGroup)
                    minNumProductsinGroup = iterateList.Count;

            }

            if (group.Count == _skuList.Count)
            {
                for (int i = 0; i < minNumProductsinGroup; i++)
                {

                    foreach (List<ProductBase> pLIst in group)
                    {
                        pLIst[i].DiscountedPrice = discountedprice;
                        pLIst[i].PromotionApplied = true;

                        //var iterateList = Order.Products.Where(m => skuList.Contains(m.SKU) && !m.PromotionApplied).ToList();
                    }
                }
            }

                
            
            //var iterateList = Order.Products.ToList().Where(x => _ProductsApplicable.Contains(x.SKU).ToList());
            return Order;

        }
    }
}
