using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace XmlDataWorker.Models.DataSavers
{
    public sealed class StreamWriterToXml<T> : XmlSaverBase<T> where T : class
    {
        public override void SaveData(T objectToSave, string filePath)
        {
            StringBuilder xmlBuilder = ConvertToXml(objectToSave);

            using (StreamWriter sw = new StreamWriter(File.Create(filePath)))
            {
                sw.Write(xmlBuilder);
            }
        }
    }
}
