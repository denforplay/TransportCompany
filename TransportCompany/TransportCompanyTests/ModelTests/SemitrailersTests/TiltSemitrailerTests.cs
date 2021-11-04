using System;
using TransportCompanyLib.Exceptions;
using TransportCompanyLib.Models.Products.FuelProducts;
using TransportCompanyLib.Models.Products.HouseholdGoods.HouseholdChemicals;
using TransportCompanyLib.Models.Semitrailers;
using Xunit;

namespace TransportCompanyTests.ModelTests.SemitrailersTests
{
    public class TiltSemitrailerTests
    {
        [Theory]
        [InlineData(-10, 10)]
        [InlineData(10, -10)]
        [InlineData(0, 10)]
        [InlineData(10, 0)]
        public void CreateTiltSemitrailer_MaxWeightLessThanZero_ThrowsArgumentException(float weight, float volume)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TiltSemitrailer(weight, volume));
        }

        [Fact]
        public void LoadTiltSemitrailer_LiquidProduct_ThrowIncompatibleProductException()
        {
            TiltSemitrailer tiltSemitrailer = new TiltSemitrailer(100, 100);
            Assert.Throws<IncompatibleProductException>(() => tiltSemitrailer.Load(new OctanePetrol_95(5, 0.5f), 1));
        }

        [Fact]
        public void LoadTiltSemitrailer_AddIncompatibleProduct_ThrowIncompatibleProductException()
        {
            TiltSemitrailer tiltSemitrailer = new TiltSemitrailer(100, 100);
            tiltSemitrailer.Load(new Detergent(1, 1), 1);
            Assert.Throws<IncompatibleProductException>(() => tiltSemitrailer.Load(new WashingPowder(1, 1), 1));
        }
    }
}
