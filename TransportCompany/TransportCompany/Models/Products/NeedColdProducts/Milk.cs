namespace TransportCompanyLib.Models.Products.NeedColdProducts
{
    public sealed class Milk : NeedColdProductBase
    {
        public Milk(float weightPerProduct, float volumePerProduct, float lowerTemperature, float highTemperature) : base(weightPerProduct, volumePerProduct, lowerTemperature, highTemperature)
        {
        }
    }
}
