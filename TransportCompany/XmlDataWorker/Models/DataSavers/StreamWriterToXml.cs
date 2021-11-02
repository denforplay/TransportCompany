using System.IO;
using System.Text;

namespace XmlDataWorker.Models.DataSavers
{
    /// <summary>
    /// Class writes object of type T in file using StreamWriter
    /// </summary>
    /// <typeparam name="T">Type of object to write in xml</typeparam>
    public sealed class StreamWriterToXml<T> : XmlSaverBase<T> where T : class
    {
        public override void SaveData(T objectToSave, string filePath)
        {
            StringBuilder xmlBuilder = ConvertToXml(objectToSave);

            using (StreamWriter sw = new StreamWriter(File.Create(filePath), Encoding.UTF8))
            {
                sw.Write(xmlBuilder);
            }
        }
    }
}
