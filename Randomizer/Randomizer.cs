

/// <summary>
/// Randomizer functions
/// </summary>
namespace RandomizerFunctions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>Methods to generate all kinds of random things</summary>
    public static class Randomizer
    {
        /// <summary>Object to generate random things</summary>
        static readonly Random r = new Random();

        #region Random Dates

        /// <summary>
        /// Get a random date between 1 januari 1900 and current date
        /// </summary>
        /// <returns>The generated date</returns>
        public static DateTime RandomDate()
        {
            var startDate = new DateTime(1900, 1, 1);
            var daysBetween = (DateTime.Now - startDate).Days;
            var daysToAdd = r.Next(daysBetween);
            return startDate.AddDays(daysToAdd);
        }

        /// <summary>
        /// Get a random date between a given date and the current date
        /// </summary>
        /// <returns>The generated date</returns>
        public static DateTime RandomDate(DateTime startDate)
        {
            if (startDate >= DateTime.Now)
            {
                throw new ArgumentException("Startdate cannot be a date in the future");
            }
            var daysBetween = (DateTime.Now - startDate).Days;
            var daysToAdd = r.Next(daysBetween);
            return startDate.AddDays(daysToAdd);
        }

        /// <summary>
        /// Get a random date between 2 given dates
        /// </summary>
        /// <returns>The generated date</returns>
        public static DateTime RandomDate(DateTime startDate, DateTime endDate)
        {
            if (startDate >= endDate)
            {
                throw new ArgumentException("Startdate must be before enddate");
            }
            var daysBetween = (endDate - startDate).Days;
            var daysToAdd = r.Next(daysBetween);
            return startDate.AddDays(daysToAdd);
        }
        #endregion

        #region Random Integer
        /// <summary>Gets a random integer.</summary>
        /// <param name="useNegative">if set to <c>true</c> [use negative].</param>
        /// <returns>The generated number</returns>
        public static int RandomInteger(bool useNegative)
        {
            int minValue;
            int maxValue = int.MaxValue;
            if (useNegative)
            {
                minValue = int.MinValue;
            }
            else
            {
                minValue = 0;
            }
            return r.Next(minValue + 1, maxValue);
        } 
        #endregion

    }
}
