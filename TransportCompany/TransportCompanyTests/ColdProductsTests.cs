using System;
using TransportCompanyLib.Models.Products.NeedColdProducts;
using Xunit;

namespace ProductsLib.ModelTests.ProductsTests
{
    public class ColdProductsTests
    {
        [Fact]
        public void CreateMilkProduct_LowerTemperetureHigherThanHigherTemperature_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Milk(1, 1, 5, 0));
        }
    }
}
