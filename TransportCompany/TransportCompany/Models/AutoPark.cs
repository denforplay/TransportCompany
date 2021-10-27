using ProductsLib.Models.Products;
using System.Collections.Generic;
using System.Text;
using TransportCompanyLib.Models.Semitrailers;
using TransportCompanyLib.Models.SemitrailerTractors;
using XmlDataWorker.Models;

namespace TransportCompanyLib.Models
{
    public sealed class Autopark : IXmlable
    {
        private List<SemitrailerTractorBase> _semitrailerTractors;
        private List<SemitrailerBase> _semitrailers;

        public void AutoPark()
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

        public string WriteInXml()
        {
           StringBuilder xmlView = new StringBuilder("<SemitrailerTractors>\n");
            for (int i = 0; i < _semitrailerTractors.Count; i++)
            {
            }
            xmlView.Append("</SemitrailerTractors>");
            return xmlView.ToString();
        }
    }
}
