using SuperMarketCheckOut.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketCheckOut.SuperMarketPricingStrategy
{
    /// <summary>
    /// This class is responsible for the define strategy
    /// based on the product selected by more than 1 times. @Author: Anirban Ghosh
    /// </summary>
    class MultiPricingStrategy : PricingStrategy
    {
        //declared variables
        private readonly int quantity;
        private readonly decimal price;

        public MultiPricingStrategy(int quantity, decimal price)
        {
            this.quantity = quantity;
            this.price = price;
        }

        public override decimal CalculatePrice(int quantity)
        {
            int numSets = quantity / this.quantity;
            int remainder = quantity % this.quantity;
            return numSets * price + remainder * price / this.quantity;
        }
    }
}
