using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace System
{
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if string is Null or Empty("")
        /// </summary>
        /// <param name="str">The string to check if Null or Empty("")</param>
        /// <returns>True if string is Null or Empty("")</returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return String.IsNullOrEmpty(str);
        }
        /// <summary>
        /// Throws an ArgumentNullException if string is if Null or Empty("").
        /// </summary>
        /// <param name="str">True if string is Null or Empty("")</param>
        public static void ThrowIfNullOrEmpty(this string str)
        {
            if (str.IsNullOrEmpty())
            {
                throw new ArgumentNullException(str);
            }
        }
        /// <summary>
        /// Checks if string is Null, all whitespaces, or Empty("")
        /// </summary>
        /// <param name="str">The string to check if Null, all whitespaces, or Empty("")</param>
        /// <returns>True if string is Null, all whitespaces, or Empty("")</returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return String.IsNullOrWhiteSpace(str);
        }


        /// <summary>
        /// Throws an ArgumentNullException if string is Null, all whitespaces, or Empty("")
        /// </summary>
        /// <param name="str">The string to check if Null, all whitespaces, or Empty("")</param>
        public static void ThrowIfNullOrWhiteSpace(this string str)
        {
            if (str.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(str);
            }
        }


        /// <summary>
        /// Creates a string where the first letter of all words are capitol and the rest are lower
        /// </summary>
        /// <param name="str"></param>
        /// <returns>A string that all words start with a capitol letter and the rest are lower case</returns>
        public static string ToTitleCase(this string str)
        {
            str.ThrowIfNullOrWhiteSpace();
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }


    }
}