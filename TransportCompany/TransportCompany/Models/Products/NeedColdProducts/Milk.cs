namespace TransportCompanyLib.Models.Products.NeedColdProducts
{
    /// <summary>
    /// Implements milk product
    /// </summary>
    public sealed class Milk : NeedColdProductBase
    {
        /// <summary>
        /// Milk constructor
        /// </summary>
        /// <param name="weightPerProduct">Product weight</param>
        /// <param name="volumePerProduct">Product volume</param>
        /// <param name="temperatureLimit">Temperature limit</param>
        public Milk(float weightPerProduct, float volumePerProduct, TemperatureLimit temperatureLimit) : base(weightPerProduct, volumePerProduct, temperatureLimit)
        {
        }
    }
}
