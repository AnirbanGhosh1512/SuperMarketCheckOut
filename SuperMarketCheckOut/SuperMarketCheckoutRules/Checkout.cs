using SuperMarketCheckOut.SuperMarketItemList;
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

    class Checkout
    {
        private Item[] items;

        public Checkout()
        {
            items = new Item[0];
        }

        public void Scan(Item item)
        {
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = item;
        }

        public decimal Total()
        {
            decimal totalPrice = 0;
            foreach (Item item in items)
            {
                totalPrice += item.PricingStrategy.CalculatePrice(1);
            }
            return totalPrice;
        }
    }
 }
