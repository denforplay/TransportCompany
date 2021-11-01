namespace TransportCompanyLib.Models.Products.FuelProducts
{
    /// <summary>
    /// Represents liquid product base
    /// </summary>
    public abstract class LiquidProductBase : ProductBase
    {
        /// <summary>
        /// Luquid product base constructor
        /// </summary>
        /// <param name="weightPerProduct">Weight per product</param>
        /// <param name="volumePerProduct">Volume per product</param>
        protected LiquidProductBase(float weightPerProduct, float volumePerProduct) : base(weightPerProduct, volumePerProduct)
        {
        }
    }
}
