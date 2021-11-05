using System;
using TransportCompanyLib.Models;
using TransportCompanyLib.Models.Products.NeedColdProducts;
using Xunit;

namespace TransportCompanyTests.ProductsTests
{
    public class ColdProductsTests
    {
        [Fact]
        public void CreateNeedColdProduct_LowerTemperetureHigherThanHigherTemperature_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Milk(1, 1, new TemperatureLimit(5, 0)));
        }
    }
}
