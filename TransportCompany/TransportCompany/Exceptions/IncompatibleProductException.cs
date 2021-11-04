using System;

namespace TransportCompanyLib.Exceptions
{
    /// <summary>
    /// Class realize exception class, thrown if products incompatible
    /// </summary>
    public sealed class IncompatibleProductException : Exception
    {
        private string _loadProductType;
        private string _neededProductType;

        /// <summary>
        /// Incompatible product exception contructor
        /// </summary>
        /// <param name="loadProductType">Load product type in string</param>
        /// <param name="neededProductType">Need product type in string</param>
        public IncompatibleProductException(string loadProductType, string neededProductType)
        {
            _loadProductType = loadProductType;
            _neededProductType = neededProductType;
        }

        /// <summary>
        /// Exception message
        /// </summary>
        public override string Message => $"Failed to load product with type {_loadProductType}. You need product with type {_neededProductType}";
    }
}
