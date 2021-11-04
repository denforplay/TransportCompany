using System;
using TransportCompanyLib.Exceptions;
using TransportCompanyLib.Models.Semitrailers;

namespace TransportCompanyLib.Models.SemitrailerTractors
{
    /// <summary>
    /// Represents semitrailer tractor base
    /// </summary>
    public abstract class SemitrailerTractorBase
    {
        private float _maxSemitrailerWeight;
        private SemitrailerBase _semitrailer;

        /// <summary>
        /// Connected to tractor semitrailer
        /// </summary>
        public SemitrailerBase Semitrailer => _semitrailer;
        
        /// <summary>
        /// Max semitrailer weight that can be connected
        /// </summary>
        public float MaxSemitrailerWeight => _maxSemitrailerWeight;

        /// <summary>
        /// Fuel charges
        /// </summary>
        public abstract float FuelCharges { get; }

        /// <summary>
        /// Semitrailer tractor constructor
        /// </summary>
        /// <param name="maxSemitrailerWeight">Max semitrailer weight that can be connected to tractor</param>
        public SemitrailerTractorBase(float maxSemitrailerWeight)
        {
            if (maxSemitrailerWeight <= 0)
            {
                throw new ArgumentException(nameof(maxSemitrailerWeight));
            }

            _maxSemitrailerWeight = maxSemitrailerWeight;
        }

        /// <summary>
        /// Connect semitrailer to tractor
        /// </summary>
        /// <param name="semitrailer">Semitrailer to be connected</param>
        public void ConnectSemitrailer(SemitrailerBase semitrailer)
        {
            if (semitrailer.CurrentProductsWeight > _maxSemitrailerWeight)
            {
                throw new IncompatibleSemitrailerException(semitrailer.CurrentProductsWeight, _maxSemitrailerWeight);
            }

            _semitrailer = semitrailer;
        }

        /// <summary>
        /// Determines whether two object instances are equal
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>Returns true if object are equals, other returns not</returns>
        public override bool Equals(object obj)
        {
            if (obj is SemitrailerTractorBase otherTractor)
            {
                return otherTractor.MaxSemitrailerWeight == MaxSemitrailerWeight
                    && this.GetType() == otherTractor.GetType()
                    && Semitrailer.Equals(otherTractor.Semitrailer);
            }

            return false;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object</returns>
        public override int GetHashCode()
        {
            int hash = 1222;
            hash += 7 * MaxSemitrailerWeight.GetHashCode();
            hash += 7 * Semitrailer.GetHashCode();
            return hash;
        }

        /// <summary>
        /// Returns a string that represents the current tractor.
        /// </summary>
        /// <returns>A string that represents the current tractor</returns>
        public override string ToString()
        {
            return $"Tractor type: {GetType().Name}\n" +
                $"Connected semitrailer: {Semitrailer}\n" +
                $"Max semitrailer weight: {MaxSemitrailerWeight}";
        }
    }
}
