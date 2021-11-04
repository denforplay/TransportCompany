using System;
using System.Xml;
using TransportCompanyLib.Models.Configurations;

namespace TransportCompanyLib.Models.Factories.AutoparkFactory
{
    /// <summary>
    /// Factory that create autopark from xml node
    /// </summary>
    public sealed class AutoparkFromXmlFactory : IFromXmlFactory<Autopark>
    {
        /// <summary>
        /// Create instance of autopark from xml data
        /// </summary>
        /// <param name="xmlNode">Xml data from which create autopark</param>
        /// <returns>Instance of autopark</returns>
        public Autopark Create(XmlNode xmlNode)
        {
            Autopark autopark = new();
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
