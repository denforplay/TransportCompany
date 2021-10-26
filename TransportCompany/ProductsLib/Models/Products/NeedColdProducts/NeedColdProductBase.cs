using System;

namespace ProductsLib.Models.Products.NeedColdProducts
{
    public abstract class NeedColdProductBase : ProductBase
    {
        public int LowerTemperature { get; private set; }
        public int HigherTemperature { get; private set; }

        public NeedColdProductBase(float weightPerProduct, int lowerTemperature, int highTemperature) : base(weightPerProduct)
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
