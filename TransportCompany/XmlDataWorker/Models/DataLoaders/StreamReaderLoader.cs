using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace XmlDataWorker.Models.DataLoaders
{
    public sealed class StreamReaderLoader<T> : IDataLoader<T>
    {
        public XmlDocument LoadData(string path)
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
