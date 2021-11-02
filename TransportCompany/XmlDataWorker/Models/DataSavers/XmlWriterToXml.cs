using System.Text;
using System.Xml;

namespace XmlDataWorker.Models.DataSavers
{
    /// <summary>
    /// Class writes object of type T in file using XmlWriter
    /// </summary>
    /// <typeparam name="T">Type of object to write in xml</typeparam>
    public sealed class XmlWriterToXml<T> : XmlSaverBase<T> where T : class
    {
        public override void SaveData(T objectToSave, string filePath)
        {
            StringBuilder xmlBuilder = ConvertToXml(objectToSave);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlBuilder.ToString());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            using (var xmlWriter = XmlWriter.Create(filePath, settings))
            {
                xmlDoc.Save(xmlWriter);
            }
        }
    }
}
