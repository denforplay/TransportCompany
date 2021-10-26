namespace ProductsLib.Models.Products.NeedColdProducts
{
    public sealed class Fish : NeedColdProductBase
    {
        public Fish(float weightPerProduct, int lowerTemperature, int highTemperature) : base(weightPerProduct, lowerTemperature, highTemperature)
        {
        }
    }
}
