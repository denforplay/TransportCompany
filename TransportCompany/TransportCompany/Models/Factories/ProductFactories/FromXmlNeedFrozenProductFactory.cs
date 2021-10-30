using System;
using System.Xml;
using TransportCompanyLib.Models.Products.NeedColdProducts;

namespace TransportCompanyLib.Models.Factories.ProductFactories
{
    public sealed class FromXmlNeedFrozenProductFactory<T> : IFromXmlFactory<T> where T : NeedColdProductBase
    {
        public T Create(XmlNode xmlNode)
        {
            float productWeight = float.Parse(xmlNode["WeightPerProduct"].InnerText);
            float lowerTemperature = float.Parse(xmlNode["LowerTemperature"].InnerText);
            float higherTemperature = float.Parse(xmlNode["HigherTemperature"].InnerText);
            T needFrozeProduct = (T)Activator.CreateInstance(typeof(T), productWeight, lowerTemperature, higherTemperature);
            return needFrozeProduct;
        }
    }
}
