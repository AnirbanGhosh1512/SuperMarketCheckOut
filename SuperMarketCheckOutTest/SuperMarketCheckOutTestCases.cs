using SuperMarketCheckOut.SuperMarketCheckoutRules;
using SuperMarketCheckOut.SuperMarketItemList;
using SuperMarketCheckOut.SuperMarketPricingRules;
using System;

namespace SuperMarketCheckOutTest
{
    [TestFixture]
    public class CheckOutTests
    {
        private List<ItemList> _inventory;
        private List<PricingStrategyOffer> _offers;

        [SetUp]
        public void Setup()
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
        [TestCase("A", 50)]
        [TestCase("A,A", 100)]
        [TestCase("A,B", 80)]
        [TestCase("A,A,A", 130)]
        [TestCase("B", 30)]
        [TestCase("B,B", 45)]
        [TestCase("A,B,C,D", 115)]
        [TestCase("A,A,A,A,B,B,B", 255)]
        public void GetTotal_GivenSuccessionOfScannedItems_ReturnsCorrectTotal(string basket, decimal expectedTotal)
        {
            var checkout = new Checkout(_inventory, _offers);

            foreach (var item in basket.Split(','))
            {
                checkout.Scan(item);
            }
            var result = checkout.GetTotal();
            Assert.AreEqual(expectedTotal, result);
        }
    }
}