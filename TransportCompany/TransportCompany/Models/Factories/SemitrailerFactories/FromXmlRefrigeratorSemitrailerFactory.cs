using System;
using System.Xml;
using TransportCompanyLib.Models.Products.NeedColdProducts;
using TransportCompanyLib.Models.Semitrailers;

namespace TransportCompanyLib.Models.Factories.SemitrailerFactories
{
    public sealed class FromXmlRefrigeratorSemitrailerFactory : IFromXmlFactory<RefrigeratorSemitrailer>
    {
        public RefrigeratorSemitrailer Create(XmlNode xmlNode)
        {
            float maxProducts = float.Parse(xmlNode["MaxCarryingWeight"].InnerText);
            float lowerRefrigeratorTemperature = float.Parse(xmlNode["LowerTemperature"].InnerText);
            float higherRefrigeratorTemperature = float.Parse(xmlNode["HighTemperature"].InnerText);
            RefrigeratorSemitrailer refrigeratorSemitrailer = new RefrigeratorSemitrailer(maxProducts, lowerRefrigeratorTemperature, higherRefrigeratorTemperature);
            foreach (XmlNode product in xmlNode["SemitrailerProducts"].ChildNodes)
            {
                Type productType = Type.GetType(product.Name);
                float productWeight = float.Parse(product["WeightPerProduct"].InnerText);
                float lowerTemperature = float.Parse(product["LowerTemperature"].InnerText);
                float highTemperature = float.Parse(product["HigherTemperature"].InnerText);
                refrigeratorSemitrailer.Load(Activator.CreateInstance(productType, productWeight, lowerTemperature, highTemperature) as NeedColdProductBase, 1);
            }

            return refrigeratorSemitrailer;
        }

    }
}
