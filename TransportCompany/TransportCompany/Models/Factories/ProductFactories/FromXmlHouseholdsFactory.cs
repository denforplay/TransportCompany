using System;
using System.Xml;
using TransportCompanyLib.Models.Products.HouseholdGoods;

namespace TransportCompanyLib.Models.Factories.ProductFactories
{
    public class FromXmlHouseholdsFactory<T> : IFromXmlFactory<T> where T : HouseholdProductBase
    {
        /// <summary>
        /// Returns instance of household product factory from xml data
        /// </summary>
        /// <param name="xmlNode">Xml data from which create liqiud product</param>
        /// <returns>Returns household product base</returns>
        public T Create(XmlNode xmlNode)
        {
            float productWeight = float.Parse(xmlNode[nameof(HouseholdProductBase.WeightPerProduct)].InnerText);
            float productVolume = float.Parse(xmlNode[nameof(HouseholdProductBase.VolumePerProduct)].InnerText);
            T householdProduct = (T)Activator.CreateInstance(typeof(T), productWeight, productVolume);
            return householdProduct;
        }
    }
}
