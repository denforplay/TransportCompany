using System;

namespace TransportCompanyLib.Models.Products
{
    /// <summary>
    /// Represents products base
    /// </summary>
    public abstract class ProductBase
    {
        public float WeightPerProduct { get; private set; }

        public ProductBase() { }

        public ProductBase(float weightPerProduct)
        {
            if (weightPerProduct <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weightPerProduct), "Product weight must be more than zero");
            }

            WeightPerProduct = weightPerProduct;
        }

        public override bool Equals(object obj)
        {
            if (obj is ProductBase product)
            {
                return GetType().Name == product.GetType().Name && WeightPerProduct == product.WeightPerProduct;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 12 * WeightPerProduct.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return $"{GetType().Name} with weight {WeightPerProduct}";
        }
    }
}