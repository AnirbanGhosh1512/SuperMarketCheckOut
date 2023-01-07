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
    /// based on Individual product selection. @Author: Anirban Ghosh
    /// </summary>
    class IndividualPricingStrategy : PricingStrategy
    {
        //declared variables
        private readonly decimal price;

        public IndividualPricingStrategy(decimal price)
        {
            this.price = price;
        }

        public override decimal CalculatePrice(int quantity)
        {
            return quantity * price;
        }
    }
}
