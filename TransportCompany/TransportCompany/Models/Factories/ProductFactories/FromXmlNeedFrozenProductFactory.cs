using System;
using System.Xml;
using TransportCompanyLib.Models.Products.NeedColdProducts;

namespace TransportCompanyLib.Models.Factories.ProductFactories
{
    public sealed class FromXmlNeedFrozenProductFactory<T> : IFromXmlFactory<T> where T : NeedColdProductBase
    {
        public T Create(XmlNode xmlNode)
        {
            float productWeight = float.Parse(xmlNode[nameof(NeedColdProductBase.WeightPerProduct)].InnerText);
            float productVolume = float.Parse(xmlNode[nameof(NeedColdProductBase.VolumePerProduct)].InnerText);
            float lowerTemperature = float.Parse(xmlNode[nameof(NeedColdProductBase.LowerTemperature)].InnerText);
            float higherTemperature = float.Parse(xmlNode[nameof(NeedColdProductBase.HigherTemperature)].InnerText);
            T needFrozeProduct = (T)Activator.CreateInstance(typeof(T), productWeight, productVolume, lowerTemperature, higherTemperature);
            return needFrozeProduct;
        }
    }
}
