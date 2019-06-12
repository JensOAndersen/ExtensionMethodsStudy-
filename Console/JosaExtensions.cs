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
            if (predicate(child)) //predicate looks like: 'x => x.id == 1' or 'x => x.name == 'hansel'
            {
                return child;
            }
            else
            {
                foreach (var item in getChildren(child)) //getChildren is 'x => x.children
                {
                    return item.FindWhereInChildren(predicate, getChildren);
                }
            }

            return default(T);
            /*
             The method is recursive as it needs to look through all children of the given object.
             */
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
