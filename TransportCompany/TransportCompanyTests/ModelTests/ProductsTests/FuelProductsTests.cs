using System;
using TransportCompanyLib.Models.Products.FuelProducts;
using Xunit;

namespace TransportCompanyTests.ProductsTests
{
    public class FuelProductsTests
    {
        [Fact]
        public void CreateDieselFuel_WeightLessThanZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DieselFuel(-1, 1));
        }
    }
}
