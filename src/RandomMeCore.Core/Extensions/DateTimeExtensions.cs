using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace RandomMeCore.Core.Extensions
{
    public static class DateHelper
    {
        public static DateTime Random(int minYear, int maxYear)
        {
            var year = RandomNumberGenerator.GetInt32(minYear, maxYear+1);
            var month = RandomNumberGenerator.GetInt32(1, 13);
            var days = DateTime.DaysInMonth(year, month);
            var day = RandomNumberGenerator.GetInt32(1, days+1);

            return new DateTime(year, month, day);
        }
    }
}
