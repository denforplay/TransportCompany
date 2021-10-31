using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XmlDataWorker.Models.DataSavers
{
    public sealed class XmlWriterToXml<T> : XmlSaverBase<T> where T : class
    {
        public override void SaveData(T objectToSave, string filePath)
        {
            StringBuilder xmlBuilder = ConvertToXml(objectToSave);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlBuilder.ToString());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t   ";
            using (var xmlWriter = XmlWriter.Create(filePath, settings))
            {
                xmlDoc.Save(xmlWriter);
            }
        }
    }
}
