using System;
using TransportCompanyLib.Models;
using Xunit;

namespace TransportCompanyTests.ModelTests
{
    public class TemperatureLimitTests
    {
        [Theory]
        [InlineData(10, 5)]
        [InlineData(0, -1)]
        public void LowerLimitHigherThanHighLimit_ThrowsArgumentException(float lowValue, float highValue)
        {
            Assert.Throws<ArgumentException>(() => new TemperatureLimit(lowValue, highValue));
        }

        [Fact]
        public void IsInOtherLimit_NullTemperatureLimit_ThrowsArgumentNullException()
        {
            TemperatureLimit temperatureLimit = new TemperatureLimit(5, 10);
            Assert.Throws<ArgumentNullException>(() => temperatureLimit.IsInOtherLimit(null));
        }
    }
}
