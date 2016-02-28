// <copyright company="XATA">
//      Copyright (c) 2016, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;

namespace Sketch
{
    public static class EnumerableExtensions
    {
        public static void AddTo<T>(this IEnumerable<T> source, ICollection<T> target)
        {
            foreach (var element in source)
            {
                target.Add(element);
            }
        }
    }
}
