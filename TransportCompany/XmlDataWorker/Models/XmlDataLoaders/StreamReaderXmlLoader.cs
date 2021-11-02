using System.IO;
using System.Xml;

namespace XmlDataWorker.Models.DataLoaders
{
    /// <summary>
    /// Class provides functionality to load xml data using stream reader
    /// </summary>
    public sealed class StreamReaderLoader : XmlLoaderBase
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
