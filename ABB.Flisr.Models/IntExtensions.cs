using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ABB.Flisr.Models
{
    public static class Extensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this T number)
        {
            return new List<T> { number };
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> items, T item)
        {
            return items.Concat(new List<T> { item });
        }
            
    }


    public static class DateTimeExtensions
    {
        public static TimeSpan Seconds(this int seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        public static TimeSpan Seconds(this double seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }
    }
}
