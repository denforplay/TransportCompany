using TransportCompanyLib.Models.Factories.ProductFactories;
using TransportCompanyLib.Models.Factories.SemitrailerFactories;
using TransportCompanyLib.Models.Factories.TractorFactories;
using TransportCompanyLib.Models.Products.FuelProducts;
using TransportCompanyLib.Models.Products.NeedColdProducts;
using TransportCompanyLib.Models.Semitrailers;
using TransportCompanyLib.Models.SemitrailerTractors;
using XmlDataWorker.Models.DataLoaders;
using XmlDataWorker.Models.DataSaveLoaders;
using XmlDataWorker.Models.DataSavers;
using XmlDataWorker.Models.XmlDataLoaders;
using Xunit;

namespace TransportCompanyTests.ModelTests.DataSaversTests
{
    public sealed class ReadWriteXmlTestsUsingXmlWriterStreamReader
    {
        [Fact]
        public void TestWritingReadingDieselFuelDataInXml()
        {
            DieselFuel expectedFuel = new DieselFuel(4, 4);
            XmlSaveLoader<DieselFuel> writerToXml = NewMethod(expectedFuel);
            DieselFuel actualFuel = writerToXml.Load();
            Assert.Equal(expectedFuel, actualFuel);
        }

        private static XmlSaveLoader<DieselFuel> NewMethod(DieselFuel expectedFuel)
        {
            var writerToXml = new XmlSaveLoader<DieselFuel>(new StreamReaderLoader<DieselFuel>(), new XmlWriterToXml<DieselFuel>(), new FromXmlLiquidFactory<DieselFuel>());
            writerToXml.Save(expectedFuel);
            return writerToXml;
        }

        [Fact]
        public void TestWritingReadingOctane_Pertol95DataInXml()
        {
            OctanePetrol_95 expectedFuel = new OctanePetrol_95(5.5f, 1.5f);
            var writerToXml = new XmlSaveLoader<OctanePetrol_95>(new StreamReaderLoader<OctanePetrol_95>(), new XmlWriterToXml<OctanePetrol_95>(), new FromXmlLiquidFactory<OctanePetrol_95>());
            writerToXml.Save(expectedFuel);
            OctanePetrol_95 actualFuel = writerToXml.Load();
            Assert.Equal(expectedFuel, actualFuel);
        }


        [Fact]
        public void TestWritingReadingNeedFrozeProductDataInXml()
        {
            Milk expectedProduct = new Milk(5, 2.5f, -10, 5);
            var writerToXml = new XmlSaveLoader<Milk>(new StreamReaderLoader<Milk>(), new XmlWriterToXml<Milk>(), new FromXmlNeedFrozenProductFactory<Milk>());
            writerToXml.Save(expectedProduct);
            Milk actualProduct = writerToXml.Load();
            Assert.Equal(expectedProduct, actualProduct);
        }

        [Fact]
        public void TestWritingReadingTankSemitrailertDataInXml()
        {
            TankSemitrailer expectedSemitrailer = new TankSemitrailer(500, 250);
            expectedSemitrailer.Load(new OctanePetrol_95(1, 1), 5);
            var writerToXml = new XmlSaveLoader<TankSemitrailer>(new StreamReaderLoader<TankSemitrailer>(), new XmlWriterToXml<TankSemitrailer>(), new FromXmlTankSemitrailerFactory());
            writerToXml.Save(expectedSemitrailer);
            TankSemitrailer actualSemitrailer = writerToXml.Load();
            Assert.True(expectedSemitrailer.Equals(actualSemitrailer));
        }

        [Fact]
        public void TestWritingRefrigeratorSemitrailertDataInXml()
        {
            RefrigeratorSemitrailer expectedSemitrailer = new RefrigeratorSemitrailer(500, 1000, -5, 5);
            expectedSemitrailer.Load(new Yogurt(1, 1, -4, 4), 10);
            var writerToXml = new XmlSaveLoader<RefrigeratorSemitrailer>(new StreamReaderLoader<RefrigeratorSemitrailer>(), new XmlWriterToXml<RefrigeratorSemitrailer>(), new FromXmlRefrigeratorSemitrailerFactory());
            writerToXml.Save(expectedSemitrailer);
            RefrigeratorSemitrailer actualSemitrailer = writerToXml.Load();
            Assert.True(expectedSemitrailer.Equals(actualSemitrailer));
        }

        [Fact]
        public void TestWritingMANTractorDataInXml()
        {
            MANTractor expectedTractor = new MANTractor(100);
            RefrigeratorSemitrailer expectedSemitrailer = new RefrigeratorSemitrailer(100, 250, -5, 5);
            expectedSemitrailer.Load(new Yogurt(1, 1, -4, 4), 10);
            expectedTractor.ConnectSemitrailer(expectedSemitrailer);
            var serializer = new XmlSaveLoader<MANTractor>(new StreamReaderLoader<MANTractor>(), new XmlWriterToXml<MANTractor>(), new FromXmlTractorFactory<MANTractor>());
            serializer.Save(expectedTractor);
            MANTractor realTractor = serializer.Load();
            Assert.True(expectedTractor.Equals(realTractor));
        }
    }
}
