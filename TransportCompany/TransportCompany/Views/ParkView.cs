using System;
using System.Text;
using TransportCompanyLib.Models;

namespace TransportCompanyLib.Views
{
    /// <summary>
    /// Class realized demonstration of autopark
    /// </summary>
    public class ParkView
    {
        private Autopark _autopark;

        /// <summary>
        /// Park view constructor
        /// </summary>
        /// <param name="autopark">Autopark model</param>
        public ParkView(Autopark autopark)
        {
            if (autopark is null)
                throw new ArgumentNullException();

            _autopark = autopark;
        }

        /// <summary>
        /// Method shows all autopark(semitrailers and tractors)
        /// </summary>
        /// <returns></returns>
        public string ShowAutopark()
        {
            StringBuilder autoparkView = new StringBuilder();

            autoparkView.AppendLine("Autopark tractors");
            for (int i = 0; i < _autopark.SemitrailerTractors.Count; i++)
            {
                autoparkView.AppendLine(_autopark.SemitrailerTractors[i].ToString());
            }

            autoparkView.AppendLine("Autopark semitrailers");
            for (int i = 0; i < _autopark.Semitrailers.Count; i++)
            {
                autoparkView.AppendLine(_autopark.Semitrailers[i].ToString());
            }

            return autoparkView.ToString();
        }
    }
}
