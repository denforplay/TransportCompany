using System;
using System.Xml;
using TransportCompanyLib.Models.Products.FuelProducts;

namespace TransportCompanyLib.Models.Factories.ProductFactories
{
    /// <summary>
    /// Factory to create liqiid products from xml 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class FromXmlLiquidFactory<T> : IFromXmlFactory<T> where T : LiquidProductBase
    {
        /// <summary>
        /// Returns instance of liquid product from xml data
        /// </summary>
        /// <param name="xmlNode">Xml data from which create liqiud product</param>
        /// <returns>Returns luquid product base</returns>
        public T Create(XmlNode xmlNode)
        {
            float productWeight = float.Parse(xmlNode[nameof(LiquidProductBase.WeightPerProduct)].InnerText);
            float productVolume = float.Parse(xmlNode[nameof(LiquidProductBase.VolumePerProduct)].InnerText);
            T liquidProduct = (T)Activator.CreateInstance(typeof(T), productWeight, productVolume);
            return liquidProduct;
        }
    }
}
