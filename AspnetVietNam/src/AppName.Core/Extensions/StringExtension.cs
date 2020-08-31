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
            // First to lower case
            phrase = phrase.RemoveAccent().ToLower();
            // invalid chars           
            phrase = Regex.Replace(phrase, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            phrase = Regex.Replace(phrase, @"\s+", " ").Trim();
            // cut and trim 
            phrase = phrase.Substring(0, phrase.Length <= maxLength ? phrase.Length : maxLength).Trim();
            // replace occurences of -
            phrase = Regex.Replace(phrase, @"\s", "-"); // hyphens   
            return phrase;
        }

        public static string RemoveAccent(this string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

        public static string ToUrlSlug(this string value)
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
