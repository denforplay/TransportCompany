using System;
using System.Collections;
using System.Reflection;
using System.Text;

namespace XmlDataWorker.Models.DataSavers
{
    /// <summary>
    /// Represents xml saver class
    /// </summary>
    /// <typeparam name="T">Type of object to save in xml</typeparam>
    public abstract class XmlSaverBase<T> where T : class
    {
        /// <summary>
        /// Method saves object in file
        /// </summary>
        /// <param name="objectToSave">Object to save</param>
        /// <param name="filePath">File path</param>
        public abstract void SaveData(T objectToSave, string filePath);

        /// <summary>
        /// Method converts object to xml view.
        /// </summary>
        /// <param name="objectToSave">Object to parse in xml</param>
        /// <returns>String builder represents xml view of object</returns>
        protected StringBuilder ConvertToXml(T objectToSave)
        {
            StringBuilder xmlBuilder = new StringBuilder();
            xmlBuilder.Append($"<{typeof(T).Name}>\n");
            foreach (var property in typeof(T).GetProperties())
            {
                ReadProperty(xmlBuilder, property, objectToSave, "\t");
            }
            xmlBuilder.Append($"</{typeof(T).Name}>");
            return xmlBuilder;
        }

        /// <summary>
        /// Read property from object and write in xml
        /// </summary>
        /// <param name="xmlBuilder">Current xml string builder</param>
        /// <param name="currentProperty">Current property to read from object</param>
        /// <param name="currentObject">Current object to read property</param>
        /// <param name="tabulation">Xml tag tabulation</param>
        private void ReadProperty(StringBuilder xmlBuilder, PropertyInfo currentProperty, object currentObject, string tabulation)
        {
            IEnumerable list = currentProperty.GetValue(currentObject) as IEnumerable;

            if (currentProperty.PropertyType.IsValueType || list is not null)
                xmlBuilder.Append($"\t{tabulation}<{currentProperty.Name}>");
            else
                xmlBuilder.Append($"\t{tabulation}<{currentProperty.Name} {nameof(Type)}='{currentProperty.GetValue(currentObject).GetType().FullName}'>");
           
            if (list is not null)
            {
                ReadListObjects(xmlBuilder, list, tabulation);
            }
            else
            {
                var length = currentProperty.PropertyType.GetProperties().Length;
                if (length == 0)
                {
                    xmlBuilder.Append($"{currentProperty.GetValue(currentObject)}</{currentProperty.Name}>\n");
                    return;
                }
                else
                {
                    ReadInnerObject(xmlBuilder, currentProperty, currentObject, tabulation);
                }
            }

            xmlBuilder.AppendLine($"\t{tabulation}</{currentProperty.Name}>");
        }

        /// <summary>
        /// Read list of objects
        /// </summary>
        /// <param name="xmlBuilder">Current xml string builder</param>
        /// <param name="listToRead">List with object to write in xml</param>
        /// <param name="tabulation">Xml string tabulation</param>
        private void ReadListObjects(StringBuilder xmlBuilder, IEnumerable listToRead, string tabulation)
        {
            foreach (var listElem in listToRead)
            {
                xmlBuilder.AppendLine($"\n\t\t{tabulation}<{listElem.GetType().FullName}>");
                foreach (var listElemProperty in listElem.GetType().GetProperties())
                {
                    ReadProperty(xmlBuilder, listElemProperty, listElem, tabulation + "\t\t");
                }

                xmlBuilder.Append($"\t\t{tabulation}</{listElem.GetType().FullName}>");
            }

            xmlBuilder.Append($"\n");
        }

        /// <summary>
        /// Read inner object of current object
        /// </summary>
        /// <param name="xmlBuilder">Current xml string builder</param>
        /// <param name="currentProperty">Current property</param>
        /// <param name="currentObject">Current object to check property</param>
        /// <param name="tabulation">Xml string tabulation</param>
        private void ReadInnerObject(StringBuilder xmlBuilder, PropertyInfo currentProperty, object currentObject, string tabulation)
        {
            var innerObject = currentProperty.GetValue(currentObject);
            if (innerObject is not null)
            {
                xmlBuilder.AppendLine();
                foreach (var innerProperty in innerObject.GetType().GetProperties())
                {
                    ReadProperty(xmlBuilder, innerProperty, innerObject, tabulation + "\t");
                }
            }
        }
    }
}
