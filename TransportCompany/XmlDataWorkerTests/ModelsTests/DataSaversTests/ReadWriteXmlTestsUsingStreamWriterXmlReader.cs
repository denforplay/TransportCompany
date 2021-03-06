using TransportCompanyLib.Exceptions;
using TransportCompanyLib.Models;
using TransportCompanyLib.Models.Factories.ProductFactories;
using TransportCompanyLib.Models.Factories.SemitrailerFactories;
using TransportCompanyLib.Models.Factories.TractorFactories;
using TransportCompanyLib.Models.Products.FuelProducts;
using TransportCompanyLib.Models.Products.HouseholdGoods.HouseholdChemicals;
using TransportCompanyLib.Models.Products.NeedColdProducts;
using TransportCompanyLib.Models.Semitrailers;
using TransportCompanyLib.Models.SemitrailerTractors;
using XmlDataWorker.Models.DataSaveLoaders;
using XmlDataWorker.Models.DataSavers;
using XmlDataWorker.Models.XmlDataLoaders;
using Xunit;

namespace XmlDataWorkerTests.ModelTests.DataSaversTests
{
    public sealed class ReadWriteXmlTestsUsingStreamWriterXmlReader
    {
        [Fact]
        public void TestReadingObjectDataFromWrongXml_ThrowsWrongXmlContentException()
        {
            var writerToXml = new XmlSaveLoader<DieselFuel>(new XmlReaderLoader(), new StreamWriterToXml<DieselFuel>(), new FromXmlLiquidFactory<DieselFuel>());
            Assert.Throws<WrongXmlContentException>(() => writerToXml.Load());
        }

        [Fact]
        public void TestWritingReadingDieselFuelDataInXml()
        {
            DieselFuel expectedFuel = new DieselFuel(4, 4);
            var writerToXml = new XmlSaveLoader<DieselFuel>(new XmlReaderLoader(), new StreamWriterToXml<DieselFuel>(), new FromXmlLiquidFactory<DieselFuel>());
            writerToXml.Save(expectedFuel);
            DieselFuel actualFuel = writerToXml.Load();
            Assert.Equal(expectedFuel, actualFuel);
        }

        [Fact]
        public void TestWritingReadingOctane_Pertol95DataInXml()
        {
            OctanePetrol_95 expectedFuel = new OctanePetrol_95(5.5f, 1.5f);
            var writerToXml = new XmlSaveLoader<OctanePetrol_95>(new XmlReaderLoader(), new StreamWriterToXml<OctanePetrol_95>(), new FromXmlLiquidFactory<OctanePetrol_95>());
            writerToXml.Save(expectedFuel);
            OctanePetrol_95 actualFuel = writerToXml.Load();
            Assert.Equal(expectedFuel, actualFuel);
        }


        [Fact]
        public void TestWritingReadingNeedFrozeProductDataInXml()
        {
            Milk expectedProduct = new Milk(5, 2.5f, new TemperatureLimit(-10, 5));
            var writerToXml = new XmlSaveLoader<Milk>(new XmlReaderLoader(), new StreamWriterToXml<Milk>(), new FromXmlNeedFrozenProductFactory<Milk>());
            writerToXml.Save(expectedProduct);
            Milk actualProduct = writerToXml.Load();
            Assert.Equal(expectedProduct, actualProduct);
        }

        [Fact]
        public void TestWritingReadingTankSemitrailertDataInXml()
        {
            TankSemitrailer expectedSemitrailer = new TankSemitrailer(500, 250);
            expectedSemitrailer.Load(new OctanePetrol_95(1, 1), 5);
            var writerToXml = new XmlSaveLoader<TankSemitrailer>(new XmlReaderLoader(), new StreamWriterToXml<TankSemitrailer>(), new FromXmlTankSemitrailerFactory());
            writerToXml.Save(expectedSemitrailer);
            TankSemitrailer actualSemitrailer = writerToXml.Load();
            Assert.True(expectedSemitrailer.Equals(actualSemitrailer));
        }

        [Fact]
        public void TestWritingRefrigeratorSemitrailertDataInXml()
        {
            RefrigeratorSemitrailer expectedSemitrailer = new RefrigeratorSemitrailer(500, 1000, new TemperatureLimit(-5, 5));
            expectedSemitrailer.Load(new Yogurt(1, 1, new TemperatureLimit(-4, 4)), 10);
            var writerToXml = new XmlSaveLoader<RefrigeratorSemitrailer>(new XmlReaderLoader(), new StreamWriterToXml<RefrigeratorSemitrailer>(), new FromXmlRefrigeratorSemitrailerFactory());
            writerToXml.Save(expectedSemitrailer);
            RefrigeratorSemitrailer actualSemitrailer = writerToXml.Load();
            Assert.True(expectedSemitrailer.Equals(actualSemitrailer));
        }

        [Fact]
        public void TestWritingTiltSemitrailerDataInXml()
        {
            TiltSemitrailer expectedSemitrailer = new TiltSemitrailer(500, 1000);
            expectedSemitrailer.Load(new Detergent(1, 1), 10);
            var writerToXml = new XmlSaveLoader<TiltSemitrailer>(new XmlReaderLoader(), new StreamWriterToXml<TiltSemitrailer>(), new FromXmlTiltSemitrailerFactory());
            writerToXml.Save(expectedSemitrailer);
            TiltSemitrailer actualSemitrailer = writerToXml.Load();
            Assert.True(expectedSemitrailer.Equals(actualSemitrailer));
        }

        [Fact]
        public void TestWritingMANTractorDataInXml()
        {
            MANTractor expectedTractor = new MANTractor(100);
            RefrigeratorSemitrailer expectedSemitrailer = new RefrigeratorSemitrailer(100, 250, new TemperatureLimit(-5, 5));
            expectedSemitrailer.Load(new Yogurt(1, 1, new TemperatureLimit(-4, 4)), 10);
            expectedTractor.ConnectSemitrailer(expectedSemitrailer);
            var serializer = new XmlSaveLoader<MANTractor>(new XmlReaderLoader(), new StreamWriterToXml<MANTractor>(), new FromXmlTractorFactory<MANTractor>());
            serializer.Save(expectedTractor);
            MANTractor realTractor = serializer.Load();
            Assert.True(expectedTractor.Equals(realTractor));
        }
    }
}
