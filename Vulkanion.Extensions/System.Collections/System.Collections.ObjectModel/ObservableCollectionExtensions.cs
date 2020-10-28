using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Vulkanion.Extensions.System.Collections.Generic;

namespace Vulkanion.Extensions.System.Collections.ObjectModel
{
    /// <summary>
    /// Extends the <see cref="ObservableCollection{T}"/>.
    /// </summary>
    public static class ObservableCollectionExtensions
    {
        /// <summary>
        /// Replaces all items in this <see cref="ObservableCollection{T}"/> with the items of the provided <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items in both the <see cref="ObservableCollection{T}"/> and the provided <see cref="IEnumerable{T}"/>.</typeparam>
        /// <param name="observableCollection">The <see cref="ObservableCollection{T}"/> to perform the replacement operation on.</param>
        /// <param name="collection">The provided <see cref="IEnumerable{T}"/> that will replace the existing items in this <see cref="ObservableCollection{T}"/>.</param>
        public static void ReplaceWith<T>(this ObservableCollection<T> observableCollection, IEnumerable<T> collection)
        {
            if(observableCollection is null) throw new NullReferenceException();
            if(collection != null)
            {
                observableCollection.Clear();
                if(collection.IsNotEmpty())
                {
                    foreach(var item in collection)
                    {
                        observableCollection.Add(item);
                    }
                }
            }
        }
    }
}