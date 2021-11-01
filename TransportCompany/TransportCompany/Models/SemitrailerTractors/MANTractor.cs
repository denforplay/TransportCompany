namespace TransportCompanyLib.Models.SemitrailerTractors
{
    public sealed class MANTractor : SemitrailerTractorBase
    {
        public MANTractor(float maxSemitrailerWeight) : base(maxSemitrailerWeight)
        {
        }

        public override float FuelCharges => 1.25f * (Semitrailer is null ? 1 : Semitrailer.CurrentProductsWeight);
    }
}
