using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public static class JosaExtensions
    {
        /// <summary>
        /// Iterates through a tree-like data structure, and searches for a predicate match
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="child">Object with a child</param>
        /// <param name="predicate">boolean match</param>
        /// <param name="getChildren">get children of the object</param>
        /// <returns>a match of the predicate</returns>
        public static T FindWhereInChildren<T>(this T child, Func<T, bool> predicate, Func<T, IEnumerable<T>> getChildren)
        {
            if (predicate(child))
                return child;

            foreach (var item in getChildren(child))
            {
                var res = item.FindWhereInChildren(predicate, getChildren);
                if (res != null)
                    return res;
            }

            return default;
        }

        /// <summary>
        /// Finds all matching occurances in a list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> WhereInList<T>(this IEnumerable<T> root, Func<T, bool> predicate)
        {
            foreach (var item in root)
                if (predicate(item))
                    yield return item;
        }
    }
}
