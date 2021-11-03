using System.Collections.Generic;

namespace TransportCompanyLib.Extensions
{
    public static class ListExtensions
    {
        public static bool IsEqual<T>(this List<T> currentCollection, List<T> otherCollection)
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
