using System;
using TransportCompanyLib.Models.Products.NeedColdProducts;
using TransportCompanyLib.Models.Semitrailers;
using Xunit;

namespace TransportCompanyTests.ModelTests.SemitrailersTests
{
    public class RefrigeratorSemitrailerTests
    {
        [Fact]
        public void LoadRefrigeratorSemitrailer_LoadOtherTypeProduct_ThrowsArgumentException()
        {
            var refrigeratorSemitrailer = new RefrigeratorSemitrailer(10, 10, -10, 5);
            refrigeratorSemitrailer.Load(new Milk(1, 0.75f, 0, 5), 2);
            Assert.Throws<ArgumentException>(() => refrigeratorSemitrailer.Load(new Fish(2, 0.5f, -10, -5), 2));
        }

        [Fact]
        public void LoadRefrigeratorSemitrailer_LoadOtherTypeProduct_ReturnsTrue()
        {
            float expected = 4;
            var refrigeratorSemitrailer = new RefrigeratorSemitrailer(10, 10, -10, 5);
            refrigeratorSemitrailer.Load(new Milk(1, 0.5f, 0, 5), 2);
            refrigeratorSemitrailer.Load(new Yogurt(0.5f, 1, 0, 3), 4);
            Assert.Equal(expected, refrigeratorSemitrailer.CurrentProductsWeight);
        }

        [Fact]
        public void UnloadRefrigeratorSemitrailer_LoadOtherTypeProduct_ReturnsTrue()
        {
            float expected = 2.5f;
            var refrigeratorSemitrailer = new RefrigeratorSemitrailer(10, 10, -10, 5);
            refrigeratorSemitrailer.Load(new Milk(1, 0.5f, 0, 5), 2);
            refrigeratorSemitrailer.Load(new Yogurt(0.5f, 1, 0, 3), 4);
            refrigeratorSemitrailer.Unload(new Yogurt(0.5f, 1, 0, 3), 1);
            refrigeratorSemitrailer.Unload(new Milk(1, 0.5f, 0, 5), 1);
            Assert.Equal(expected, refrigeratorSemitrailer.CurrentProductsWeight);
        }

        [Fact]
        public void LoadRefrigeratorSemitrailer_Test1_ReturnsTrue()
        {
            float expected = 2.5f;
            var refrigeratorSemitrailer = new RefrigeratorSemitrailer(10, 10, -10, 5);
            refrigeratorSemitrailer.Load(new Milk(1, 0.5f, 0, 5), 1);
            refrigeratorSemitrailer.Load(new Yogurt(0.5f, 1, 0, 3), 1);
            refrigeratorSemitrailer.Load(new Milk(1, 0.5f, 0, 5), 1);
            Assert.Equal(expected, refrigeratorSemitrailer.CurrentProductsWeight);
        }
    }
}
