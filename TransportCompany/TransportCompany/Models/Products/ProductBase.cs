using System;

namespace TransportCompanyLib.Models.Products
{
    /// <summary>
    /// Represents products base
    /// </summary>
    public abstract class ProductBase
    {
        public float WeightPerProduct { get; private set; }
        public float VolumePerProduct { get; private set; }

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

        public override int GetHashCode()
        {
            int hash = 12 * WeightPerProduct.GetHashCode();
            hash += 12 * VolumePerProduct.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return $"{GetType().Name} with weight {WeightPerProduct}";
        }
    }
}