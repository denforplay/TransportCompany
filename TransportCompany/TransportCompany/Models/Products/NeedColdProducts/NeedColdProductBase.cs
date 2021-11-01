using System;

namespace TransportCompanyLib.Models.Products.NeedColdProducts
{
    public abstract class NeedColdProductBase : ProductBase
    {
        public float LowerTemperature { get; private set; }
        public float HigherTemperature { get; private set; }

        protected NeedColdProductBase(float weightPerProduct, float volumePerProduct, float lowerTemperature, float highTemperature) : base(weightPerProduct, volumePerProduct)
        {
            if (lowerTemperature > highTemperature)
            {
                throw new ArgumentException("Lower temperature must be lower than higher");
            }

            LowerTemperature = lowerTemperature;
            HigherTemperature = highTemperature;
        }

        public override bool Equals(object obj)
        {
            if (obj is NeedColdProductBase product)
            {
                return GetType().Name == product.GetType().Name
                    && WeightPerProduct == product.WeightPerProduct
                    && VolumePerProduct == product.VolumePerProduct
                    && LowerTemperature == product.LowerTemperature
                    && HigherTemperature == product.HigherTemperature;
            }

            return false;
        }

    }
}
