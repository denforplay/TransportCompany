using ProductsLib.Models.Products.FuelProducts;
using System;
using System.Linq;

namespace TransportCompanyLib.Models.Semitrailers
{
    public sealed class TankSemitrailer : SemitrailerBase<LiquidProductBase>
    {
        public TankSemitrailer(float carryingCapacity) : base(carryingCapacity)
        {
        }

        public override void Load(LiquidProductBase product, int count)
        {
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
