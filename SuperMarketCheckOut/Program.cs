using SuperMarketCheckOut.SuperMarketCheckoutRules;
using SuperMarketCheckOut.SuperMarketItemList;
using SuperMarketCheckOut.SuperMarketPricingRules;
using System;
using System.Collections.Generic;

namespace SuperMarketCheckOut
{
    // <summary>
    /// This class is main class responsible to run the program after checkout
    /// into the supermarket. @Author: Anirban Ghosh
    /// </summary>
    class Program
    {
        private static List<ItemList> _inventory;
        private static List<PricingStrategyOffer> _offers;
        private static String _basket;
        private static decimal _expectedTotal;
        static void Main(string[] args)
        {
            //Call Setup for Item and Price for the customers. @Anirban 11.01.2023
            SetUp();
            //Call ReturnTotal amount to the customer for billing. @Anirban 11.01.2023
            _basket= "A,B,B,C,D";
            _expectedTotal= 0; //As we expect some return for the billing, intially it defined as 0 or no value
            try
            {
                _expectedTotal = GetTotal_GivenSuccessionOfScannedItems_ReturnsCorrectTotal(_basket, _expectedTotal);
                Console.WriteLine("(C) BillAmount: . . . . . . . . {0:C}", _expectedTotal);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void SetUp()
        {
            _inventory = new List<ItemList>
            {
                new ItemList("A", 50M),
                new ItemList("B", 30M),
                new ItemList("C", 20M),
                new ItemList("D", 15M)
            };

            _offers = new List<PricingStrategyOffer>()
            {
                new PricingStrategyOffer("A", 3, -20),
                new PricingStrategyOffer("B", 2, -15)
            };
        }

        public static decimal GetTotal_GivenSuccessionOfScannedItems_ReturnsCorrectTotal(string basket, decimal expectedTotal)
        {
            var checkout = new Checkout(_inventory, _offers);

            foreach (var item in basket.Split(','))
            {
                checkout.Scan(item);
            }
            expectedTotal = checkout.GetTotal();
            return expectedTotal;
        }

    }
}
