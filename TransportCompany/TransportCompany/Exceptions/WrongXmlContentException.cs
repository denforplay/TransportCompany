using System;

namespace TransportCompanyLib.Exceptions
{
    /// <summary>
    /// Class realize exception class, thrown if can't read object from xml
    /// </summary>
    public sealed class WrongXmlContentException : Exception
    {
        /// <summary>
        /// Wrong xml content exception constructor
        /// </summary>
        public WrongXmlContentException()
        {
        }

        /// <summary>
        /// Wrong xml content exception message
        /// </summary>
        public override string Message => base.Message;
    }
}
