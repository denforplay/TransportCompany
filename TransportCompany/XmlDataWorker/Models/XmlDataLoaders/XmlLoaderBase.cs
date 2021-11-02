using System.Xml;

namespace XmlDataWorker.Models.DataLoaders
{
    /// <summary>
    /// Class provides functionality to load xml data from file
    /// </summary>
    public abstract class XmlLoaderBase
    {
        /// <summary>
        /// Load data from file method
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <returns>Xml data</returns>
        public abstract XmlDocument LoadData(string path);
    }
}
