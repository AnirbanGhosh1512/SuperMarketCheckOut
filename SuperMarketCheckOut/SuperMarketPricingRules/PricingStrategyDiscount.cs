using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketCheckOut.SuperMarketPricingRules
{
    /// <summary>
    /// This structure is responsible for the define Amount
    /// based on the product selected by more than 1 times with discount. @Author: Anirban Ghosh
    /// </summary>
    public struct Discount
    {
        public decimal Amount { get; set; }
    }
}
