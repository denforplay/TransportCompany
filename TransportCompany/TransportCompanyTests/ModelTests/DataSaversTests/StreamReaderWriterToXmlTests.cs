using TransportCompanyLib.Models;
using TransportCompanyLib.Models.Factories;
using TransportCompanyLib.Models.Factories.ProductFactories;
using TransportCompanyLib.Models.Factories.SemitrailerFactories;
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
        public void TestWritingDieselFuelDataInXml()
        {
            DieselFuel expectedFuel = new DieselFuel(4);
            var writerToXml = new XmlSaveLoader<DieselFuel>(new StreamReaderXmlLoader<DieselFuel>(), new StreamWriterToXml<DieselFuel>(), new FromXmlLiquidFactory<DieselFuel>());
            writerToXml.Save(expectedFuel);
            DieselFuel actualFuel = writerToXml.Load();
            Assert.Equal(expectedFuel, actualFuel);
        }

        [Fact]
        public void TestWritingOctane_Pertol95DataInXml()
        {
            OctanePetrol_95 expectedFuel = new OctanePetrol_95(5);
            var writerToXml = new XmlSaveLoader<OctanePetrol_95>(new StreamReaderXmlLoader<OctanePetrol_95>(), new StreamWriterToXml<OctanePetrol_95>(), new FromXmlLiquidFactory<OctanePetrol_95>());
            writerToXml.Save(expectedFuel);
            OctanePetrol_95 actualFuel = writerToXml.Load();
            Assert.Equal(expectedFuel, actualFuel);
        }


        [Fact]
        public void TestWritingNeedFrozeProductDataInXml()
        {
            Milk expectedProduct = new Milk(5, -10, 5);
            var writerToXml = new XmlSaveLoader<Milk>(new StreamReaderXmlLoader<Milk>(), new StreamWriterToXml<Milk>(), new FromXmlNeedFrozenProductFactory<Milk>());
            writerToXml.Save(expectedProduct);
            Milk actualProduct = writerToXml.Load();
            Assert.Equal(expectedProduct, actualProduct);
        }

        [Fact]
        public void TestWritingTankSemitrailertDataInXml()
        {
            TankSemitrailer expectedSemitrailer = new TankSemitrailer(500);
            expectedSemitrailer.Load(new OctanePetrol_95(1), 5);
            var writerToXml = new XmlSaveLoader<TankSemitrailer>(new StreamReaderXmlLoader<TankSemitrailer>(), new StreamWriterToXml<TankSemitrailer>(), new FromXmlTankSemitrailerFactory());
            writerToXml.Save(expectedSemitrailer);
            TankSemitrailer actualSemitrailer = writerToXml.Load();
            Assert.Equal(expectedSemitrailer, actualSemitrailer);
        }
    }
}
