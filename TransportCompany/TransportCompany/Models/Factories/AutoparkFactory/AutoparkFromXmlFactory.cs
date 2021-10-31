using System;
using System.Collections.Generic;
using System.Xml;
using TransportCompanyLib.Models.Factories.SemitrailerFactories;
using TransportCompanyLib.Models.Factories.TractorFactories;
using TransportCompanyLib.Models.Semitrailers;
using TransportCompanyLib.Models.SemitrailerTractors;

namespace TransportCompanyLib.Models.Factories.AutoparkFactory
{
    public sealed class AutoparkFromXmlFactory : IFromXmlFactory<Autopark>
    {
        private Dictionary<Type, IFromXmlFactory<SemitrailerBase>> SemitrailerFactories = new()
        {
            { typeof(RefrigeratorSemitrailer), new FromXmlRefrigeratorSemitrailerFactory() },
            { typeof(TankSemitrailer), new FromXmlTankSemitrailerFactory() },
        };

        private Dictionary<Type, IFromXmlFactory<SemitrailerTractorBase>> TractorsFactories = new()
        {
            { typeof(TankSemitrailer), new FromXmlTractorFactory<MANTractor>() },
        };

        public Autopark Create(XmlNode xmlNode)
        {
            Autopark autopark = new Autopark();
            foreach(XmlNode semitrailer in xmlNode[nameof(Autopark.Semitrailers)].ChildNodes)
            {
                autopark.AddSemitrailer(SemitrailerFactories[Type.GetType(semitrailer.Name)].Create(semitrailer));
            }

            foreach (XmlNode tractor in xmlNode[nameof(Autopark.SemitrailerTractors)].ChildNodes)
            {
                autopark.AddTractor(TractorsFactories[Type.GetType(tractor.Name)].Create(tractor));
            }
            return autopark;
        }
    }
}
