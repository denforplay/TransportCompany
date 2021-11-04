using System;
using System.Xml;
using TransportCompanyLib.Models.Configurations;
using TransportCompanyLib.Models.Semitrailers;

namespace TransportCompanyLib.Models.Factories.SemitrailerFactories
{
    public class FromXmlTiltSemitrailerFactory : IFromXmlFactory<TiltSemitrailer>
    {
        public TiltSemitrailer Create(XmlNode xmlNode)
        {
            float maxCarryingSemitrailerWeight = float.Parse(xmlNode[nameof(TiltSemitrailer.MaxCarryingWeight)].InnerText);
            float maxCarryingSemitrailerVolume = float.Parse(xmlNode[nameof(TiltSemitrailer.MaxCarryingVolume)].InnerText);
            TiltSemitrailer tiltSemitrailer = new(maxCarryingSemitrailerWeight, maxCarryingSemitrailerVolume);
            foreach (XmlNode product in xmlNode[nameof(TiltSemitrailer.SemitrailerProducts)].ChildNodes)
            {
                Type productType = Type.GetType(product.Name);
                tiltSemitrailer.Load(FactoriesConfiguration.ProductsFactories[productType].Create(product), 1);
            }

            return tiltSemitrailer;
        }
    }
}
