using System;
using TransportCompanyLib.Exceptions;
using TransportCompanyLib.Models.Products.FuelProducts;
using TransportCompanyLib.Models.Semitrailers;
using Xunit;

namespace TransportCompanyTests.ModelTests.SemitrailersTests
{
    public class FuelSemitrailerTests
    {
        [Theory]
        [InlineData(-10, 10)]
        [InlineData(10, -10)]
        [InlineData(0, 10)]
        [InlineData(10, 0)]
        public void CreateFuelSemitrailer_MaxWeightLessThanZero_ThrowsArgumentException(float weight, float volume)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TankSemitrailer(weight, volume));
        }

        [Fact]
        public void LoadFuelSemitrailer_LoadOtherTypeProduct_ThrowsArgumentException()
        {
            var fuelSemitrailer = new TankSemitrailer(10, 10);
            fuelSemitrailer.Load(new OctanePetrol_95(1, 1), 2);
            Assert.Throws<IncompatibleProductException>(() => fuelSemitrailer.Load(new DieselFuel(1, 1), 2));
        }

        [Theory]
        [InlineData(10, 10, 1, 1)]
        [InlineData(10, 10, 11, 10)]
        [InlineData(10000, 10000, 10000, 10000)]
        public void LoadFuelSemitrailer_LoadWithOctanePetrol95_ReturnsTrue(float capacity, float volume, int count, float expected)
        {
            var fuelSemitrailer = new TankSemitrailer(capacity, volume);
            fuelSemitrailer.Load(new OctanePetrol_95(1, 1), count);
            Assert.Equal(fuelSemitrailer.CurrentProductsWeight, expected);
        }

        [Fact]
        public void LoadFuelSemitrailer_LoadWithOctanePetrol95AndUnload_ReturnsTrue()
        {
            float expected = 15;
            var fuelSemitrailer = new TankSemitrailer(100, 500);
            fuelSemitrailer.Load(new OctanePetrol_95(1, 1), 20);
            fuelSemitrailer.Unload(new OctanePetrol_95(1, 1), 5);
            Assert.Equal(fuelSemitrailer.CurrentProductsWeight, expected);
        }
    }
}
