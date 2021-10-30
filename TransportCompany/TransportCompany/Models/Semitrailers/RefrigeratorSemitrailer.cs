﻿using System;
using System.Linq;
using TransportCompanyLib.Models.Products;
using TransportCompanyLib.Models.Products.NeedColdProducts;

namespace TransportCompanyLib.Models.Semitrailers
{
    public class RefrigeratorSemitrailer : SemitrailerBase
    {
        public float LowerTemperature { get; private set; }
        public float HighTemperature { get; private set; }

        public RefrigeratorSemitrailer(float maxCarryingWeight, float lowTemperature, float highTemperature) : base(maxCarryingWeight)
        {
            LowerTemperature = lowTemperature;
            HighTemperature = highTemperature;
        }

        public override void Load(ProductBase product, int count)
        {
            if (product is not NeedColdProductBase needColdProduct)
            {
                throw new ArgumentException("In refregerator you can load only products which need cold");
            }

            if (needColdProduct.LowerTemperature >= LowerTemperature && needColdProduct.HigherTemperature <= HighTemperature)
            {
                if (_semitrailerProducts.TrueForAll(pr => (pr is NeedColdProductBase coldPr) && needColdProduct.LowerTemperature >= coldPr.LowerTemperature && needColdProduct.HigherTemperature <= coldPr.HigherTemperature))
                {
                    base.Load(product, count);
                }
                else
                {
                    throw new ArgumentException("Product unconnactable with other products in refregerator");
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is RefrigeratorSemitrailer semitrailer)
            {
                return semitrailer.MaxCarryingWeight == this.MaxCarryingWeight
                       && semitrailer.SemitrailerProducts.Except(SemitrailerProducts).Count() == 0
                       && semitrailer.LowerTemperature == this.LowerTemperature
                       && semitrailer.HighTemperature == this.HighTemperature;
            }

            return false;
        }
    }
}
