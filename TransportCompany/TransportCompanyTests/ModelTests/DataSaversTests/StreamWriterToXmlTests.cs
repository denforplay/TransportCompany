using ProductsLib.Models.Products.FuelProducts;
using System;
using System.IO;
using System.Linq;
using TransportCompanyLib.Models;
using TransportCompanyLib.Models.Semitrailers;
using XmlDataWorker.Models.DataLoaders;
using XmlDataWorker.Models.DataSavers;
using Xunit;

namespace TransportCompanyTests.ModelTests.DataSaversTests
{
    public class StreamWriterToXmlTests
    {
        [Fact]
        public void TestWritinigDataInXml()
        {
            IDataSaver<DieselFuel> dataSaver = new StreamWriterToXml<DieselFuel>();
            dataSaver.SaveData(new DieselFuel(5));
            IDataLoader<DieselFuel> dataLoader = new StreamReaderLoader<DieselFuel>();
            dataLoader.LoadData(Directory.GetCurrentDirectory() + "/autopark.xml");
            Type type = Type.GetType("TankSemitrailer");
        }
    }
}
