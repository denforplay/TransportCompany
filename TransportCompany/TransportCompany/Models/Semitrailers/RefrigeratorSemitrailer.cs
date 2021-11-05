using System;
using TransportCompanyLib.Extensions;
using TransportCompanyLib.Models.Products;
using TransportCompanyLib.Models.Products.NeedColdProducts;

namespace TransportCompanyLib.Models.Semitrailers
{
    /// <summary>
    /// Implements refrigerator semitrailer
    /// </summary>
    public sealed class RefrigeratorSemitrailer : SemitrailerBase
    {
        /// <summary>
        /// Refrigerator semitrailer constructor
        /// </summary>
        /// <param name="maxCarryingWeight">Max carrying refrigerator semitrailer weight</param>
        /// <param name="maxCarryingVolume">Max carrying semitrailer volume</param>
        /// <param name="temperatureLimit">Semitrailer temperature limit</param>
        public RefrigeratorSemitrailer(float maxCarryingWeight, float maxCarryingVolume, TemperatureLimit temperatureLimit) : base(maxCarryingWeight, maxCarryingVolume)
        {
            TemperatureLimit = temperatureLimit;
        }

        /// <summary>
        /// Low temperature limit
        /// </summary>
        public TemperatureLimit TemperatureLimit { get; private set; }

        public override void Load(ProductBase product, int count)
        {
            if (product is not NeedColdProductBase needColdProduct)
            {
                throw new ArgumentException("In refregerator you can load only products which need cold");
            }

            if (needColdProduct.TemperatureLimit.IsInOtherLimit(TemperatureLimit))
            {
                if (_semitrailerProducts.TrueForAll(pr => (pr is NeedColdProductBase coldPr) && needColdProduct.TemperatureLimit.IsInOtherLimit(coldPr.TemperatureLimit)))
                {
                    base.Load(product, count);
                }
                else
                {
                    throw new ArgumentException("Product unconnactable with other products in refregerator");
                }
            }
            else
            {
                throw new ArgumentException("Product unconnactable with refregerator");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is RefrigeratorSemitrailer semitrailer)
            {
                return semitrailer.MaxCarryingWeight == this.MaxCarryingWeight
                       && semitrailer.SemitrailerProducts.IsEqual(SemitrailerProducts)
                       && semitrailer.TemperatureLimit.CompareTo(TemperatureLimit) == 0;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1292;
            hash += 14 * MaxCarryingWeight.GetHashCode();
            hash += 14 * MaxCarryingVolume.GetHashCode();
            hash += 14 * TemperatureLimit.GetHashCode();
            hash += 14 * CurrentCarryingVolume.GetHashCode();
            hash += 14 * CurrentProductsWeight.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return $"{GetType().Name} with temperatures between {TemperatureLimit}, with loaded {CurrentProductsWeight}/{MaxCarryingWeight} weight and {CurrentCarryingVolume}/{MaxCarryingVolume}";
        }
    }
}
