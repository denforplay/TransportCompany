using System.Text;
using System.Xml;

namespace XmlDataWorker.Models.DataSavers
{
    public sealed class XmlWriterToXml<T> : XmlSaverBase<T> where T : class
    {
        public override void SaveData(T objectToSave, string filePath)
        {
            StringBuilder xmlBuilder = ConvertToXml(objectToSave);
            using (XmlWriter xw = XmlWriter.Create(filePath))
            {
            }
        }
    }
}
