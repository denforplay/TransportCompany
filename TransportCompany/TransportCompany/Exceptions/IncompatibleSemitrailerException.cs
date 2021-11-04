using System;

namespace TransportCompanyLib.Exceptions
{
    /// <summary>
    /// Class realize exception class, thrown if semitrailer incompatible with tractor
    /// </summary>
    public class IncompatibleSemitrailerException : Exception
    {
        private float _semitrailerCurrentWeight;
        private float _tractorMaxSemitrailerWeight;

        /// <summary>
        /// Incompatible semitrailer exception contructor
        /// </summary>
        /// <param name="semitrailerCurrentWeight">Semitrailer current weight with products</param>
        /// <param name="tractorMaxSemitrailerWeight">Max semitrailer weight that tractor can move</param>
        public IncompatibleSemitrailerException(float semitrailerCurrentWeight, float tractorMaxSemitrailerWeight)
        {
            _semitrailerCurrentWeight = semitrailerCurrentWeight;
            _tractorMaxSemitrailerWeight = tractorMaxSemitrailerWeight;
        }

        /// <summary>
        /// Exception message
        /// </summary>
        public override string Message => $"Can't connect semitrailer with carrying weight {_semitrailerCurrentWeight} to tractor with max possible semitrailer weight {_tractorMaxSemitrailerWeight}";
    }
}
