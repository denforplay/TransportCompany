using System.Diagnostics.Contracts;
using System.Linq;
using TransportCompanyLib.Exceptions;
using TransportCompanyLib.Models.Products;
using TransportCompanyLib.Models.Products.FuelProducts;
using TransportCompanyLib.Models.Products.HouseholdGoods;

namespace TransportCompanyLib.Models.Semitrailers
{
    public class TiltSemitrailer : SemitrailerBase
    {
        public TiltSemitrailer(float maxCarryingWeight, float maxCarryingVolume) : base(maxCarryingWeight, maxCarryingVolume)
        {
        }

        public override void Load(ProductBase product, int count)
        {
            if (product is not HouseholdProductBase)
            {
                throw new IncompatibleProductException(product.GetType().Name, typeof(HouseholdProductBase).Name);
            }

            if (_semitrailerProducts.Count == 0 ||
(_semitrailerProducts.Count != 0 && _semitrailerProducts.First().GetType() == product.GetType()))
            {
                base.Load(product, count);
            }
            else
            {
                throw new IncompatibleProductException(product.GetType().Name, _semitrailerProducts[0].GetType().Name);
            }
        }
    }
}
