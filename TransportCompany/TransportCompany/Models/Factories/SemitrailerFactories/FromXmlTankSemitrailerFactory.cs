using System;
using System.Xml;
using TransportCompanyLib.Models.Configurations;
using TransportCompanyLib.Models.Products.FuelProducts;
using TransportCompanyLib.Models.Semitrailers;

namespace TransportCompanyLib.Models.Factories.SemitrailerFactories
{
    public sealed class FromXmlTankSemitrailerFactory : IFromXmlFactory<TankSemitrailer>
    {
        public TankSemitrailer Create(XmlNode xmlNode)
        {
            float maxProducts = float.Parse(xmlNode[nameof(TankSemitrailer.MaxCarryingWeight)].InnerText);
            TankSemitrailer tankSemitrailer = new TankSemitrailer(maxProducts);
            foreach (XmlNode product in xmlNode[nameof(TankSemitrailer.SemitrailerProducts)].ChildNodes)
            {
                Type productType = Type.GetType(product.Name);
                tankSemitrailer.Load(FactoriesConfiguration.ProductsFactories[productType].Create(product), 1);
            }

            return tankSemitrailer;
        }
    }
}
