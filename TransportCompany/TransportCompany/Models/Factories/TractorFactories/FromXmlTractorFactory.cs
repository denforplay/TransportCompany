using System;
using System.Xml;
using TransportCompanyLib.Models.Configurations;
using TransportCompanyLib.Models.SemitrailerTractors;

namespace TransportCompanyLib.Models.Factories.TractorFactories
{
    /// <summary>
    /// Tractor factory from xml
    /// </summary>
    /// <typeparam name="T">Type of tractor to create</typeparam>
    public sealed class FromXmlTractorFactory<T> : IFromXmlFactory<T> where T : SemitrailerTractorBase
    {
        /// <summary>
        /// Create tractor from xml data
        /// </summary>
        /// <param name="xmlNode">Xml data from which create tractor</param>
        /// <returns>Instance of tractor</returns>
        public T Create(XmlNode xmlNode)
        {
            float maxSemitrailerWeight = float.Parse(xmlNode[nameof(SemitrailerTractorBase.MaxSemitrailerWeight)].InnerText);
            var semitrailerNode = xmlNode[nameof(SemitrailerTractorBase.Semitrailer)];
            var semitrailer = FactoriesConfiguration.SemitrailerFactories[Type.GetType(semitrailerNode.GetAttribute(nameof(Type)))].Create(semitrailerNode);
            T tractor = (T)Activator.CreateInstance(typeof(T), maxSemitrailerWeight);
            tractor.ConnectSemitrailer(semitrailer);
            return tractor;
        }
    }
}
