using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ProjectManagementApp.Helpers
{
    public static class HtmlHelpers
    {
        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            return Truncate(helper, input, length, "...");
        }

        public static string Truncate(this HtmlHelper helper, string input, int length, string omission)
        {
            // http://dobon.net/vb/dotnet/string/substring.html
            
            StringInfo si = new StringInfo(input);

            if (si.LengthInTextElements <= length)
            {
                return input;
            }
            else
            {
                return si.SubstringByTextElements(0, length) + omission;
            }
        }

        public static string Sanitize(this HtmlHelper helper, string html)
        {
            // http://stackoverflow.com/questions/785715/asp-net-strip-html-tags

            string text = Regex.Replace(html, "<[^>]*>", string.Empty);
            string normalizedText = Regex.Replace(text, "[\\s\r\n]+", " ");

            return normalizedText;
        }
    }
}