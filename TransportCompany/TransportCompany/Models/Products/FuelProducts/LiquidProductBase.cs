namespace TransportCompanyLib.Models.Products.FuelProducts
{
    public abstract class LiquidProductBase : ProductBase
    {
        protected LiquidProductBase(float weightPerProduct, float volumePerProduct) : base(weightPerProduct, volumePerProduct)
        {
        }
    }
}
