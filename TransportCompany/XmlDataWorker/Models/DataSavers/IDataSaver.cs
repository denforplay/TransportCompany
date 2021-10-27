namespace XmlDataWorker.Models.DataSavers
{
    public interface IDataSaver<T>
    {
        public void SaveData(T save);
    }
}
