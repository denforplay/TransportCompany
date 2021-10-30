using System.IO;
using TransportCompanyLib.Models.Factories;
using XmlDataWorker.Models.DataLoaders;
using XmlDataWorker.Models.DataSavers;

namespace XmlDataWorker.Models.DataSaveLoaders
{
    public sealed class XmlSaveLoader<T> where T : class
    {
        private string FILE_PATH = Directory.GetCurrentDirectory() + "/autopark.xml";
        private XmlLoaderBase<T> _dataLoader;
        private XmlSaverBase<T> _dataSaver;
        private IFromXmlFactory<T> _xmlFactory;

        public XmlSaveLoader(XmlLoaderBase<T> dataLoader, XmlSaverBase<T> dataSaver, IFromXmlFactory<T> fromXmlFactory)
        {
            _dataLoader = dataLoader;
            _dataSaver = dataSaver;
            _xmlFactory = fromXmlFactory;
        }

        public void Save(T objectToSave)
        {
            _dataSaver.SaveData(objectToSave, FILE_PATH);
        }

        public T Load()
        {
            var test = _dataLoader.LoadData(FILE_PATH);
            return _xmlFactory.Create(test[typeof(T).Name]);
        }
    }
}
