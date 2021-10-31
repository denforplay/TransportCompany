using System;
using System.Xml;
using TransportCompanyLib.Models.Products.FuelProducts;

namespace TransportCompanyLib.Models.Factories.ProductFactories
{
    public sealed class FromXmlLiquidFactory<T> : IFromXmlFactory<T> where T : LiquidProductBase
    {
        public T Create(XmlNode xmlNode)
        {
            float productWeight = float.Parse(xmlNode[nameof(LiquidProductBase.WeightPerProduct)].InnerText);
            float productVolume = float.Parse(xmlNode[nameof(LiquidProductBase.VolumePerProduct)].InnerText);
            T fuelProduct = (T)Activator.CreateInstance(typeof(T), productWeight, productVolume);
            return fuelProduct;
        }
    }
}
