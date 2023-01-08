using SuperMarketCheckOut.Common;

namespace SuperMarketCheckOut.SuperMarketItemList
{
    /// <summary>
    /// This class is responsible for define the Products or Items. @Author: Anirban Ghosh
    /// </summary>
    class Item
    {
        public string Sku { get; }
        public PricingStrategy PricingStrategy { get; }

        public Item(string sku, PricingStrategy pricingStrategy)
        {
            Sku = sku;
            PricingStrategy = pricingStrategy;
        }
    }
}
