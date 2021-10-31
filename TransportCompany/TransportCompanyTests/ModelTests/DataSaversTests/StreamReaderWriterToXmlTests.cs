using TransportCompanyLib.Models;
using TransportCompanyLib.Models.Factories;
using TransportCompanyLib.Models.Factories.AutoparkFactory;
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
using Xunit;

namespace TransportCompanyTests.ModelTests.DataSaversTests
{
    public class StreamReaderWriterToXmlTests
    {
        [Fact]
        public void TestWritingReadingDieselFuelDataInXml()
        {
            DieselFuel expectedFuel = new DieselFuel(4);
            var writerToXml = new XmlSaveLoader<DieselFuel>(new StreamReaderXmlLoader<DieselFuel>(), new StreamWriterToXml<DieselFuel>(), new FromXmlLiquidFactory<DieselFuel>());
            writerToXml.Save(expectedFuel);
            DieselFuel actualFuel = writerToXml.Load();
            Assert.Equal(expectedFuel, actualFuel);
        }

        [Fact]
        public void TestWritingReadingOctane_Pertol95DataInXml()
        {
            OctanePetrol_95 expectedFuel = new OctanePetrol_95(5);
            var writerToXml = new XmlSaveLoader<OctanePetrol_95>(new StreamReaderXmlLoader<OctanePetrol_95>(), new StreamWriterToXml<OctanePetrol_95>(), new FromXmlLiquidFactory<OctanePetrol_95>());
            writerToXml.Save(expectedFuel);
            OctanePetrol_95 actualFuel = writerToXml.Load();
            Assert.Equal(expectedFuel, actualFuel);
        }


        [Fact]
        public void TestWritingReadingNeedFrozeProductDataInXml()
        {
            Milk expectedProduct = new Milk(5, -10, 5);
            var writerToXml = new XmlSaveLoader<Milk>(new StreamReaderXmlLoader<Milk>(), new StreamWriterToXml<Milk>(), new FromXmlNeedFrozenProductFactory<Milk>());
            writerToXml.Save(expectedProduct);
            Milk actualProduct = writerToXml.Load();
            Assert.Equal(expectedProduct, actualProduct);
        }

        [Fact]
        public void TestWritingReadingTankSemitrailertDataInXml()
        {
            TankSemitrailer expectedSemitrailer = new TankSemitrailer(500);
            expectedSemitrailer.Load(new OctanePetrol_95(1), 5);
            var writerToXml = new XmlSaveLoader<TankSemitrailer>(new StreamReaderXmlLoader<TankSemitrailer>(), new StreamWriterToXml<TankSemitrailer>(), new FromXmlTankSemitrailerFactory());
            writerToXml.Save(expectedSemitrailer);
            TankSemitrailer actualSemitrailer = writerToXml.Load();
            Assert.True(expectedSemitrailer.Equals(actualSemitrailer));
        }

        [Fact]
        public void TestWritingRefrigeratorSemitrailertDataInXml()
        {
            RefrigeratorSemitrailer expectedSemitrailer = new RefrigeratorSemitrailer(500, -5, 5);
            expectedSemitrailer.Load(new Yogurt(1, -4, 4), 10);
            var writerToXml = new XmlSaveLoader<RefrigeratorSemitrailer>(new StreamReaderXmlLoader<RefrigeratorSemitrailer>(), new StreamWriterToXml<RefrigeratorSemitrailer>(), new FromXmlRefrigeratorSemitrailerFactory());
            writerToXml.Save(expectedSemitrailer);
            RefrigeratorSemitrailer actualSemitrailer = writerToXml.Load();
            Assert.True(expectedSemitrailer.Equals(actualSemitrailer));
        }

        [Fact]
        public void TestWritingMANTractorDataInXml()
        {
            MANTractor expectedTractor = new MANTractor(100);
            RefrigeratorSemitrailer expectedSemitrailer = new RefrigeratorSemitrailer(100, -5, 5);
            expectedSemitrailer.Load(new Yogurt(1, -4, 4), 10);
            expectedTractor.ConnectSemitrailer(expectedSemitrailer);
            var serializer = new XmlSaveLoader<MANTractor>(new StreamReaderXmlLoader<MANTractor>(), new StreamWriterToXml<MANTractor>(), new FromXmlTractorFactory<MANTractor>());
            serializer.Save(expectedTractor);
            MANTractor realTractor = serializer.Load();
            Assert.True(expectedTractor.Equals(realTractor));
        }

        [Fact]
        public void TestWritingAutoparkDataInXml()
        {
            Autopark expectedAutopark = new Autopark();
            RefrigeratorSemitrailer expectedSemitrailer = new RefrigeratorSemitrailer(100, -5, 5);
            expectedSemitrailer.Load(new Yogurt(1, -4, 4), 10);
            expectedAutopark.AddSemitrailer(expectedSemitrailer);
            var serializer = new XmlSaveLoader<Autopark>(new StreamReaderXmlLoader<Autopark>(), new StreamWriterToXml<Autopark>(), new AutoparkFromXmlFactory());
            serializer.Save(expectedAutopark);
            Autopark actualAutopark = serializer.Load();
        }
    }
}
