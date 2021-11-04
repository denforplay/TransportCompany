using System;
using System.IO;
using TransportCompanyLib.Exceptions;
using TransportCompanyLib.Models.Factories;
using XmlDataWorker.Models.DataLoaders;
using XmlDataWorker.Models.DataSavers;

namespace XmlDataWorker.Models.DataSaveLoaders
{
    /// <summary>
    /// Xml save loader
    /// </summary>
    /// <typeparam name="T">Type of reading or writing object</typeparam>
    public sealed class XmlSaveLoader<T> where T : class
    {
        private string _filepath = Directory.GetCurrentDirectory() + "/autopark.xml";
        private XmlLoaderBase _dataLoader;
        private XmlSaverBase<T> _dataSaver;
        private IFromXmlFactory<T> _xmlFactory;

        /// <summary>
        /// Xml save loader constructor
        /// </summary>
        /// <param name="dataLoader">Xml data loader</param>
        /// <param name="dataSaver">Xml data saver</param>
        /// <param name="fromXmlFactory">Factory to create object from xml</param>
        public XmlSaveLoader(XmlLoaderBase dataLoader, XmlSaverBase<T> dataSaver, IFromXmlFactory<T> fromXmlFactory, string filepath = null)
        {
            _filepath = filepath ?? _filepath;
            _dataLoader = dataLoader;
            _dataSaver = dataSaver;
            _xmlFactory = fromXmlFactory;
        }

        /// <summary>
        /// Saving object in xml
        /// </summary>
        /// <param name="objectToSave">Object to save in xml file</param>
        public void Save(T objectToSave)
        {
            if (objectToSave is null)
                throw new ArgumentNullException(nameof(objectToSave));

            _dataSaver.SaveData(objectToSave, _filepath);
        }

        /// <summary>
        /// Load object from xml
        /// </summary>
        /// <returns>Object of type</returns>
        public T Load()
        {
            var test = _dataLoader.LoadData(_filepath);
            T readedObject;
            try
            {
                readedObject = _xmlFactory.Create(test[typeof(T).Name]);
            }
            catch
            {
                throw new WrongXmlContentException();
            }

            return readedObject;
        }
    }
}