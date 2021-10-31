using System;
using TransportCompanyLib.Models.Products.NeedColdProducts;
using TransportCompanyLib.Models.Semitrailers;
using Xunit;

namespace TransportCompanyTests.ModelTests.SemitrailersTests
{
    public class RefrigeratorSemitrailerTests
    {
        [Fact]
        public void LoadFuelSemitrailer_LoadOtherTypeProduct_ThrowsArgumentException()
        {
            var fuelSemitrailer = new RefrigeratorSemitrailer(10, -10, 5);
            fuelSemitrailer.Load(new Milk(1, 0.75f, 0, 5), 2);
            Assert.Throws<ArgumentException>(() => fuelSemitrailer.Load(new Fish(2, 0.5f, -10, -5), 2));
        }

        [Fact]
        public void LoadFuelSemitrailer_LoadOtherTypeProduct_ReturnsTrue()
        {
            float expected = 4;
            var fuelSemitrailer = new RefrigeratorSemitrailer(10, -10, 5);
            fuelSemitrailer.Load(new Milk(1, 0.5f, 0, 5), 2);
            fuelSemitrailer.Load(new Yogurt(0.5f, 1, 0, 3), 4);
            Assert.Equal(expected, fuelSemitrailer.CurrentProductsWeight);
        }

        [Fact]
        public void UnloadFuelSemitrailer_LoadOtherTypeProduct_ReturnsTrue()
        {
            float expected = 2.5f;
            var fuelSemitrailer = new RefrigeratorSemitrailer(10, -10, 5);
            fuelSemitrailer.Load(new Milk(1, 0.5f, 0, 5), 2);
            fuelSemitrailer.Load(new Yogurt(0.5f, 1, 0, 3), 4);
            fuelSemitrailer.Unload(new Yogurt(0.5f, 1, 0, 3), 1);
            fuelSemitrailer.Unload(new Milk(1, 0.5f, 0, 5), 1);
            Assert.Equal(expected, fuelSemitrailer.CurrentProductsWeight);
        }

        [Fact]
        public void LoadFuelSemitrailer_Test1_ReturnsTrue()
        {
            float expected = 2.5f;
            var fuelSemitrailer = new RefrigeratorSemitrailer(10, -10, 5);
            fuelSemitrailer.Load(new Milk(1, 0.5f, 0, 5), 1);
            fuelSemitrailer.Load(new Yogurt(0.5f, 1, 0, 3), 1);
            fuelSemitrailer.Load(new Milk(1, 0.5f, 0, 5), 1);
        }
    }
}
