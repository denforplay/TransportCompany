using System;

namespace TransportCompanyLib.Models.Products.NeedColdProducts
{
    public abstract class NeedColdProductBase : ProductBase
    {
        public float LowerTemperature { get; private set; }
        public float HigherTemperature { get; private set; }

        public NeedColdProductBase(float weightPerProduct, float lowerTemperature, float highTemperature) : base(weightPerProduct)
        {
            if (lowerTemperature > highTemperature)
            {
                throw new ArgumentException("Lower temperature must be lower than higher");
            }

            LowerTemperature = lowerTemperature;
            HigherTemperature = highTemperature;
        }
    }
}
