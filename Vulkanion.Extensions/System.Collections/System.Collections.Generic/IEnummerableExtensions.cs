using System;
using System.Collections.Generic;
using System.Linq;

namespace Vulkanion.Extensions.System.Collections.Generic
{
    /// <summary>
    /// Extends the functionality of <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class IEnummerableExtensions
    {
        /// <summary>
        /// Determines whether or not the collection is empty.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>A <see cref="bool"/> indicating whether or not the collection is empty.</returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> collection)
        {
            if(collection is null) throw new NullReferenceException();
            try
            {
                return collection.Count() > 0;
            }
            catch(OverflowException)
            {
                return collection.LongCount() > default(long);
            }
        }

        /// <summary>
        /// Determines whether or not the collection is empty.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>A <see cref="bool"/> indicating whether or not the collection is empty.</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> collection) => !IsNotEmpty(collection);
    }
}