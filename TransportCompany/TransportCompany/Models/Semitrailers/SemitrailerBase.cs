using ProductsLib.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XmlDataWorker.Models;

namespace TransportCompanyLib.Models.Semitrailers
{
    public abstract class SemitrailerBase : IXmlable
    {
        protected List<ProductBase> _semitrailerProducts;
        private float _maxCarryingWeight;
        public float CurrentProductsWeight => _semitrailerProducts.Sum(x => x.WeightPerProduct);
        public float MaxCarryingWeight => _maxCarryingWeight;
        public List<ProductBase> SemitrailerProducts => _semitrailerProducts;

        public SemitrailerBase(float maxCarryingWeight)
        {
            if (maxCarryingWeight <= 0)
            {
                throw new ArgumentException(nameof(maxCarryingWeight));
            }

            _semitrailerProducts = new List<ProductBase>();
            _maxCarryingWeight = maxCarryingWeight;
        }

        /// <summary>
        /// Method to load product in semitrailer
        /// </summary>
        public virtual void Load(ProductBase product, int count)
        {
            while (count-- > 0)
            {
                if (CurrentProductsWeight + product.WeightPerProduct <= MaxCarryingWeight)
                    _semitrailerProducts.Add(product);
                else
                    break;
            }
        }

        public void Unload(ProductBase product, int productCount)
        {
            while(productCount-- != 0 && _semitrailerProducts.Count != 0)
            {
                var findedProduct = _semitrailerProducts.Last(pr => pr.Equals(product));
                if (findedProduct is null) break;
                _semitrailerProducts.Remove(findedProduct);
            }
        }

        public string WriteInXml()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append($"<{GetType().Name}>\n");
            xml.Append($"<{nameof(SemitrailerProducts)}>");
            foreach (var product in SemitrailerProducts)
                xml.Append(product.WriteInXml());
            xml.Append($"</{nameof(SemitrailerProducts)}>");
            xml.Append($"<{nameof(MaxCarryingWeight)}>{MaxCarryingWeight}</{nameof(MaxCarryingWeight)}>\n");
            xml.Append($"<{nameof(CurrentProductsWeight)}>{CurrentProductsWeight}</{nameof(CurrentProductsWeight)}>\n");
            xml.Append($"</{GetType().Name}>\n");
            return xml.ToString();
        }
    }
}
