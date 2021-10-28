using System.Xml;

namespace XmlDataWorker.Models.DataLoaders
{
    public interface IDataLoader<T>
    {
        public XmlDocument LoadData(string path);
    }
}
