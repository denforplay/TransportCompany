using System.Collections.Generic;

namespace TransportCompanyLib.Extensions
{
    /// <summary>
    /// Extensions for list collection
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Is list equal to other list
        /// </summary>
        /// <typeparam name="T">Type of list objects</typeparam>
        /// <param name="currentCollection">Current collection</param>
        /// <param name="otherCollection">Other collection to compare with current collection</param>
        /// <returns>Returns true if both lists are similar, other returns false</returns>
        public static bool IsEqual<T>(this IReadOnlyList<T> currentCollection, IReadOnlyList<T> otherCollection)
        {
            if (currentCollection.Count != otherCollection.Count)
                return false;

            for (int i = 0; i < currentCollection.Count; i++)
            {
                if (!otherCollection[i].Equals(currentCollection[i]))
                    return false;
            }

            return true;
        }
    }
}
