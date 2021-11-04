using System;

namespace TransportCompanyLib.Exceptions
{
    public class IncompatibleProductException : Exception
    {
        private string _loadProductType;
        private string _neededProductType;

        public IncompatibleProductException(string loadProductType, string neededProductType)
        {
            _loadProductType = loadProductType;
            _neededProductType = neededProductType;
        }

        public override string Message => $"Failed to load product with type {_loadProductType}. You need product with type {_neededProductType}";
    }
}
