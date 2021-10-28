using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace XmlDataWorker.Models.DataSavers
{
    public sealed class StreamWriterToXml<T> : IDataSaver<T>
    {
        string fillename = Directory.GetCurrentDirectory() + @"\autopark.xml";

        public ICollection SemitrailerBase { get; private set; }

        public void SaveData(T save)
        {
            StringBuilder xmlBuilder = new StringBuilder();
            xmlBuilder.Append($"<{typeof(T)}>\n");
            foreach (var property in typeof(T).GetProperties())
            {
                Read(xmlBuilder, property, save, "\t");
            }
            xmlBuilder.Append($"</{typeof(T)}>");

            XmlDocument xml = new XmlDocument();
            using (StreamWriter sw = new StreamWriter(File.Create(fillename)))
            {
                sw.Write(xmlBuilder);
            }
        }

        private void Read(StringBuilder xmlBuilder, PropertyInfo property, object propertyChecker, string tabulation)
        {
            IEnumerable list = null;
            xmlBuilder.AppendLine($"\t{tabulation}<{property.Name}>");
            if (property.PropertyType.FullName.Contains("Collection"))
                list = property.GetValue(propertyChecker) as IEnumerable;
            if (list is not null)
            {
                foreach (var listElem in list)
                {
                    xmlBuilder.AppendLine($"\t\t{tabulation}<{listElem.GetType().Name}>");
                    foreach (var listElemProperty in listElem.GetType().GetProperties())
                    {
                        Read(xmlBuilder, listElemProperty, listElem, tabulation + "\t\t");
                    }
                    xmlBuilder.AppendLine($"\t\t{tabulation}</{listElem.GetType().Name}>");
                }
            }
            else
            {
                var length = property.PropertyType.GetProperties().Length;
                if (length == 0)
                {
                    xmlBuilder.AppendLine($"\t{tabulation}{property.GetValue(propertyChecker)}");
                }
                else
                {
                    var innerObject = property.GetValue(propertyChecker);
                    foreach (var innerProperty in property.PropertyType.GetProperties())
                    {
                        Read(xmlBuilder, innerProperty, innerObject, tabulation + "\t");
                    }
                }
            }

            xmlBuilder.AppendLine($"\t{tabulation}</{property.Name}>");
        }
    }
}
