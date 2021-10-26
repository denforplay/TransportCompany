using ProductsLib.Models.Products;
using System;
using TransportCompanyLib.Models.Semitrailers;

namespace TransportCompanyLib.Models.SemitrailerTractors
{
    public abstract class SemitrailerTractorBase
    {
        private int _maxSemitrailerWeight;
        private SemitrailerBase _semitrailer;
        public SemitrailerBase Semitrailer => _semitrailer;

        public SemitrailerTractorBase(int maxSemitrailerWeight)
        {
            if (maxSemitrailerWeight <= 0)
            {
                throw new ArgumentException(nameof(maxSemitrailerWeight));
            }

            _maxSemitrailerWeight = maxSemitrailerWeight;
        }

        public void ConnectSemitrailer(SemitrailerBase semitrailer)
        {
            if (semitrailer.MaxCarryingWeight > _maxSemitrailerWeight)
            {
                throw new ArgumentException("Semitrailer can care more than semitrailer tractor can load", nameof(semitrailer));
            }

            _semitrailer = semitrailer;
        }
    }
}
