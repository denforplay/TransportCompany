using System;

namespace TransportCompanyLib.Exceptions
{
    public class IncompatibleSemitrailerException : Exception
    {
        private float _semitrailerCurrentWeight;
        private float _tractorMaxSemitrailerWeight;

        public IncompatibleSemitrailerException(float semitrailerCurrentWeight, float tractorMaxSemitrailerWeight)
        {
            _semitrailerCurrentWeight = semitrailerCurrentWeight;
            _tractorMaxSemitrailerWeight = tractorMaxSemitrailerWeight;
        }

        public override string Message => $"Can't connect semitrailer with carrying weight {_semitrailerCurrentWeight} to tractor with max possible semitrailer weight {_tractorMaxSemitrailerWeight}";
    }
}
