namespace XmlDataWorker.Models.DataLoaders
{
    public interface IDataLoader<T> where T : IXmlable
    {
        public void LoadData(string path);
    }
}
