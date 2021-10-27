using System.IO;
using System.Xml;

namespace XmlDataWorker.Models.DataSavers
{
    public sealed class StreamWriterToXml<T> : IDataSaver<T> where T : IXmlable
    {
        string fillename = Directory.GetCurrentDirectory() + @"\autopark.xml";

        public void SaveData(T save)
        {
            XmlDocument xml = new XmlDocument();
            using (StreamWriter sw = new StreamWriter(File.Create(fillename)))
            {
                sw.WriteLine(save.WriteInXml());
            }
        }
    }
}
