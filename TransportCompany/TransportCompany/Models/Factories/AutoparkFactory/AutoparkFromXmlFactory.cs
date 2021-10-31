using System;
using System.Xml;
using TransportCompanyLib.Models.Configurations;

namespace TransportCompanyLib.Models.Factories.AutoparkFactory
{
    public sealed class AutoparkFromXmlFactory : IFromXmlFactory<Autopark>
    {
        public Autopark Create(XmlNode xmlNode)
        {
            Autopark autopark = new Autopark();
            foreach(XmlNode semitrailer in xmlNode[nameof(Autopark.Semitrailers)].ChildNodes)
            {
                autopark.AddSemitrailer(FactoriesConfiguration.SemitrailerFactories[Type.GetType(semitrailer.Name)].Create(semitrailer));
            }

            foreach (XmlNode tractor in xmlNode[nameof(Autopark.SemitrailerTractors)].ChildNodes)
            {
                autopark.AddTractor(FactoriesConfiguration.TractorsFactories[Type.GetType(tractor.Name)].Create(tractor));
            }
            return autopark;
        }
    }
}
