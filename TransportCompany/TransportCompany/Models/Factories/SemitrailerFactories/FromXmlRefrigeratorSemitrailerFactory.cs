using System;
using System.Xml;
using System.Xml.Serialization;
using TransportCompanyLib.Models.Configurations;
using TransportCompanyLib.Models.Products.NeedColdProducts;
using TransportCompanyLib.Models.Semitrailers;

namespace TransportCompanyLib.Models.Factories.SemitrailerFactories
{
    public sealed class FromXmlRefrigeratorSemitrailerFactory : IFromXmlFactory<RefrigeratorSemitrailer>
    {
        public RefrigeratorSemitrailer Create(XmlNode xmlNode)
        {
            float maxCarryingSemitrailerWeight = float.Parse(xmlNode[nameof(RefrigeratorSemitrailer.MaxCarryingWeight)].InnerText);
            float maxCarryingSemitrailerVolume = float.Parse(xmlNode[nameof(RefrigeratorSemitrailer.MaxCarryingVolume)].InnerText);
            float lowerRefrigeratorTemperature = float.Parse(xmlNode[nameof(RefrigeratorSemitrailer.LowerTemperature)].InnerText);
            float higherRefrigeratorTemperature = float.Parse(xmlNode[nameof(RefrigeratorSemitrailer.HighTemperature)].InnerText);
            RefrigeratorSemitrailer refrigeratorSemitrailer = new RefrigeratorSemitrailer(maxCarryingSemitrailerWeight, maxCarryingSemitrailerVolume, lowerRefrigeratorTemperature, higherRefrigeratorTemperature);
            foreach (XmlNode product in xmlNode[nameof(RefrigeratorSemitrailer.SemitrailerProducts)].ChildNodes)
            {
                Type productType = Type.GetType(product.Name);
                refrigeratorSemitrailer.Load(FactoriesConfiguration.ProductsFactories[productType].Create(product), 1);
            }

            return refrigeratorSemitrailer;
        }
    }
}
