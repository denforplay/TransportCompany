namespace TransportCompanyLib.Models.Products.NeedColdProducts
{
    /// <summary>
    /// Implements yogurt product
    /// </summary>
    public sealed class Yogurt : NeedColdProductBase
    {
        /// <summary>
        /// Yogurt constructor
        /// </summary>
        /// <param name="weightPerProduct">Product weight</param>
        /// <param name="volumePerProduct">Product volume</param>
        /// <param name="temperatureLimit">Product temperature limit</param>
        public Yogurt(float weightPerProduct, float volumePerProduct, TemperatureLimit temperatureLimit) : base(weightPerProduct, volumePerProduct, temperatureLimit)
        {
        }
    }
}
