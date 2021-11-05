using System;

namespace TransportCompanyLib.Models.Products.NeedColdProducts
{
    /// <summary>
    /// Implements products that need cold
    /// </summary>
    public abstract class NeedColdProductBase : ProductBase
    {
        /// <summary>
        /// Product temperature limits
        /// </summary>
        public TemperatureLimit TemperatureLimit { get; private set; }

        /// <summary>
        /// Need cold producct base constructor
        /// </summary>
        /// <param name="weightPerProduct">Product weight</param>
        /// <param name="volumePerProduct">Product volume</param>
        /// <param name="temperatureLimit">Temperature limit</param>
        protected NeedColdProductBase(float weightPerProduct, float volumePerProduct, TemperatureLimit temperatureLimit) : base(weightPerProduct, volumePerProduct)
        {
            TemperatureLimit = temperatureLimit;
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
                    && TemperatureLimit.CompareTo(product.TemperatureLimit) == 0;
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
            hash += TemperatureLimit.GetHashCode();
            return hash;
        }
    }
}
