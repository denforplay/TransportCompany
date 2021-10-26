using ProductsLib.Models.Products;
using ProductsLib.Models.Products.FuelProducts;
using System;
using System.Linq;

namespace TransportCompanyLib.Models.Semitrailers
{
    public sealed class TankSemitrailer : SemitrailerBase
    {
        public TankSemitrailer(float carryingCapacity) : base(carryingCapacity)
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
