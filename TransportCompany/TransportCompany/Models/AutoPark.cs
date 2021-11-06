using System.Collections.Generic;
using System.Linq;
using TransportCompanyLib.Extensions;
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
        public IReadOnlyList<SemitrailerTractorBase> SemitrailerTractors => _semitrailerTractors;

        /// <summary>
        /// Autopark semitrailers
        /// </summary>
        public IReadOnlyList<SemitrailerBase> Semitrailers => _semitrailers;

        /// <summary>
        /// Autopark constructor
        /// </summary>
        public Autopark()
        {
            _semitrailerTractors = new List<SemitrailerTractorBase>();
            _semitrailers = new List<SemitrailerBase>();
        }

        /// <summary>
        /// Method finds list of couplings, consists of semitrailer and tractor that already connected
        /// </summary>
        /// <returns>List of couplings</returns>
        public List<Coupling> GetCurrentCouplings()
        {
            List<Coupling> couplings = new List<Coupling>();
            foreach (var tractor in _semitrailerTractors)
            {
                if (tractor.Semitrailer is not null)
                {
                    couplings.Add(new Coupling(tractor, tractor.Semitrailer));
                }
            }

            return couplings;
        }

        /// <summary>
        /// Method finds list of couplings, consists of semitrailer and tractor that can be connected
        /// </summary>
        /// <returns>List of couplings</returns>
        public List<Coupling> GetPossibleCouplings()
        {
            List<Coupling> currentCouplings = GetCurrentCouplings();
            List<Coupling> possibleCouplings = new List<Coupling>();

            for (int i = 0; i < _semitrailerTractors.Count; i++)
            {
                if (_semitrailerTractors[i].Semitrailer is not null)
                    continue;

                for (int j = 0; j < _semitrailers.Count; j++)
                {
                    if (currentCouplings.Any(x => x.Semitrailer == _semitrailers[j]))
                        continue;

                    possibleCouplings.Add(new Coupling(_semitrailerTractors[i], _semitrailers[j]));
                }
            }

            return possibleCouplings;
        }

        /// <summary>
        /// Add tractor in autopark
        /// </summary>
        /// <param name="semitrailerTractorBase">Tractor to add in autopark</param>
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
        /// Find semitrailer by template
        /// </summary>
        /// <typeparam name="T">Typeof semitrailer to find</typeparam>
        /// <param name="semitrailerTemplate">Semitrailer template</param>
        /// <returns>Finded semitrailer of type T</returns>
        public SemitrailerBase FindSemitrailerByTemplate<T>(T semitrailerTemplate) where T : SemitrailerBase
        {
            return _semitrailers.Find(semitrailer => semitrailer is T semitrailerType && semitrailerType.Equals(semitrailerTemplate));
        }

        /// <summary>
        /// Find list of semitrailers that carry current type of product
        /// </summary>
        /// <typeparam name="T">Type of product to find in semitrailers</typeparam>
        /// <returns>List of histches tractor-semitrailer that carry product of type T</returns>
        public List<Coupling> FindAllCouplingsForProduct<T>() where T : ProductBase
        {
            return GetCurrentCouplings().FindAll(coupling => coupling.Semitrailer != null && coupling.Semitrailer.SemitrailerProducts.Find(x => x.GetType() == typeof(T)) != null);
        }

        /// <summary>
        /// Find all hitches in what can be loaded products
        /// </summary>
        /// <returns>List of tractors with connected semitrailers that can be loaded</returns>
        public List<Coupling> FindAllCouplingsThatCanBeLoaded()
        {
            return GetCurrentCouplings().FindAll(coupling => coupling.Tractor.MaxSemitrailerWeight > coupling.Semitrailer.CurrentProductsWeight
            && coupling.Semitrailer.MaxCarryingWeight != coupling.Semitrailer.CurrentProductsWeight);
        }

        /// <summary>
        /// Find all hitches in what can be loaded products fully
        /// </summary>
        /// <returns>List of tractors with connected semitrailers that can be loaded fully</returns>
        public List<Coupling> FindAllCouplingsThatCanBeLoadedFully()
        {
            return GetCurrentCouplings().FindAll(coupling => coupling.Semitrailer.MaxCarryingWeight <= coupling.Tractor.MaxSemitrailerWeight
            && coupling.Semitrailer.MaxCarryingWeight != coupling.Semitrailer.CurrentProductsWeight);
        }

        public override bool Equals(object obj)
        {
            if (obj is Autopark autopark)
            {
                return Semitrailers.IsEqual(autopark.Semitrailers)
                    && SemitrailerTractors.IsEqual(autopark.SemitrailerTractors);
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 195;
            hash += Semitrailers.Sum(x => x.GetHashCode());
            hash += SemitrailerTractors.Sum(x => x.GetHashCode());
            return hash;
        }

        public override string ToString()
        {
            return $"{GetType().Name}";
        }
    }
}
