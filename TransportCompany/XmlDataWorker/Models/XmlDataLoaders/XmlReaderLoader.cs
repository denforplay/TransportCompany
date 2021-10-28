using System.IO;
using System.Xml;
using XmlDataWorker.Models.DataLoaders;

namespace XmlDataWorker.Models.XmlDataLoaders
{
    public sealed class XmlReaderLoader<T> : XmlLoaderBase<T> where T : class
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
