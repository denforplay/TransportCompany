using ProductsLib.Models.Products;
using System.Collections.Generic;
using TransportCompanyLib.Models.Semitrailers;
using TransportCompanyLib.Models.SemitrailerTractors;

namespace TransportCompanyLib.Models
{
    public sealed class AutoPark
    {
        private List<SemitrailerTractorBase> _semitrailerTractors;
        private List<SemitrailerBase<ProductBase>> _semitrailers;
    }
}
