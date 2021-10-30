using System;
using TransportCompanyLib.Models.Products.FuelProducts;
using TransportCompanyLib.Models.Semitrailers;
using Xunit;

namespace TransportCompanyTests.ModelTests.SemitrailersTests
{
    public class FuelSemitrailerTests
    {
        [Fact]
        public void CreateFuelSemitrailer_MaxWeightLessThanZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new TankSemitrailer(-10));
        }

        [Fact]
        public void LoadFuelSemitrailer_LoadOtherTypeProduct_ThrowsArgumentException()
        {
            var fuelSemitrailer = new TankSemitrailer(10);
            fuelSemitrailer.Load(new OctanePetrol_95(1), 2);
            Assert.Throws<ArgumentException>(() => fuelSemitrailer.Load(new DieselFuel(1), 2));
        }

        [Theory]
        [InlineData(10, 1, 1)]
        [InlineData(10, 11, 10)]
        [InlineData(10000, 10000, 10000)]
        public void LoadFuelSemitrailer_LoadWithOctanePetrol95_ReturnsTrue(int capacity, int count, float expected)
        {
            var fuelSemitrailer = new TankSemitrailer(capacity);
            fuelSemitrailer.Load(new OctanePetrol_95(1), count);
            Assert.Equal(fuelSemitrailer.CurrentProductsWeight, expected);
        }

        [Fact]
        public void LoadFuelSemitrailer_LoadWithOctanePetrol95AndUnload_ReturnsTrue()
        {
            float expected = 15;
            var fuelSemitrailer = new TankSemitrailer(100);
            fuelSemitrailer.Load(new OctanePetrol_95(1), 20);
            fuelSemitrailer.Unload(new OctanePetrol_95(1), 5);
            Assert.Equal(fuelSemitrailer.CurrentProductsWeight, expected);
        }
    }
}
