using System;
using TransportCompanyLib.Models.Products.FuelProducts;
using TransportCompanyLib.Models.Semitrailers;
using TransportCompanyLib.Models.SemitrailerTractors;
using Xunit;

namespace TransportCompanyTests.ModelTests.SemitrailersTractorsTests
{
    public class MANTractorsTest
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void CreateManTractor_MaxWeightLessOrEqualsZero_ThrowsArgumentException(int weight)
        {
            Assert.Throws<ArgumentException>(() => new MANTractor(weight));
        }

        [Fact]
        public void CreateManTractor_ConnectWithSemitrailer()
        {
            var tractor = new MANTractor(1000);
            SemitrailerBase semitrailer = new TankSemitrailer(900, 1500);
            tractor.ConnectSemitrailer(semitrailer);
            semitrailer.Load(new DieselFuel(1, 0.5f), 5);
            Assert.Equal(5, tractor.Semitrailer.CurrentProductsWeight);
        }
    }
}
