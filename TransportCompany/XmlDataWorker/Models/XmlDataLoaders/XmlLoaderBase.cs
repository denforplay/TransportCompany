using System.Xml;

namespace XmlDataWorker.Models.DataLoaders
{
    public abstract class XmlLoaderBase<T> where T : class
    {
        public abstract XmlDocument LoadData(string path);
    }
}
