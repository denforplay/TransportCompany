namespace TransportCompanyLib.Models.Products.HouseholdGoods.HouseholdChemicals
{
    /// <summary>
    /// Class represents washing powder product
    /// </summary>
    public sealed class WashingPowder : HouseholdProductBase
    {
        /// <summary>
        /// Washing powder constructor
        /// </summary>
        /// <param name="weightPerProduct">Washing powder weight</param>
        /// <param name="volumePerProduct">Washing powder volume</param>
        public WashingPowder(float weightPerProduct, float volumePerProduct) : base(weightPerProduct, volumePerProduct)
        {
        }
    }
}
