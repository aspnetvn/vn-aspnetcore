using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;

namespace AppName.Core.Extensions.StringExtension
{
    public static class StringExtension
    {
        public static bool IsValidJson(this string text)
        {
            text = text.Trim();
            if ((text.StartsWith("{") && text.EndsWith("}")) || //For object
                (text.StartsWith("[") && text.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(text);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static string GenerateSlug(this string phrase, int maxLength = 45)
        {
            string str = phrase.RemoveAccent().ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= maxLength ? str.Length : maxLength).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        public static string RemoveAccent(this string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

        public static string ToUrlSlug(string value)
        {
            //First to lower case
            value = value.ToLowerInvariant();
            //Remove all accents
            value = value.RemoveAccent().ToLower();
            //Replace spaces
            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);
            //Remove invalid chars
            value = Regex.Replace(value, @"[^a-z0-9\s-_]", "", RegexOptions.Compiled);
            //Trim dashes from end
            value = value.Trim('-', '_');
            //Replace double occurences of - or _
            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);
            return value;
        }
    }
}
