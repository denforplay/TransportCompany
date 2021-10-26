namespace ProductsLib.Models.Products.NeedColdProducts
{
    public sealed class Milk : NeedColdProductBase
    {
        public Milk(float weightPerProduct, int lowerTemperature, int highTemperature) : base(weightPerProduct, lowerTemperature, highTemperature)
        {
        }
    }
}
