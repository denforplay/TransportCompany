namespace TransportCompanyLib.Models.Products.FuelProducts
{
    /// <summary>
    /// Represents diesel fuel
    /// </summary>
    public sealed class DieselFuel : LiquidProductBase
    {
        /// <summary>
        /// Diesel fuel constructor
        /// </summary>
        /// <param name="weightPerProduct">Weight per product</param>
        /// <param name="volumePerProduct">Volume per product</param>
        public DieselFuel(float weightPerProduct, float volumePerProduct) : base(weightPerProduct, volumePerProduct)
        {
        }
    }
}
