using System;
using System.Collections.Generic;
using TransportCompanyLib.Models;
using TransportCompanyLib.Models.Products.FuelProducts;
using TransportCompanyLib.Models.Products.NeedColdProducts;
using TransportCompanyLib.Models.Semitrailers;
using TransportCompanyLib.Models.SemitrailerTractors;
using Xunit;

namespace TransportCompanyTests.ModelTests
{
    public sealed class AutoparkTests
    {
        [Fact]
        public void TestFindSemitrailerByTypeInAutopark_ReturnsTrue()
        {
            Type expectedType = typeof(TankSemitrailer);
            Autopark autopark = new Autopark();
            autopark.AddSemitrailer(new TankSemitrailer(100, 100));
            autopark.AddSemitrailer(new RefrigeratorSemitrailer(100, 100, 0, 10));
            Type actualType = autopark.FindSemitrailer<TankSemitrailer>().GetType();
            Assert.Equal(expectedType, actualType);
        }

        [Fact]
        public void TestFindAllHitchesThatCanBeLoaded_ReturnsNull()
        {
            var expected = new List<SemitrailerTractorBase>();
            Autopark autopark = new Autopark();
            autopark.AddTractor(new MANTractor(100));
            autopark.AddTractor(new MANTractor(100));
            autopark.AddSemitrailer(new TankSemitrailer(100, 100));
            autopark.AddSemitrailer(new RefrigeratorSemitrailer(100, 100, 0, 10));
            var actual = autopark.FindAllHitchesThatCanBeLoaded();
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestFindAllHitchesThatCanBeLoaded_ReturnsAll()
        {
            Autopark autopark = new Autopark();
            var tractor1 = new MANTractor(100);
            var tractor2 = new MANTractor(100);
            var tankSemitrailer = new TankSemitrailer(100, 100);
            var refrigeratorSemitrailer = new RefrigeratorSemitrailer(100, 100, 0, 10);
            var expected = new List<SemitrailerTractorBase>
            {
                tractor1, tractor2
            };

            tractor1.ConnectSemitrailer(tankSemitrailer);
            tractor2.ConnectSemitrailer(refrigeratorSemitrailer);
            autopark.AddTractor(tractor1);
            autopark.AddTractor(tractor2);
            autopark.AddSemitrailer(tankSemitrailer);
            autopark.AddSemitrailer(refrigeratorSemitrailer);
            var actual = autopark.FindAllHitchesThatCanBeLoaded();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestFindAllHitchesThatCanBeLoaded_ReturnsOne()
        {
            Autopark autopark = new Autopark();
            var tractor1 = new MANTractor(100);
            var tractor2 = new MANTractor(100);
            var tankSemitrailer = new TankSemitrailer(100, 100);
            var refrigeratorSemitrailer = new RefrigeratorSemitrailer(100, 100, 0, 10);
            refrigeratorSemitrailer.Load(new Milk(100, 100, 5, 10), 1);
            var expected = new List<SemitrailerTractorBase>
            {
                tractor1
            };

            tractor1.ConnectSemitrailer(tankSemitrailer);
            tractor2.ConnectSemitrailer(refrigeratorSemitrailer);
            autopark.AddTractor(tractor1);
            autopark.AddTractor(tractor2);
            autopark.AddSemitrailer(tankSemitrailer);
            autopark.AddSemitrailer(refrigeratorSemitrailer);
            var actual = autopark.FindAllHitchesThatCanBeLoaded();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestFindSemitrailerByTemplate_ReturnsTrue()
        {
            Type expected = typeof(RefrigeratorSemitrailer);
            Autopark autopark = new Autopark();
            var tankSemitrailer = new TankSemitrailer(100, 100);
            var refrigeratorSemitrailer = new RefrigeratorSemitrailer(100, 100, 0, 10);
            autopark.AddSemitrailer(tankSemitrailer);
            autopark.AddSemitrailer(refrigeratorSemitrailer);
            var findTemplate = new RefrigeratorSemitrailer(100, 100, 0, 5);
            var actual = autopark.FindSemitrailerByTemplate(findTemplate);
            Assert.Equal(expected, actual.GetType());
        }


        [Fact]
        public void TestFindAllHitchesThatCanBeLoadedFully_ReturnsOneFromThree()
        {
            Autopark autopark = new Autopark();
            var tractor1 = new MANTractor(100);
            var tractor2 = new MANTractor(100);
            var tractor3 = new MANTractor(100);
            var tankSemitrailer1 = new TankSemitrailer(100, 100);
            var tankSemitrailer2 = new TankSemitrailer(200, 200);
            var refrigeratorSemitrailer = new RefrigeratorSemitrailer(100, 100, 0, 10);
            refrigeratorSemitrailer.Load(new Milk(100, 100, 5, 10), 1);
            tankSemitrailer1.Load(new OctanePetrol_95(50, 50), 1);
            tractor1.ConnectSemitrailer(tankSemitrailer1);
            tractor2.ConnectSemitrailer(refrigeratorSemitrailer);
            tractor3.ConnectSemitrailer(tankSemitrailer2);

            var expected = new List<SemitrailerTractorBase>
            {
                tractor1
            };

            autopark.AddTractor(tractor1);
            autopark.AddTractor(tractor2);
            autopark.AddSemitrailer(tankSemitrailer1);
            autopark.AddSemitrailer(tankSemitrailer2);
            autopark.AddSemitrailer(refrigeratorSemitrailer);
            var actual = autopark.FindAllHitchesThatCanBeLoadedFully();
            Assert.Equal(expected, actual);
        }
    }
}
