﻿using System;
using System.Collections;
using System.Linq;
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
            if (currentProperty.PropertyType.FullName.Contains("Collection"))
                list = currentProperty.GetValue(currentObject) as IEnumerable;

            if (currentProperty.PropertyType.IsValueType || list is not null)
                xmlBuilder.Append($"\t{tabulation}<{currentProperty.Name}>");
            else
                xmlBuilder.Append($"\t{tabulation}<{currentProperty.Name} {nameof(Type)}='{currentProperty.GetValue(currentObject).GetType().FullName}'>");
           
            if (list is not null)
            {
                foreach (var listElem in list)
                {
                    xmlBuilder.AppendLine($"\n\t\t{tabulation}<{listElem.GetType().FullName}>");
                    foreach (var listElemProperty in listElem.GetType().GetProperties())
                    {
                        Read(xmlBuilder, listElemProperty, listElem, tabulation + "\t\t");
                    }

                    xmlBuilder.Append($"\t\t{tabulation}</{listElem.GetType().FullName}>");
                }

                xmlBuilder.Append($"\n");
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
                    var innerObject = currentProperty.GetValue(currentObject);
                    if (innerObject is not null)
                    {
                        xmlBuilder.AppendLine();
                        foreach (var innerProperty in innerObject.GetType().GetProperties())
                        {
                            Read(xmlBuilder, innerProperty, innerObject, tabulation + "\t");
                        }
                    }
                }
            }

            xmlBuilder.AppendLine($"\t{tabulation}</{currentProperty.Name}>");
        }
    }
}
