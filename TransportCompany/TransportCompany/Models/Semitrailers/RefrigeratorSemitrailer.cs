using System;
using System.Linq;
using TransportCompanyLib.Models.Products;
using TransportCompanyLib.Models.Products.NeedColdProducts;

namespace TransportCompanyLib.Models.Semitrailers
{
    public class RefrigeratorSemitrailer : SemitrailerBase
    {
        public RefrigeratorSemitrailer(float maxCarryingWeight, float maxCarryingVolume, float lowerTemperature, float highTemperature) : base(maxCarryingWeight, maxCarryingVolume)
        {
            if (highTemperature <= lowerTemperature)
            {
                throw new ArgumentException(nameof(highTemperature), "higher temperature must be higher than lower temperature");
            }

            LowerTemperature = lowerTemperature;
            HighTemperature = highTemperature;
        }

        public float LowerTemperature { get; private set; }
        public float HighTemperature { get; private set; }

        public override void Load(ProductBase product, int count)
        {
            if (product is not NeedColdProductBase needColdProduct)
            {
                throw new ArgumentException("In refregerator you can load only products which need cold");
            }

            if (needColdProduct.LowerTemperature >= LowerTemperature && needColdProduct.HigherTemperature <= HighTemperature)
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

        public override bool Equals(object obj)
        {
            if (obj is RefrigeratorSemitrailer semitrailer)
            {
                return semitrailer.MaxCarryingWeight == this.MaxCarryingWeight
                       && semitrailer.SemitrailerProducts.Except(SemitrailerProducts).Count() == 0
                       && semitrailer.LowerTemperature == this.LowerTemperature
                       && semitrailer.HighTemperature == this.HighTemperature;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1292;
            hash += 14 * MaxCarryingWeight.GetHashCode();
            hash += 14 * MaxCarryingVolume.GetHashCode();
            hash += 14 * HighTemperature.GetHashCode();
            hash += 14 * LowerTemperature.GetHashCode();
            hash += 14 * CurrentCarryingVolume.GetHashCode();
            hash += 14 * CurrentProductsWeight.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return $"{GetType().Name} with temperatures between {LowerTemperature} and {HighTemperature}, with loaded {CurrentProductsWeight}/{MaxCarryingWeight} weight and {CurrentCarryingVolume}/{MaxCarryingVolume}";
        }
    }
}
