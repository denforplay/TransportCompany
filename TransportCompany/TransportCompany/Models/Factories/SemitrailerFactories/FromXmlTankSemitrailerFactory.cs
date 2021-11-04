using System;
using System.Xml;
using TransportCompanyLib.Models.Configurations;
using TransportCompanyLib.Models.Semitrailers;

namespace TransportCompanyLib.Models.Factories.SemitrailerFactories
{
    /// <summary>
    /// Factory to create tank semitrailer from xml
    /// </summary>
    public sealed class FromXmlTankSemitrailerFactory : IFromXmlFactory<TankSemitrailer>
    {
        /// <summary>
        /// Create instance of tank semitrailer from xml data
        /// </summary>
        /// <param name="xmlNode">Xml data from which create tank semitrailer</param>
        /// <returns>Instance of tank semitrailer</returns>
        public TankSemitrailer Create(XmlNode xmlNode)
        {
            float maxProducts = float.Parse(xmlNode[nameof(TankSemitrailer.MaxCarryingWeight)].InnerText);
            float maxVolume = float.Parse(xmlNode[nameof(TankSemitrailer.MaxCarryingVolume)].InnerText);
            TankSemitrailer tankSemitrailer = new(maxProducts, maxVolume);
            foreach (XmlNode product in xmlNode[nameof(TankSemitrailer.SemitrailerProducts)].ChildNodes)
            {
                Type productType = Type.GetType(product.Name);
                tankSemitrailer.Load(FactoriesConfiguration.ProductsFactories[productType].Create(product), 1);
            }

            return tankSemitrailer;
        }
    }
}
