using SuperMarketCheckOut.Common;
using SuperMarketCheckOut.SuperMarketCheckoutRules;
using SuperMarketCheckOut.SuperMarketItemList;
using SuperMarketCheckOut.SuperMarketPricingStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketCheckOut
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create pricing strategies
            PricingStrategy individualPricingStrategyA = new IndividualPricingStrategy(0.5m);
            PricingStrategy individualPricingStrategyB = new IndividualPricingStrategy(0.25m);
            PricingStrategy multiPricingStrategyC = new MultiPricingStrategy(3, 1.3m);

            // Create items
            Item itemA = new Item("A", individualPricingStrategyA);
            Item itemB = new Item("B", individualPricingStrategyB);
            Item itemC = new Item("C", multiPricingStrategyC);

            // Create checkout
            Checkout checkout = new Checkout();

            // Scan items
            checkout.Scan(itemA);
            checkout.Scan(itemB);
            checkout.Scan(itemC);
            checkout.Scan(itemA);
            checkout.Scan(itemA);

            // Calculate total price
            decimal totalPrice = checkout.Total();
            Console.WriteLine($"Total price: {totalPrice:F2}");
            Console.ReadKey();
        }
    }
}
