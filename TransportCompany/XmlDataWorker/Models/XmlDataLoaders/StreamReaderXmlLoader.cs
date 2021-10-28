using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace XmlDataWorker.Models.DataLoaders
{
    public sealed class StreamReaderXmlLoader<T> : XmlLoaderBase<T> where T : class
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
