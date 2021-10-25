using System.Collections.Generic;
using TransportCompanyLib.Models.Semitrailers;
using TransportCompanyLib.Models.SemitrailerTractors;

namespace TransportCompanyLib.Models
{
    public sealed class TransportCompany
    {
        private List<SemitrailerTractorBase> _semitrailerTractors;
        private List<SemitrailerBase> _semitrailers;
    }
}
