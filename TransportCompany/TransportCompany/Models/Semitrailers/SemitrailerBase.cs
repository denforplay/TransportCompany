using System;
using System.Collections.Generic;
using System.Linq;
using TransportCompanyLib.Models.Products;

namespace TransportCompanyLib.Models.Semitrailers
{
    /// <summary>
    /// Semitrailer base
    /// </summary>
    public abstract class SemitrailerBase
    {
        protected List<ProductBase> _semitrailerProducts;
        private readonly float _maxCarryingWeight;
        private readonly float _maxCarryingVolume;

        /// <summary>
        /// Semitrailer constructor
        /// </summary>
        /// <param name="maxCarryingWeight">Max semitrailer carrying weight</param>
        /// <param name="maxCarryingVolume">Max semitrailer carrying volume</param>
        public SemitrailerBase(float maxCarryingWeight, float maxCarryingVolume)
        {
            if (maxCarryingWeight <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxCarryingWeight));
            }

            if (maxCarryingVolume <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxCarryingWeight));
            }

            _semitrailerProducts = new List<ProductBase>();
            _maxCarryingVolume = maxCarryingVolume;
            _maxCarryingWeight = maxCarryingWeight;
        }

        /// <summary>
        /// Current product weight in semitrailer
        /// </summary>
        public float CurrentProductsWeight => _semitrailerProducts.Sum(x => x.WeightPerProduct);

        /// <summary>
        /// Max carrying semitrailer weight
        /// </summary>
        public float MaxCarryingWeight => _maxCarryingWeight;

        /// <summary>
        /// Current carrying volume in semitrailer
        /// </summary>
        public float CurrentCarryingVolume => _semitrailerProducts.Sum(x => x.VolumePerProduct);

        /// <summary>
        /// Max carrying volume in semitrailer
        /// </summary>
        public float MaxCarryingVolume => _maxCarryingVolume;

        /// <summary>
        /// Products loaded in semitrailer
        /// </summary>
        public List<ProductBase> SemitrailerProducts => _semitrailerProducts;

        /// <summary>
        /// Method to load products in semitrailer
        /// </summary>
        /// <param name="product">Product to load</param>
        /// <param name="count">Count of product to load</param>
        public virtual void Load(ProductBase product, int count)
        {
            while (count-- > 0)
            {
                if (CurrentProductsWeight + product.WeightPerProduct <= MaxCarryingWeight
                    && CurrentCarryingVolume + product.VolumePerProduct <= MaxCarryingVolume)
                    _semitrailerProducts.Add(product);
                else
                    break;
            }
        }

        /// <summary>
        /// Method to unload products from semitrailer
        /// </summary>
        /// <param name="product">Product to unload</param>
        /// <param name="productCount">Count of products to unload</param>
        public void Unload(ProductBase product, int productCount)
        {
            while (productCount-- != 0 && _semitrailerProducts.Count != 0)
            {
                var findedProduct = _semitrailerProducts.Last(pr => pr.Equals(product));
                if (findedProduct is null) break;
                _semitrailerProducts.Remove(findedProduct);
            }
        }

        /// <summary>
        /// Remove all products from semitrailer
        /// </summary>
        public void UnloadAllProducts()
        {
            _semitrailerProducts.Clear();
        }

        /// <summary>
        /// Determines whether two object instances are equal
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>Returns true if object are equals, other returns not</returns>
        public override bool Equals(object obj)
        {
            if (obj is SemitrailerBase semitrailer)
            {
                return semitrailer.MaxCarryingWeight == this.MaxCarryingWeight
                       && !semitrailer.SemitrailerProducts.Except(SemitrailerProducts).Any();
            }

            return false;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object</returns>
        public override int GetHashCode()
        {
            int hash = 1221;
            hash += MaxCarryingWeight.GetHashCode() * 8;
            hash += SemitrailerProducts.Sum(x => x.GetHashCode() * 3);
            return hash;
        }

        /// <summary>
        /// Returns a string that represents the semitrailer.
        /// </summary>
        /// <returns>A string that represents the semitrailer</returns>
        public override string ToString()
        {
            return $"{GetType().Name} with loaded {CurrentProductsWeight}/{MaxCarryingWeight} weight and {CurrentCarryingVolume}/{MaxCarryingVolume}";
        }
    }
}
