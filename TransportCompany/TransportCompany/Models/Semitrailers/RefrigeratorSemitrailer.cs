using ProductsLib.Models.Products;
using ProductsLib.Models.Products.NeedColdProducts;
using System;

namespace TransportCompanyLib.Models.Semitrailers
{
    public class RefrigeratorSemitrailer : SemitrailerBase
    {
        private float _lowTemperature;
        private float _highTemperature;

        public RefrigeratorSemitrailer(float maxCarryingWeight, float lowTemperature, float highTemperature) : base(maxCarryingWeight)
        {
            _lowTemperature = lowTemperature;
            _highTemperature = highTemperature;
        }

        public override void Load(ProductBase product, int count)
        {
            if (product is not NeedColdProductBase needColdProduct)
            {
                throw new ArgumentException("In refregerator you can load only products which need cold");
            }

            if (needColdProduct.LowerTemperature >= _lowTemperature && needColdProduct.HigherTemperature <= _highTemperature)
            {
                if (_semitrailerProducts.TrueForAll(pr => (pr is NeedColdProductBase coldPr) && needColdProduct.LowerTemperature >= coldPr.LowerTemperature && needColdProduct.HigherTemperature <= coldPr.HigherTemperature))
                {
                    base.Load(product, count);
                }
                else
                {
                    throw new ArgumentException("Product unconnactable with other products in refregerator");
                }
            }
        }
    }
}
