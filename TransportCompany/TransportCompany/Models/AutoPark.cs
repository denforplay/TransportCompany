using ProductsLib.Models.Products;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using TransportCompanyLib.Models.Semitrailers;
using TransportCompanyLib.Models.SemitrailerTractors;
using XmlDataWorker.Models;

namespace TransportCompanyLib.Models
{
    public sealed class Autopark
    {
        private List<SemitrailerTractorBase> _semitrailerTractors;
        private List<SemitrailerBase> _semitrailers;

        public List<SemitrailerTractorBase> SemitrailerTractors => _semitrailerTractors;
        public List<SemitrailerBase> Semitrailers => _semitrailers;

        public Autopark()
        {
            _semitrailerTractors = new List<SemitrailerTractorBase>();
            _semitrailers = new List<SemitrailerBase>();
        }

        public void AddTractor(SemitrailerTractorBase semitrailerTractorBase)
        {
            _semitrailerTractors.Add(semitrailerTractorBase);
        }

        public void AddSemitrailer(SemitrailerBase semitrailer)
        {
            _semitrailers.Add(semitrailer);
        }

        public void FindSemitrailer<T>() where T : SemitrailerBase
        {
            _semitrailers.Find(trailer => trailer.GetType() == typeof(T));
        }

        public List<SemitrailerTractorBase> FindAllHitchesForProduct<T>() where T : ProductBase
        {
            return _semitrailerTractors.FindAll(tractor => tractor.Semitrailer != null && tractor.Semitrailer.SemitrailerProducts.Find(x => x.GetType() == typeof(T)) != null);
        }

        public List<SemitrailerTractorBase> FindAllHitchesThatCanBeLoaded()
        {
            return _semitrailerTractors.FindAll(tractor => tractor.Semitrailer != null && tractor.Semitrailer.CurrentProductsWeight < tractor.Semitrailer.MaxCarryingWeight);
        }
    }
}
