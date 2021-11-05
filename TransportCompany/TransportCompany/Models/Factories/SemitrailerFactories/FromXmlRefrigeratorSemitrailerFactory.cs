using System;
using System.Xml;
using TransportCompanyLib.Models.Configurations;
using TransportCompanyLib.Models.Semitrailers;

namespace TransportCompanyLib.Models.Factories.SemitrailerFactories
{
    /// <summary>
    /// Factory to create refrigerator semitrailer from xml
    /// </summary>
    public sealed class FromXmlRefrigeratorSemitrailerFactory : IFromXmlFactory<RefrigeratorSemitrailer>
    {
        /// <summary>
        /// Create instance of refrigerator semitrailer from xml data
        /// </summary>
        /// <param name="xmlNode">Xml data from which create refrigerator semitrailer instance</param>
        /// <returns>Refrigerator semitrailer</returns>
        public RefrigeratorSemitrailer Create(XmlNode xmlNode)
        {
            float maxCarryingSemitrailerWeight = float.Parse(xmlNode[nameof(RefrigeratorSemitrailer.MaxCarryingWeight)].InnerText);
            float maxCarryingSemitrailerVolume = float.Parse(xmlNode[nameof(RefrigeratorSemitrailer.MaxCarryingVolume)].InnerText);
            var temperatureLimits = xmlNode[nameof(RefrigeratorSemitrailer.TemperatureLimit)];
            float lowerRefrigeratorTemperature = float.Parse(temperatureLimits[nameof(TemperatureLimit.LowerTemperature)].InnerText);
            float higherRefrigeratorTemperature = float.Parse(temperatureLimits[nameof(TemperatureLimit.HigherTemperature)].InnerText);
            RefrigeratorSemitrailer refrigeratorSemitrailer = new(maxCarryingSemitrailerWeight, maxCarryingSemitrailerVolume, new TemperatureLimit(lowerRefrigeratorTemperature, higherRefrigeratorTemperature));
            foreach (XmlNode product in xmlNode[nameof(RefrigeratorSemitrailer.SemitrailerProducts)].ChildNodes)
            {
                Type productType = Type.GetType(product.Name);
                refrigeratorSemitrailer.Load(FactoriesConfiguration.ProductsFactories[productType].Create(product), 1);
            }

            return refrigeratorSemitrailer;
        }
    }
}
