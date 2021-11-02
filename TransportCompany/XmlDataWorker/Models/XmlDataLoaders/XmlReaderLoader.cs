using System.IO;
using System.Xml;
using XmlDataWorker.Models.DataLoaders;

namespace XmlDataWorker.Models.XmlDataLoaders
{
    /// <summary>
    /// Class provides functionality to load xml data using xml reader
    /// </summary>
    public sealed class XmlReaderLoader : XmlLoaderBase
    {
        public override XmlDocument LoadData(string path)
        {
            if (!File.Exists(path))
                throw new IOException("Cant open file");

            XmlDocument xml = new XmlDocument();
            using (XmlReader xmlReader = XmlReader.Create(File.OpenRead(path)))
            {
                xml.Load(xmlReader);
            }

            return xml;
        }
    }
}
