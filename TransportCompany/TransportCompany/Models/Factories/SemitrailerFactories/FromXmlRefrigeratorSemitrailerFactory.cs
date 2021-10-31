using System;
using System.Xml;
using System.Xml.Serialization;
using TransportCompanyLib.Models.Products.NeedColdProducts;
using TransportCompanyLib.Models.Semitrailers;

namespace TransportCompanyLib.Models.Factories.SemitrailerFactories
{
    public sealed class FromXmlRefrigeratorSemitrailerFactory : IFromXmlFactory<RefrigeratorSemitrailer>
    {
        public RefrigeratorSemitrailer Create(XmlNode xmlNode)
        {
            float maxCarryingSemitrailerWeight = float.Parse(xmlNode[nameof(RefrigeratorSemitrailer.MaxCarryingWeight)].InnerText);
            float lowerRefrigeratorTemperature = float.Parse(xmlNode[nameof(RefrigeratorSemitrailer.LowerTemperature)].InnerText);
            float higherRefrigeratorTemperature = float.Parse(xmlNode[nameof(RefrigeratorSemitrailer.HighTemperature)].InnerText);
            RefrigeratorSemitrailer refrigeratorSemitrailer = new RefrigeratorSemitrailer(maxCarryingSemitrailerWeight, lowerRefrigeratorTemperature, higherRefrigeratorTemperature);
            foreach (XmlNode product in xmlNode[nameof(RefrigeratorSemitrailer.SemitrailerProducts)].ChildNodes)
            {
                Type productType = Type.GetType(product.Name);
                float productWeight = float.Parse(product[nameof(NeedColdProductBase.WeightPerProduct)].InnerText);
                float lowerTemperature = float.Parse(product[nameof(NeedColdProductBase.LowerTemperature)].InnerText);
                float highTemperature = float.Parse(product[nameof(NeedColdProductBase.HigherTemperature)].InnerText);
                refrigeratorSemitrailer.Load(Activator.CreateInstance(productType, productWeight, lowerTemperature, highTemperature) as NeedColdProductBase, 1);
            }

            return refrigeratorSemitrailer;
        }
    }
}
