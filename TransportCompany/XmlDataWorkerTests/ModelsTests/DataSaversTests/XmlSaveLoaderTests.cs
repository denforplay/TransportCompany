using System;
using TransportCompanyLib.Exceptions;
using TransportCompanyLib.Models.Factories.ProductFactories;
using TransportCompanyLib.Models.Products.FuelProducts;
using XmlDataWorker.Models.DataLoaders;
using XmlDataWorker.Models.DataSaveLoaders;
using XmlDataWorker.Models.DataSavers;
using Xunit;

namespace XmlDataWorkerTests.ModelsTests.DataSaversTests
{
    public class XmlSaveLoaderTests
    {
        [Fact]
        public void TestWritingNullObjectInXml_ThrowsArgumentNullException()
        {
            var writerLoaderToXml = new XmlSaveLoader<OctanePetrol_95>(new StreamReaderLoader(), new StreamWriterToXml<OctanePetrol_95>(), new FromXmlLiquidFactory<OctanePetrol_95>());
            Assert.Throws<ArgumentNullException>(() => writerLoaderToXml.Save(null));
        }

        [Fact]
        public void TestReadingObjectDataFromWrongXml_ThrowsWrongXmlContentException()
        {
            var op95 = new OctanePetrol_95(5, 5);
            var writerLoaderToXml = new XmlSaveLoader<OctanePetrol_95>(new StreamReaderLoader(), new StreamWriterToXml<OctanePetrol_95>(), new FromXmlLiquidFactory<OctanePetrol_95>());
            writerLoaderToXml.Save(op95);
            var newWriterLoaderToXml = new XmlSaveLoader<DieselFuel>(new StreamReaderLoader(), new StreamWriterToXml<DieselFuel>(), new FromXmlLiquidFactory<DieselFuel>());
            Assert.Throws<WrongXmlContentException>(() => newWriterLoaderToXml.Load());
        }
    }
}
