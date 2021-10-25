using System;
using TransportCompanyLib.Models.Semitrailers;

namespace TransportCompanyLib.Models.SemitrailerTractors
{
    public abstract class SemitrailerTractorBase
    {
        private int _maxSemitrailerWeight;
        private SemitrailerBase _semitrailer;

        public SemitrailerTractorBase(SemitrailerBase semitrailer, int maxSemitrailerWeight)
        {
            if (semitrailer is null)
            {
                throw new ArgumentNullException(nameof(semitrailer));
            }

            if (maxSemitrailerWeight <= 0 || maxSemitrailerWeight >= semitrailer.CarryingCapacity)
            {
                throw new ArgumentException(nameof(maxSemitrailerWeight));
            }

            _maxSemitrailerWeight = maxSemitrailerWeight;
            _semitrailer = semitrailer;
        }
    }
}
