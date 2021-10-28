using System;
using System.Text;
using System.Xml;
using XmlDataWorker.Models;

namespace ProductsLib.Models.Products
{
    /// <summary>
    /// Represents products base
    /// </summary>
    public abstract class ProductBase
    {
        private float _weightPerProduct;
        public float WeightPerProduct => _weightPerProduct;

        public ProductBase() { }

        public ProductBase(float weightPerProduct)
        {
            if (weightPerProduct <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weightPerProduct), "Product weight must be more than zero");
            }

            _weightPerProduct = weightPerProduct;
        }

        public override bool Equals(object obj)
        {
            if (obj is ProductBase product)
            {
                return GetType().Name == product.GetType().Name && _weightPerProduct == product.WeightPerProduct;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 12 * _weightPerProduct.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return $"{GetType().Name} with weight {_weightPerProduct}";
        }
    }
}