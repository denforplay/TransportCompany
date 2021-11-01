using System.Collections.Generic;
using TransportCompanyLib.Models.Products;
using TransportCompanyLib.Models.Semitrailers;
using TransportCompanyLib.Models.SemitrailerTractors;

namespace TransportCompanyLib.Models
{
    /// <summary>
    /// Represents autopark
    /// </summary>
    public sealed class Autopark
    {
        private List<SemitrailerTractorBase> _semitrailerTractors;
        private List<SemitrailerBase> _semitrailers;

        /// <summary>
        /// Autork semitrailer tractors
        /// </summary>
        public List<SemitrailerTractorBase> SemitrailerTractors => _semitrailerTractors;

        /// <summary>
        /// Autopark semitrailers
        /// </summary>
        public List<SemitrailerBase> Semitrailers => _semitrailers;

        /// <summary>
        /// Autopark constructor
        /// </summary>
        public Autopark()
        {
            _semitrailerTractors = new List<SemitrailerTractorBase>();
            _semitrailers = new List<SemitrailerBase>();
        }

        /// <summary>
        /// Add tractor in autopark
        /// </summary>
        /// <param name="semitrailerTractorBase"></param>
        public void AddTractor(SemitrailerTractorBase semitrailerTractorBase)
        {
            _semitrailerTractors.Add(semitrailerTractorBase);
        }

        /// <summary>
        /// Add semitrailer in autopark
        /// </summary>
        /// <param name="semitrailer">Semitrailer to add in autopark</param>
        public void AddSemitrailer(SemitrailerBase semitrailer)
        {
            _semitrailers.Add(semitrailer);
        }

        /// <summary>
        /// Find semitrailer of current type in list of semitrailers
        /// </summary>
        /// <typeparam name="T">Type of semitrailer to find</typeparam>
        /// <returns>Semitrailer of type T</returns>
        public T FindSemitrailer<T>() where T : SemitrailerBase
        {
            return _semitrailers.Find(trailer => trailer.GetType() == typeof(T)) as T;
        }

        /// <summary>
        /// Find list of semitrailers that carry current type of product
        /// </summary>
        /// <typeparam name="T">Type of product to find in semitrailers</typeparam>
        /// <returns>List of histches tractor-semitrailer that carry product of type T</returns>
        public List<SemitrailerTractorBase> FindAllHitchesForProduct<T>() where T : ProductBase
        {
            return _semitrailerTractors.FindAll(tractor => tractor.Semitrailer != null && tractor.Semitrailer.SemitrailerProducts.Find(x => x.GetType() == typeof(T)) != null);
        }

        /// <summary>
        /// Find all hitches in what can be loaded products
        /// </summary>
        /// <returns>List of tractors with connected semitrailers that can be loaded</returns>
        public List<SemitrailerTractorBase> FindAllHitchesThatCanBeLoaded()
        {
            return _semitrailerTractors.FindAll(tractor => tractor.Semitrailer != null && tractor.Semitrailer.CurrentProductsWeight < tractor.Semitrailer.MaxCarryingWeight);
        }
    }
}
