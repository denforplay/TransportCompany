namespace TransportCompanyLib.Models.SemitrailerTractors
{
    /// <summary>
    /// Man tractor
    /// </summary>
    public sealed class MANTractor : SemitrailerTractorBase
    {
        /// <summary>
        /// Man tractor constructor
        /// </summary>
        /// <param name="maxSemitrailerWeight">Max semitrailer weight that cen be load to tractor</param>
        public MANTractor(float maxSemitrailerWeight) : base(maxSemitrailerWeight)
        {
        }

        public override float FuelCharges => 1.25f * (Semitrailer is null ? 1 : Semitrailer.CurrentProductsWeight);
    }
}
