namespace TransportCompanyLib.Models.Products.FuelProducts
{
    /// <summary>
    /// Represents octane petrol 95
    /// </summary>
    public sealed class OctanePetrol_95 : LiquidProductBase
    {
        /// <summary>
        /// Octane petrol 95 constructor
        /// </summary>
        /// <param name="weightPerProduct">Weight per product</param>
        /// <param name="volumePerProduct">Volume per product</param>
        public OctanePetrol_95(float weightPerProduct, float volumePerProduct) : base(weightPerProduct, volumePerProduct)
        {
        }
    }
}
