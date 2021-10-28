using ProductsLib.Models.Products.FuelProducts;
using ProductsLib.Models.Products.NeedColdProducts;
using System;
using System.IO;
using System.Linq;
using TransportCompanyLib.Models;
using TransportCompanyLib.Models.Semitrailers;
using TransportCompanyLib.Models.SemitrailerTractors;
using XmlDataWorker.Models.DataLoaders;
using XmlDataWorker.Models.DataSaveLoaders;
using XmlDataWorker.Models.DataSavers;
using XmlDataWorker.Models.XmlDataLoaders;
using Xunit;

namespace TransportCompanyTests.ModelTests.DataSaversTests
{
    public class StreamWriterToXmlTests
    {
        [Fact]
        public void TestWritingProductDataInXml()
        {
            Autopark autopark = new Autopark();
            Milk milk = new Milk(5, 0, 5);
            var semitrailer = new TankSemitrailer(100);
            semitrailer.Load(new OctanePetrol_95(4), 5);
            var tractor = new MANTractor(1000);
            tractor.ConnectSemitrailer(semitrailer);
            autopark.AddTractor(tractor);
            autopark.AddSemitrailer(semitrailer);
            autopark.AddSemitrailer(new TankSemitrailer(200));
            autopark.AddSemitrailer(new TankSemitrailer(300));
            XmlSaveLoader<Autopark> xmlSaveLoader = new XmlSaveLoader<Autopark>(new XmlReaderLoader<Autopark>(), new StreamWriterToXml<Autopark>());
            xmlSaveLoader.Save(autopark);
            xmlSaveLoader.Load();
        }
    }
}
