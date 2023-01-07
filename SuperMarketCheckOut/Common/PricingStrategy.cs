namespace SuperMarketCheckOut.Common
{
    /// <summary>
    /// This class is responsible for the define strategy
    /// based on strategic design pattern. @Author: Anirban Ghosh
    /// </summary>
    abstract class PricingStrategy
    {
        //declared methods.
        public abstract decimal CalculatePrice(int quantity);
    }
}
