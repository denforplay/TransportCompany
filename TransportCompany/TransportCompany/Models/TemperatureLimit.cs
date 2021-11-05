using System;

namespace TransportCompanyLib.Models
{
    public sealed class TemperatureLimit : IComparable<TemperatureLimit>
    {
        public float LowerTemperature { get; private set; }
        public float HigherTemperature { get; private set; }

        public TemperatureLimit(float lowerTemperature, float highTemperature)
        {
            if (lowerTemperature > highTemperature)
            {
                throw new ArgumentException("Lower temperature must be lower than higher");
            }

            LowerTemperature = lowerTemperature;
            HigherTemperature = highTemperature;
        }

        public bool IsInOtherLimits(TemperatureLimit otherLimit)
        {
            if (otherLimit is null)
                throw new ArgumentNullException(nameof(otherLimit));

            return LowerTemperature >= otherLimit.LowerTemperature && HigherTemperature <= otherLimit.HigherTemperature;
        }

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
