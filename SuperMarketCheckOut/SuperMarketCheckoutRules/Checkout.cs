using SuperMarketCheckOut.SuperMarketItemList;
using SuperMarketCheckOut.SuperMarketPricingStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketCheckOut.SuperMarketCheckoutRules
{
    /// <summary>
    /// This class is responsible for the define the rules of the check
    /// out of the supermarket system. @Author: Anirban Ghosh
    /// </summary>

    public class Checkout
    {
        private readonly List<string> _basket;
        private readonly IList<ItemList> _inventory;
        private readonly IList<PricingStrategyOffer> _offers;

        public Checkout(IList<ItemList> inventory, IList<PricingStrategyOffer> offers)
        {
            _basket = new List<string>();
            _inventory = inventory;
            _offers = offers;
        }

        public void Scan(string product)
        {
            _basket.Add(product);
        }

        public decimal GetTotal()
        {
            var preDiscountTotal = GetPreDiscountTotal();
            var discounts = ApplyOfferDiscounts();
            return preDiscountTotal + discounts;
        }

        private decimal GetPreDiscountTotal()
        {
            return _basket.Sum(item => _inventory.First(i => i.Sku == item).Price);
        }

        private decimal ApplyOfferDiscounts()
        {
            return _offers.Sum(offer => offer.GetDiscounts(_basket).Select(d => d.Amount).Sum());
        }
    }
 }
