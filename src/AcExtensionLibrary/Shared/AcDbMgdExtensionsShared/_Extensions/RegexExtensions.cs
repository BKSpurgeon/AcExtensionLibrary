#define ACAD  // Allows the use of AutoCAD-specific wildcard - Regex conversions
// // ©CADbloke 2016.  I am at http://www.CADbloke.com

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cadbloke.Common.Strings
{
    /// <summary> <see cref="System.Text.RegularExpressions" /> things for a string containing wildcards. </summary>
    /// <remarks> it all started at http://www.codeproject.com/Articles/11556/Converting-Wildcards-to-Regexes </remarks>
    /// <seealso cref="T:System.Text.RegularExpressions.Regex" />
    internal static class RegexExtensions
    {
        /// <summary> Converts a string with wildcards to a regular expression. </summary>
        /// <param name="stringWithWildcards">          The string containing Wildcards(s). </param>
        /// <param name="searchAtStringStart">          the search at string start. </param>
        /// <param name="searchAtStringEnd">            the search at string end. </param>
        /// <param name="useDoubleStarsForGreedyMatch"> Use double stars ** for greedy match, other wise the match is lazy. </param>
        /// <returns> a Regex generated from a String containing wildcards. </returns>
        /// <exception cref="ArgumentException"> String Provided did not covert to a valid regex.</exception>
        internal static string MakeWildcardToRegex(string stringWithWildcards,
                                                   bool searchAtStringStart = false,
                                                   bool searchAtStringEnd = false,
                                                   bool useDoubleStarsForGreedyMatch = true)
        {
            int stringWithWildcardsLength = stringWithWildcards.Length;
            var sb = new StringBuilder();
            string textToPutAtTheEnd = string.Empty;

            if (searchAtStringStart)
                sb.Append("^"); // matches start of string

            for (var i = 0; i < stringWithWildcardsLength; i++)
            {
                char c = stringWithWildcards[i];
                switch (c)
                {
                    case '*':
                        if (useDoubleStarsForGreedyMatch) // as opposed to a lazy match. ** is usually an invald pattern
                        {
                            if (i < stringWithWildcardsLength - 1) // to test for ** without going past the end of the string
                            {
                                char next = stringWithWildcards[i + 1];
                                if (next == '*') // if this is to be a greedy match ...
                                {
                                    // non-backtracking: http://msdn.microsoft.com/en-us/library/bs2twtah%28v=vs.110%29.aspx#nonbacktracking_subexpression
                                    sb.Append(".*"); // Greedy
                                    i++; // we just used the * so skip it.
                                    break;
                                }
                            }
                            sb.Append(".*?"); // Lazy
                            break;
                        }
                        sb.Append(".*"); // Greedy
                        break;


                    case '?':
                        sb.Append(".");
                        break;

#if !ACAD // AutoCAD doesn't use the backslash as to escape text, it uses the backwards apostrophe
                    case '\\':
                        if (i < stringWithWildcardsLength - 1)
                            sb.Append(Regex.Escape(stringWithWildcards[++i].ToString(CultureInfo.InvariantCulture)));
                        break;
#endif

#if ACAD // AutoCAD-specific Wildcards.
                    // See also http://docs.autodesk.com/ACD/2010/ENU/AutoCAD%202010%20User%20Documentation/index.html?url=WS73099cc142f487551ec84dc1111af5a7b7-7aa4.htm,topicNumber=d0e122528

                    case '#':
                        sb.Append("\\d");   // Matches any numeric digit.
                        break;

                    case '@':    // Matches any alphabetic character.  note: English language only
                        sb.Append("[a-zA-Z]");
                        break;

                    case '.':    // Matches any nonalphanumeric character.
                        sb.Append(@"\W.");
                        break;

                    case '~':    // Matches anything but the pattern; for example; ~*AB*matches all strings that don't contain AB.
                        sb.Append("(?!"); // negative lookahead
                        textToPutAtTheEnd = ")" + textToPutAtTheEnd;
                        break;
                    // bug: Bloody hell, how do I do this? ... http://stackoverflow.com/a/406408/492
                    // This is AutoCAD-specific behaviour and probably not appropriate in the real world.

                    case '[':   // same as the usual Regex. Also note we are ignoring "-" as well, same as regular Regex.
                        sb.Append("[");
                        break;

                    case ']':     // same as the usual Regex
                        sb.Append("]");
                        break;

                    case '`':     //(Reverse quote)  Reads the next character literally; for example, `~AB matches ~AB
                        if (i < stringWithWildcardsLength - 1)
                        {
                            sb.Append(Regex.Escape(stringWithWildcards[++i].ToString(CultureInfo.InvariantCulture)));
                        }
                        break;

                    case '\\':
                        sb.Append(@"\");
                        break;

#endif //ACAD

                    default:
                        sb.Append(Regex.Escape(stringWithWildcards[i].ToString(CultureInfo.InvariantCulture)));
                        break;
                }
            }

            sb.Append(textToPutAtTheEnd); // For that bloody ~

            if (searchAtStringEnd)
                sb.Append(@"\Z"); // matches end of string

            string regexToReturn = sb.ToString();

            if (regexToReturn.IsValidRegex())
                return regexToReturn; // note: should I test this here or when used?

            string ruhroh = "Regular Expression generated from String with Wildcards was not valid. Wildcard String is: "
                            + stringWithWildcards + "  but Regex generated is: " + regexToReturn;
            throw new ArgumentException(ruhroh, stringWithWildcards); // bug: need a better way to police bad regex being generated
        }


        /// <summary> A string extension method that checks if 'pattern' is valid regular expression. </summary>
        /// <param name="pattern"> The string / pattern to test. </param>
        /// <returns> true if valid regular expression, false if not. </returns>
        internal static bool IsValidRegex(this string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                return false;

            try
            {
                // ReSharper disable ReturnValueOfPureMethodIsNotUsed
                Regex.Match("", pattern);
                // ReSharper restore ReturnValueOfPureMethodIsNotUsed
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }

        /// <summary> A string extension method to check if a  'pattern' is just a plain string,
        ///     not a regular expression pattern. </summary>
        /// <param name="pattern"> The string / pattern to check. </param>
        /// <returns> true if it is just a plain string not a regular expression pattern or it is null or empty, false if it's a
        ///     Regex. </returns>
        internal static bool IsJustaPlainStringNotARegexPattern(this string pattern)
        {
            if (pattern == null || !string.IsNullOrEmpty(pattern))
                return true;

            if (Regex.Escape(pattern) == pattern)
                return true;

            return false;
        }

        /// <summary> A string extension method to check if pattern is a regular expression pattern. </summary>
        /// <param name="pattern"> The string / pattern to check. </param>
        /// <returns> true if pattern is a regular expression pattern, false just a plain string or it is null or empty. </returns>
        internal static bool IsARegexPattern(this string pattern)
        {
            if (pattern == null || !string.IsNullOrEmpty(pattern))
                return false;

            if (Regex.Escape(pattern) == pattern)
                return false;

            return true;
        }


        /*
    original method, later updated in a comment
    http://www.codeproject.com/Articles/11556/Converting-Wildcards-to-Regexes?msg=1423024#xx1228560xx
    <summary> Converts a stringWithWildcards to a regex. </summary>
    <param name="stringWithWildcards"> The stringWithWildcards stringWithWildcards to convert. </param>
    <returns> A regex equivalent of the given stringWithWildcards. </returns>
    nternal static string MakeWildcardToRegex(string stringWithWildcards)
    
     return "^" + Regex.Escape(pattern).
                  Replace("\\*", ".*").
                  Replace("\\?", ".") + "$";

        I think I may have got a little carried away here. Whups
    
    */
    }
}