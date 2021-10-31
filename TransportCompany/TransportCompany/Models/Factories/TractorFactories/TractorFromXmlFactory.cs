using System;
using System.Xml;
using TransportCompanyLib.Models.SemitrailerTractors;

namespace TransportCompanyLib.Models.Factories.TractorFactories
{
    public class TractorFromXmlFactory<T> : IFromXmlFactory<T> where T : SemitrailerTractorBase
    {
        public T Create(XmlNode xmlNode)
        {
            float maxSemitrailerWeight = float.Parse(xmlNode[nameof(SemitrailerTractorBase.MaxSemitrailerWeight)].InnerText);
            T tractor = (T)Activator.CreateInstance(typeof(T), maxSemitrailerWeight);
            return tractor;
        }
    }
}
