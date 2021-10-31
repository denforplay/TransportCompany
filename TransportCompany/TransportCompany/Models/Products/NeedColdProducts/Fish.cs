namespace TransportCompanyLib.Models.Products.NeedColdProducts
{
    public sealed class Fish : NeedColdProductBase
    {
        public Fish(float weightPerProduct, float volumePerProduct, float lowerTemperature, float highTemperature) : base(weightPerProduct, volumePerProduct, lowerTemperature, highTemperature)
        {
        }
    }
}
