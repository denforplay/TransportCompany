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

        /// <summary>
        /// Determines whether two object instances are equal
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>Returns true if object are equals, other returns not</returns>
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

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object</returns>
        public override int GetHashCode()
        {
            int hash = 123;
            hash += WeightPerProduct.GetHashCode();
            hash += VolumePerProduct.GetHashCode();
            hash += LowerTemperature.GetHashCode();
            hash += HigherTemperature.GetHashCode();
            return hash;
        }
    }
}
