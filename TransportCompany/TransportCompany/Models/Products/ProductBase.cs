using System;

namespace TransportCompanyLib.Models.Products
{
    /// <summary>
    /// Represents products base
    /// </summary>
    public abstract class ProductBase
    {
        /// <summary>
        /// Product weight
        /// </summary>
        public float WeightPerProduct { get; private set; }

        /// <summary>
        /// Product volume
        /// </summary>
        public float VolumePerProduct { get; private set; }

        /// <summary>
        /// Product constructor
        /// </summary>
        /// <param name="weightPerProduct">Product weight</param>
        /// <param name="volumePerProduct">Product volume</param>
        public ProductBase(float weightPerProduct, float volumePerProduct)
        {
            if (weightPerProduct <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weightPerProduct), "Product weight must be more than zero");
            }

            if (volumePerProduct <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(volumePerProduct), "Product volume must be more then zero");
            }

            VolumePerProduct = volumePerProduct;
            WeightPerProduct = weightPerProduct;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is ProductBase product)
            {
                return GetType().Name == product.GetType().Name
                    && WeightPerProduct == product.WeightPerProduct
                    && VolumePerProduct == product.VolumePerProduct;
            }

            return false;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object</returns>
        public override int GetHashCode()
        {
            int hash = 12 * WeightPerProduct.GetHashCode();
            hash += 12 * VolumePerProduct.GetHashCode();
            return hash;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{GetType().Name} with weight {WeightPerProduct}";
        }
    }
}