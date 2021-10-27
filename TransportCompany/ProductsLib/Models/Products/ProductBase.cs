using System;
using System.Text;
using XmlDataWorker.Models;

namespace ProductsLib.Models.Products
{
    /// <summary>
    /// Represents products base
    /// </summary>
    public abstract class ProductBase : IXmlable
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

        public virtual string WriteInXml()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append($"<{GetType().Name}>\n");
            xml.Append($"<{nameof(WeightPerProduct)}>{WeightPerProduct}</{nameof(WeightPerProduct)}>\n");
            xml.Append($"</{GetType().Name}>\n");
            return xml.ToString();
        }
    }
}