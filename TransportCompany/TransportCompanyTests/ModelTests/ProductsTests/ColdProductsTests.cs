using ProductsLib.Models.Products.NeedColdProducts;
using System;
using Xunit;

namespace TransportCompanyTests.ModelTests.ProductsTests
{
    public class ColdProductsTests
    {
        [Fact]
        public void CreateMilkProduct_LowerTemperetureHigherThanHigherTemperature_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Milk(1, 5, 0));
        }
    }
}
