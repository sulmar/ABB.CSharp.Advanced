using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB.Flisr.Extensions
{
    
    public class DateTimeHelper
    {
        public static bool IsHoliday(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday
                || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }
    }


    public static class DateTimeExtentions
    {
        public static bool IsHoliday(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday
                || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        public static DateTime AddWorkDays(this DateTime dateTime, int days)
        {
            return dateTime.AddDays(days);
        }

        public static int GetLength(this string input)
        {
            return input.Length;
        }
    }

    public static class Test
    {
        public static int GetLength2(this string text)
        {
            return text.Length;
        }
    }
}
