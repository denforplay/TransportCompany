namespace TransportCompanyLib.Models.Products.HouseholdGoods
{
    /// <summary>
    /// Represents base household product
    /// </summary>
    public class HouseholdProductBase : ProductBase
    {
        /// <summary>
        /// Household product base constructor
        /// </summary>
        /// <param name="weightPerProduct">Product weight</param>
        /// <param name="volumePerProduct">Product volume</param>
        public HouseholdProductBase(float weightPerProduct, float volumePerProduct) : base(weightPerProduct, volumePerProduct)
        {
        }
    }
}
