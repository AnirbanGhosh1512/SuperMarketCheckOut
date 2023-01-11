

namespace SuperMarketCheckOut.SuperMarketItemList
{
    /// <summary>
    /// This class is responsible for define the Products or Items and The Price of the Items. @Author: Anirban Ghosh
    /// </summary>
    public class ItemList
    {
        //Defined variables for ItemList.
        public string Sku { get; set; }
        public decimal Price { get; set; }
        

        //Constructor to set SKU and Price
        public ItemList(string sku, decimal price)
        {
            Sku = sku;
            Price = price;
        }
    }
}
