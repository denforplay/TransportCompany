using TransportCompanyLib.Models.Semitrailers;
using TransportCompanyLib.Models.SemitrailerTractors;

namespace TransportCompanyLib.Models
{
    /// <summary>
    /// Coupling consists of tractor and semitrailer
    /// </summary>
    public sealed class Coupling
    {
        /// <summary>
        /// Tractor
        /// </summary>
        public SemitrailerTractorBase Tractor { get; private set; }

        /// <summary>
        /// Semitrailer
        /// </summary>
        public SemitrailerBase Semitrailer { get; private set; }

        /// <summary>
        /// Coupling constructor
        /// </summary>
        /// <param name="tractor">Tractor for coupling</param>
        /// <param name="semitrailer">Semitrailer for coupling</param>
        public Coupling(SemitrailerTractorBase tractor, SemitrailerBase semitrailer)
        {
            Tractor = tractor;
            Semitrailer = semitrailer;
        }

        public override bool Equals(object obj)
        {
            if (obj is Coupling coupling)
                return Tractor.Equals(coupling.Tractor)
                    && Semitrailer.Equals(coupling.Semitrailer);

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1556;
            hash += 12 * Tractor.GetHashCode();
            hash += 12 * Semitrailer.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return $"Coupling with {Tractor} and {Semitrailer}";
        }
    }
}
