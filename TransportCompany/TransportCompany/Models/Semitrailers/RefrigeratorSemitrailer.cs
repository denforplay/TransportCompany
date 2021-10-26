using ProductsLib.Models.Products.NeedColdProducts;

namespace TransportCompanyLib.Models.Semitrailers
{
    public class RefrigeratorSemitrailer : SemitrailerBase<NeedColdProductBase>
    {
        private float _lowTemperature;
        private float _highTemperature;

        public RefrigeratorSemitrailer(float maxCarryingWeight, float lowTemperature, float highTemperature) : base(maxCarryingWeight)
        {
            _lowTemperature = lowTemperature;
            _highTemperature = highTemperature;
        }

        public override void Load(NeedColdProductBase product, int count)
        {
            if (product.LowerTemperature >= _lowTemperature && product.HigherTemperature <= _highTemperature)
            {
                if (_semitrailerProducts.TrueForAll(pr => product.LowerTemperature >= pr.LowerTemperature && product.HigherTemperature <= pr.HigherTemperature))
                {
                    base.Load(product, count);
                }
            }
        }
    }
}
