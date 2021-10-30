namespace TransportCompanyLib.Models.Products.NeedColdProducts
{
    public sealed class Milk : NeedColdProductBase
    {
        public Milk(float weightPerProduct, float lowerTemperature, float highTemperature) : base(weightPerProduct, lowerTemperature, highTemperature)
        {
        }
    }
}
