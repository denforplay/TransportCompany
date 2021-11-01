using System.Xml;

namespace TransportCompanyLib.Models.Factories
{
    /// <summary>
    /// Interface provides functionality to create object from xml data
    /// </summary>
    /// <typeparam name="T">Type of object to create</typeparam>
    public interface IFromXmlFactory<out T>
    {
        /// <summary>
        /// Returns new instance of T object
        /// </summary>
        /// <param name="xmlNode">Xml nodes</param>
        /// <returns>New instance of T object</returns>
        public T Create(XmlNode xmlNode);
    }
}
