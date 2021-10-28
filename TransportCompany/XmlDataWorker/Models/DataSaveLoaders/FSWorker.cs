using XmlDataWorker.Models.DataLoaders;
using XmlDataWorker.Models.DataSavers;

namespace XmlDataWorker.Models.DataSaveLoaders
{
    public sealed class FSWorker<T>
    {
        IDataLoader<T> _dataLoader;
        IDataSaver<T> _dataSaver;

        public FSWorker(IDataLoader<T> dataLoader, IDataSaver<T> dataSaver)
        {
            _dataLoader = dataLoader;
            _dataSaver = dataSaver;
        }
    }
}
