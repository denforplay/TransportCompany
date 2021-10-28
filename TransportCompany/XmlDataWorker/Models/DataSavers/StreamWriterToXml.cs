using System.IO;
using System.Text;
using System.Xml;

namespace XmlDataWorker.Models.DataSavers
{
    public sealed class StreamWriterToXml<T> : IDataSaver<T>
    {
        string fillename = Directory.GetCurrentDirectory() + @"\autopark.xml";
        public void SaveData(T save)
        {
            StringBuilder xmlBuilder = new StringBuilder();
            xmlBuilder.Append($"<{typeof(T)}>\n");
            foreach(var property in typeof(T).GetProperties())
            {
                xmlBuilder.AppendLine($"<{property.Name}>{property.GetValue(save)}</{property.Name}>");
            }
            xmlBuilder.Append($"</{typeof(T)}>");

            XmlDocument xml = new XmlDocument();
            using (StreamWriter sw = new StreamWriter(File.Create(fillename)))
            {
                sw.Write(xmlBuilder);
            }
        }
    }
}
