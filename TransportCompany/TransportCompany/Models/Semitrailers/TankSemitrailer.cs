using System;
using System.Linq;
using TransportCompanyLib.Models.Products;
using TransportCompanyLib.Models.Products.FuelProducts;

namespace TransportCompanyLib.Models.Semitrailers
{
    public sealed class TankSemitrailer : SemitrailerBase
    {
        public TankSemitrailer(float maxCarryingWeight, float maxCarryingVolume) : base(maxCarryingWeight, maxCarryingVolume)
        {
        }

        public override void Load(ProductBase product, int count)
        {
            if (product is not LiquidProductBase) throw new ArgumentException("You can fill tanks only with liquids");

            if (_semitrailerProducts.Count == 0 ||
                (_semitrailerProducts.Count != 0 && _semitrailerProducts.First().GetType() == product.GetType()))
            {
                base.Load(product, count);
            }
            else
            {
                throw new ArgumentException("This fuel uncompatible with fuel in semitrailer", product.GetType().Name);
            }
        }
    }
}
