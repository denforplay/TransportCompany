using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TransportCompanyLib.Models.Factories.ProductFactories;
using TransportCompanyLib.Models.Products.FuelProducts;
using TransportCompanyLib.Models.Products.NeedColdProducts;
using TransportCompanyLib.Models.Semitrailers;

namespace TransportCompanyLib.Models.Factories.SemitrailerFactories
{
    public sealed class FromXmlTankSemitrailerFactory : IFromXmlFactory<TankSemitrailer>
    {
        public TankSemitrailer Create(XmlNode xmlNode)
        {
            float maxProducts = float.Parse(xmlNode["MaxCarryingWeight"].InnerText);
            TankSemitrailer tankSemitrailer = new TankSemitrailer(maxProducts);
            foreach (XmlNode product in xmlNode["SemitrailerProducts"].ChildNodes)
            {
                Type productType = Type.GetType(product.Name);
                float productWeight = float.Parse(product["WeightPerProduct"].InnerText);
                tankSemitrailer.Load(Activator.CreateInstance(productType, productWeight) as LiquidProductBase, 1);
            }

            return tankSemitrailer;
        }
    }
}
