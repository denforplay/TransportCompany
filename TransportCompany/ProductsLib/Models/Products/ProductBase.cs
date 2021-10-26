using System;

namespace ProductsLib.Models.Products
{
    public abstract class ProductBase
    {
        private float _weightPerProduct;
        public float WeightPerProduct => _weightPerProduct;

        public ProductBase(float weightPerProduct)
        {
            if (weightPerProduct <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weightPerProduct), "Product weight must be more than zero");
            }

            _weightPerProduct = weightPerProduct;
        }
    }
}