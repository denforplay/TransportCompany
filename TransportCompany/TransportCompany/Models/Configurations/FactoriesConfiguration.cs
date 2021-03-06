using System;
using System.Collections.Generic;
using TransportCompanyLib.Models.Factories;
using TransportCompanyLib.Models.Factories.ProductFactories;
using TransportCompanyLib.Models.Factories.SemitrailerFactories;
using TransportCompanyLib.Models.Factories.TractorFactories;
using TransportCompanyLib.Models.Products;
using TransportCompanyLib.Models.Products.FuelProducts;
using TransportCompanyLib.Models.Products.HouseholdGoods.HouseholdChemicals;
using TransportCompanyLib.Models.Products.NeedColdProducts;
using TransportCompanyLib.Models.Semitrailers;
using TransportCompanyLib.Models.SemitrailerTractors;

namespace TransportCompanyLib.Models.Configurations
{
    /// <summary>
    /// Class container - contains dictionaries of factories
    /// </summary>
    internal static class FactoriesConfiguration
    {
        /// <summary>
        /// Product factories
        /// </summary>
        public static Dictionary<Type, IFromXmlFactory<ProductBase>> ProductsFactories = new()
        {
            { typeof(DieselFuel), new FromXmlLiquidFactory<DieselFuel>() },
            { typeof(OctanePetrol_95), new FromXmlLiquidFactory<OctanePetrol_95>() },
            { typeof(Fish), new FromXmlNeedFrozenProductFactory<Fish>() },
            { typeof(Milk), new FromXmlNeedFrozenProductFactory<Milk>() },
            { typeof(Yogurt), new FromXmlNeedFrozenProductFactory<Yogurt>() },
            { typeof(Detergent), new FromXmlHouseholdsFactory<Detergent>() },
            { typeof(WashingPowder), new FromXmlHouseholdsFactory<WashingPowder>() }
        };

        /// <summary>
        /// Semitrailer factories
        /// </summary>
        public static Dictionary<Type, IFromXmlFactory<SemitrailerBase>> SemitrailerFactories = new()
        {
            { typeof(RefrigeratorSemitrailer), new FromXmlRefrigeratorSemitrailerFactory() },
            { typeof(TankSemitrailer), new FromXmlTankSemitrailerFactory() },
            { typeof(TiltSemitrailer), new FromXmlTiltSemitrailerFactory() }
        };

        /// <summary>
        /// Tractors factories
        /// </summary>
        public static Dictionary<Type, IFromXmlFactory<SemitrailerTractorBase>> TractorsFactories = new()
        {
            { typeof(MANTractor), new FromXmlTractorFactory<MANTractor>() },
        };
    }
}
