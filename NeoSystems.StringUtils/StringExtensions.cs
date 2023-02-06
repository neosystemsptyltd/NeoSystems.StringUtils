
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSystems.StringUtils
{

    /// <summary>
    /// string class extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// case insensitive contains
        /// </summary>
        /// <param name="source">source class</param>
        /// <param name="toCheck">string to check for contains</param>
        /// <param name="comp">comparison type</param>
        /// <returns></returns>
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }

        /// <summary>
        /// Check if a string contains any of the strings in the array
        /// </summary>
        /// <param name="source">source string to check</param>
        /// <param name="toCheckArr">array of strings to check if its contained in source</param>
        /// <returns>true if any of the strings in the array is contained in source</returns>
        public static bool ContainsAnyOf(this string source, string[] toCheckArr)
        {
            foreach (string s in toCheckArr)
            {
                if (source.Contains(s))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if a string contains any of the strings in the array, using the specified comparison type.
        /// </summary>
        /// <param name="source">source string to check</param>
        /// <param name="toCheckArr">array of strings to check if its contained in source</param>
        /// <param name="comp">comparison type</param>
        /// <returns>true if any of the strings in the array is contained in source</returns>
        public static bool ContainsAnyOf(this string source, string[] toCheckArr, StringComparison comp)
        {
            foreach (string s in toCheckArr)
            {
                if (source.Contains(s, comp))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if a string contains any of the strings in the list
        /// </summary>
        /// <param name="source">source string to check</param>
        /// <param name="toCheckList">List of strings to check if its contained in source</param>
        /// <returns>true if any of the strings in the array is contained in source</returns>
        public static bool ContainsAnyOf(this string source, List<string> toCheckList)
        {
            foreach (string s in toCheckList)
            {
                if (source.Contains(s))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if a string contains any of the strings in the list, using the specified comparison type.
        /// </summary>
        /// <param name="source">source string to check</param>
        /// <param name="toCheckList">List of strings to check if its contained in source</param>
        /// <param name="comp">comparison type</param>
        /// <returns>true if any of the strings in the array is contained in source</returns>
        public static bool ContainsAnyOf(this string source, List<string> toCheckList, StringComparison comp)
        {
            foreach (string s in toCheckList)
            {
                if (source.Contains(s, comp))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// test if a string contains ASCII characters only
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsASCIIOnly(this string source)
        {
            // ASCII encoding replaces non-ascii with question marks, so we use UTF8 to see if multi-byte sequences are there
            return Encoding.UTF8.GetByteCount(source) == source.Length;
        }

        /// <summary>
        /// Count the number of occurrences of a character in a string
        /// </summary>
        /// <param name="source">string to check</param>
        /// <param name="c">char to count</param>
        /// <returns>number of times c occurs in the string</returns>
        public static int Count(this string source, char c)
        {
            int count = 0;

            foreach (char ch in source)
            {
                if (ch == c)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Check if a string is a valid email address
        /// </summary>
        /// <param name="source">String to check</param>
        /// <returns>true if string is an email address, false if not</returns>
        public static bool IsEmail(this string source)
        {
            string emailRegex = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

            // check if source is a Regex match for emailRegex
            bool result = System.Text.RegularExpressions.Regex.IsMatch(source, emailRegex);
            result = result && source.Count('@') == 1; // check if there is only one @ in the string

            return result;
        }

        /// <summary>
        /// Remove all occurrences of the character r in the string
        /// </summary>
        /// <param name="s">string object ref</param>
        /// <param name="c">char to remove</param>
        /// <returns>string where all occurrences of c was removed</returns>
        public static string RemoveAll(this string s, char c)
        {
            return s.Replace(c.ToString(), "");
        }

        /// <summary>
        /// Remove all occurrences of the characters in the array c in the string
        /// </summary>
        /// <param name="s">Original string</param>
        /// <param name="c">array of chars to remove</param>
        /// <returns>string with chars removed</returns>
        public static string RemoveAll(this string s, char[] c)
        {
            foreach (char ch in c)
            {
                s = s.Replace(ch.ToString(), "");
            }

            return s;
        }

        /// <summary>
        ///
        /// </summary>
        public enum CommentType
        {
            /// <summary>
            /// Traditional C comments
            /// </summary>
            TraditionalC,

            /// <summary>
            /// Comments with Hash char
            /// </summary>
            HashCharComments,

            /// <summary>
            /// Traditional C comments
            /// </summary>
            Cplusplus,
        }

        /// <summary>
        /// Position of the comment, in front of all lines are after all lines
        /// </summary>
        public enum CommentPosition
        {
            /// <summary>
            /// add comment in front of the text
            /// </summary>
            Front,

            /// <summary>
            /// Add comment after the text
            /// </summary>
            After
        }

        /// <summary>
        /// add comments to a block represented by string arrays
        /// </summary>
        /// <param name="lines">array of strings to be commented</param>
        /// <param name="commentstringFront">comment text to be added in front</param>
        /// <param name="commentstringAfter">text to added afetr</param>
        /// <returns>string arrays with comments</returns>
        public static void Comment(this string[] lines, string commentstringFront, string commentstringAfter)
        {
            for (int i = 0; i < lines.Count(); i++)
            {
                lines[i] = commentstringFront + lines[i];
            }
        }

        /// <summary>
        /// add comments to a block represented by string arrays
        /// </summary>
        /// <param name="lines">array of strings to be commented</param>
        /// <param name="type">type of comment to be added</param>
        /// <param name="position">Where to add the comments</param>
        /// <returns></returns>
        public static void Comment(this string[] lines, CommentType type, CommentPosition position = CommentPosition.Front)
        {
            string commentstringFront = "";
            string commentstringBack = "";

            if (position == CommentPosition.Front)
            {
                switch (type)
                {
                    case CommentType.HashCharComments:
                        commentstringFront = "# ";
                        break;

                    case CommentType.TraditionalC:
                        commentstringFront = "/* ";
                        commentstringBack = " */";
                        break;

                    case CommentType.Cplusplus: // implicitly front and back
                        commentstringFront = "// ";
                        break;
                }
            }
            else
            {
                switch (type)
                {
                    case CommentType.HashCharComments:
                        commentstringBack = " #";
                        break;

                    case CommentType.TraditionalC:
                        commentstringFront = "/* ";
                        commentstringBack = " */";
                        break;


                    case CommentType.Cplusplus: // implicitly front and back
                        commentstringBack = " //";
                        break;
                }
            }

            Comment(lines, commentstringFront, commentstringBack);
        }
    }
}
