using System.IO;
using System.Xml;

namespace XmlDataWorker.Models.DataLoaders
{
    public sealed class StreamReaderLoader<T> : XmlLoaderBase<T> where T : class
    {
        public override XmlDocument LoadData(string path)
        {
            if (!File.Exists(path))
                throw new IOException("Cant open file");

            XmlDocument xml = new XmlDocument();
            using (StreamReader streamReader = new StreamReader(File.OpenRead(path)))
            {
                xml.Load(streamReader);
            }

            return xml;
        }
    }
}
