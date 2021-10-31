using System;
using System.Linq;
using System.Text;
using System.Xml;
using TransportCompanyLib.Models.Semitrailers;

namespace TransportCompanyLib.Models.SemitrailerTractors
{
    public abstract class SemitrailerTractorBase
    {
        private float _maxSemitrailerWeight;
        private SemitrailerBase _semitrailer;
        public SemitrailerBase Semitrailer => _semitrailer;
        public float MaxSemitrailerWeight => _maxSemitrailerWeight;
        public SemitrailerTractorBase(float maxSemitrailerWeight)
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

        public override bool Equals(object obj)
        {
            if (obj is SemitrailerTractorBase otherTractor)
            {
                return otherTractor.MaxSemitrailerWeight == MaxSemitrailerWeight
                    && this.GetType() == otherTractor.GetType();
            }

            return false;
        }
    }
}
