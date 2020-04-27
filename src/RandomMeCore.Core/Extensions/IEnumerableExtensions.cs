using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RandomMeCore.Core.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T Random<T>(this IEnumerable<T> collection)
        {
            var length = collection.Count();

            return collection.ElementAt(RandomNumberGenerator.GetInt32(length));
        }

        public static T RandomOrDefault<T>(this IEnumerable<T> collection)
        {
            var length = collection.Count();

            return collection.ElementAtOrDefault(RandomNumberGenerator.GetInt32(length));
        }
    }
}
