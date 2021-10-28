using System.IO;
using XmlDataWorker.Models.DataLoaders;
using XmlDataWorker.Models.DataSavers;

namespace XmlDataWorker.Models.DataSaveLoaders
{
    public sealed class XmlSaveLoader<T> where T : class
    {
        private string FILE_PATH = Directory.GetCurrentDirectory() + "/autopark.xml";
        private XmlLoaderBase<T> _dataLoader;
        private XmlSaverBase<T> _dataSaver;

        public XmlSaveLoader(XmlLoaderBase<T> dataLoader, XmlSaverBase<T> dataSaver)
        {
            _dataLoader = dataLoader;
            _dataSaver = dataSaver;
        }

        public void Save(T objectToSave)
        {
            _dataSaver.SaveData(objectToSave, FILE_PATH);
        }

        public T Load()
        {
            var test = _dataLoader.LoadData(FILE_PATH);
            return null;
        }
    }
}
