using System;

namespace TransportCompanyLib.Models
{
    /// <summary>
    /// Represents temperatures limits
    /// </summary>
    public sealed class TemperatureLimit : IComparable<TemperatureLimit>
    {
        /// <summary>
        /// Lower temperature limit
        /// </summary>
        public float LowerTemperature { get; private set; }

        /// <summary>
        /// High temperature limit
        /// </summary>
        public float HigherTemperature { get; private set; }

        /// <summary>
        /// Temperature limit constructor
        /// </summary>
        /// <param name="lowerTemperature">Lower temperature limit</param>
        /// <param name="highTemperature">Higher temperature limit</param>
        public TemperatureLimit(float lowerTemperature, float highTemperature)
        {
            if (lowerTemperature > highTemperature)
            {
                throw new ArgumentException("Lower temperature must be lower than higher");
            }

            LowerTemperature = lowerTemperature;
            HigherTemperature = highTemperature;
        }

        /// <summary>
        /// Method checks if this limit lies in range of other temperature limi
        /// </summary>
        /// <param name="otherLimit">Other temperature limit</param>
        /// <returns>Returns true if this limit lies in other temperature limit, other returns false</returns>
        public bool IsInOtherLimit(TemperatureLimit otherLimit)
        {
            if (otherLimit is null)
                throw new ArgumentNullException(nameof(otherLimit));

            return LowerTemperature >= otherLimit.LowerTemperature && HigherTemperature <= otherLimit.HigherTemperature;
        }

        /// <summary>
        /// Compare this temperature limit with other temperature limit
        /// </summary>
        /// <param name="other">Other temperature limit</param>
        /// <returns>
        /// Return zero if limits are equals. 
        /// Return minus one if current temperature limit is lower than other temperature limit. 
        /// Return one if current temperature limit is higher than other temperature limit
        /// </returns>
        public int CompareTo(TemperatureLimit other)
        {
            if (LowerTemperature == other.LowerTemperature && HigherTemperature == other.HigherTemperature)
                return 0;

            if (LowerTemperature <= other.LowerTemperature && HigherTemperature <= other.HigherTemperature)
                return -1;

            return 1;
        }

        public override string ToString()
        {
            return $"from {LowerTemperature} to {HigherTemperature} celcium degrees";
        }
    }
}
