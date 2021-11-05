namespace TransportCompanyLib.Models.Products.NeedColdProducts
{
    /// <summary>
    /// Implements fish product
    /// </summary>
    public sealed class Fish : NeedColdProductBase
    {
        /// <summary>
        /// Fish constructor
        /// </summary>
        /// <param name="weightPerProduct">Product weight</param>
        /// <param name="volumePerProduct">Product volume</param>
        /// <param name="temperatureLimit">Temperature limit</param>
        public Fish(float weightPerProduct, float volumePerProduct, TemperatureLimit temperatureLimit) : base(weightPerProduct, volumePerProduct, temperatureLimit)
        {
        }
    }
}
