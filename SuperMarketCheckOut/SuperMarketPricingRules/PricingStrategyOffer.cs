using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketCheckOut.SuperMarketPricingStrategy
{
    /// <summary>
    /// This class is responsible for the define strategy
    /// based on Individual product selection with any special Offer. @Author: Anirban Ghosh
    /// </summary>
    public class PricingStrategyOffer 
    {
        //declared variables
        private readonly string _sku;
        private readonly int _amountYouMustBuy;
        private readonly decimal _discount;

        public PricingStrategyOffer(string sku, int amountYouMustBuy, decimal discount)
        {
            _sku = sku;
            _amountYouMustBuy = amountYouMustBuy;
            _discount = discount;
        }

        internal IEnumerable<Discount> GetDiscounts(List<string> basket)
        {
            var itemsInBasket = basket.Count(s => s == _sku);
            var timesDiscountApplies = (itemsInBasket / _amountYouMustBuy);

            var discounts = new List<Discount>();
            for (var i = 0; i < timesDiscountApplies; i++)
            {
                discounts.Add(new Discount() { Amount = _discount });
            }
            return discounts;
        }
    }
}

