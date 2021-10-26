﻿using ProductsLib.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TransportCompanyLib.Models.Semitrailers
{
    public abstract class SemitrailerBase<T> where T : ProductBase
    {
        protected List<T> _semitrailerProducts;
        private float _maxCarryingWeight;
        public float CurrentProductsWeight => _semitrailerProducts.Sum(x => x.WeightPerProduct);
        public float MaxCarryingWeight => _maxCarryingWeight;

        public SemitrailerBase(float maxCarryingWeight)
        {
            if (maxCarryingWeight <= 0)
            {
                throw new ArgumentException(nameof(maxCarryingWeight));
            }

            _semitrailerProducts = new List<T>();
            _maxCarryingWeight = maxCarryingWeight;
        }

        /// <summary>
        /// Method to load product in semitrailer
        /// </summary>
        public abstract void Load(T product, int count);

        public void Unload(int productCount)
        {
            while(productCount-- != 0 && _semitrailerProducts.Count != 0)
            {
                var product = _semitrailerProducts.Last();
                _semitrailerProducts.Remove(product);
            }
        }
    }
}
