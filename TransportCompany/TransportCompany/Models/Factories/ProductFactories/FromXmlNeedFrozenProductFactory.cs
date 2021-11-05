using System;
using System.Xml;
using TransportCompanyLib.Models.Products.NeedColdProducts;

namespace TransportCompanyLib.Models.Factories.ProductFactories
{
    /// <summary>
    /// Factory to create need frozen product from xml
    /// </summary>
    /// <typeparam name="T">Type of frozen product</typeparam>
    public sealed class FromXmlNeedFrozenProductFactory<T> : IFromXmlFactory<T> where T : NeedColdProductBase
    {
        /// <summary>
        /// Returns instance of need froze product from xml data
        /// </summary>
        /// <param name="xmlNode">Xml data from which create product</param>
        /// <returns>Instance of need froze product</returns>
        public T Create(XmlNode xmlNode)
        {
            float productWeight = float.Parse(xmlNode[nameof(NeedColdProductBase.WeightPerProduct)].InnerText);
            float productVolume = float.Parse(xmlNode[nameof(NeedColdProductBase.VolumePerProduct)].InnerText);
            var temperatureLimits = xmlNode[nameof(NeedColdProductBase.TemperatureLimit)];
            float lowerTemperature = float.Parse(temperatureLimits[nameof(TemperatureLimit.LowerTemperature)].InnerText);
            float higherTemperature = float.Parse(temperatureLimits[nameof(TemperatureLimit.HigherTemperature)].InnerText);
            T needFrozeProduct = (T)Activator.CreateInstance(typeof(T), productWeight, productVolume, new TemperatureLimit(lowerTemperature, higherTemperature));
            return needFrozeProduct;
        }
    }
}
