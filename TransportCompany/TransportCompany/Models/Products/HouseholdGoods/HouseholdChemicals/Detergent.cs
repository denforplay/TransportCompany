namespace TransportCompanyLib.Models.Products.HouseholdGoods.HouseholdChemicals
{
    /// <summary>
    /// Class represents detergent
    /// </summary>
    public sealed class Detergent : HouseholdProductBase
    {
        /// <summary>
        /// Detergent constructor
        /// </summary>
        /// <param name="weightPerProduct">Detergent weight</param>
        /// <param name="volumePerProduct">Detergent volume</param>
        public Detergent(float weightPerProduct, float volumePerProduct) : base(weightPerProduct, volumePerProduct)
        {
        }
    }
}
