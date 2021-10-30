using System;
using System.Collections.Generic;
using System.Xml;

namespace TransportCompanyLib.Models.Factories
{
    public interface IFromXmlFactory<out T>
    {
        public T Create(XmlNode xmlDocument);
    }
}
