using ProductsLib.Models.Products;
using System;
using System.Linq;
using System.Text;
using TransportCompanyLib.Models.Semitrailers;
using XmlDataWorker.Models;

namespace TransportCompanyLib.Models.SemitrailerTractors
{
    public abstract class SemitrailerTractorBase : IXmlable
    {
        private int _maxSemitrailerWeight;
        private SemitrailerBase _semitrailer;
        public SemitrailerBase Semitrailer => _semitrailer;

        public SemitrailerTractorBase(int maxSemitrailerWeight)
        {
            if (maxSemitrailerWeight <= 0)
            {
                throw new ArgumentException(nameof(maxSemitrailerWeight));
            }

            _maxSemitrailerWeight = maxSemitrailerWeight;
        }

        public void ConnectSemitrailer(SemitrailerBase semitrailer)
        {
            if (semitrailer.MaxCarryingWeight > _maxSemitrailerWeight)
            {
                throw new ArgumentException("Semitrailer can care more than semitrailer tractor can load", nameof(semitrailer));
            }

            _semitrailer = semitrailer;
        }

        public string WriteInXml()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append($"<{GetType().Name}>\n");
            if (Semitrailer is not null)
            {
                xml.Append(Semitrailer.WriteInXml());
            }
            xml.Append($"</{GetType().Name}>\n");
            return xml.ToString();
        }

        public void Factory()
        {
            
        }
    }
}
