using System.Collections;
using System.Reflection;
using System.Text;

namespace XmlDataWorker.Models.DataSavers
{
    public abstract class XmlSaverBase<T> where T : class
    {
        public abstract void SaveData(T objectToSave, string filePath);

        protected StringBuilder ConvertToXml(T objectToSave)
        {
            StringBuilder xmlBuilder = new StringBuilder();
            xmlBuilder.Append($"<{typeof(T).Name}>\n");
            foreach (var property in typeof(T).GetProperties())
            {
                Read(xmlBuilder, property, objectToSave, "\t");
            }
            xmlBuilder.Append($"</{typeof(T).Name}>");
            return xmlBuilder;
        }

        private void Read(StringBuilder xmlBuilder, PropertyInfo currentProperty, object currentObject, string tabulation)
        {
            IEnumerable list = null;
            xmlBuilder.AppendLine($"\t{tabulation}<{currentProperty.Name}>");
            if (currentProperty.PropertyType.FullName.Contains("Collection"))
                list = currentProperty.GetValue(currentObject) as IEnumerable;
            if (list is not null)
            {
                foreach (var listElem in list)
                {
                    xmlBuilder.AppendLine($"\t\t{tabulation}<{listElem.GetType().FullName}>");
                    foreach (var listElemProperty in listElem.GetType().GetProperties())
                    {
                        Read(xmlBuilder, listElemProperty, listElem, tabulation + "\t\t");
                    }
                    xmlBuilder.AppendLine($"\t\t{tabulation}</{listElem.GetType().FullName}>");
                }
            }
            else
            {
                var length = currentProperty.PropertyType.GetProperties().Length;
                if (length == 0)
                {
                    xmlBuilder.AppendLine($"\t{tabulation}{currentProperty.GetValue(currentObject)}");
                }
                else
                {
                    var innerObject = currentProperty.GetValue(currentObject);
                    foreach (var innerProperty in currentProperty.PropertyType.GetProperties())
                    {
                        Read(xmlBuilder, innerProperty, innerObject, tabulation + "\t");
                    }
                }
            }

            xmlBuilder.AppendLine($"\t{tabulation}</{currentProperty.Name}>");
        }
    }
}
