using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace ProjectManagementApp.Helpers
{
    public static class GravatarHelpers
    {
        private const string BASE_URL = "http://www.gravatar.com/avatar/{0}?d={1}&s={2}&r={3}";
        private const string IMG_TAG = "<img src=\"{0}\" class=\"gravatar\" style=\"width:{1}px; height:{1}px;\" />";

        public static MvcHtmlString GravatarImage(this HtmlHelper helper, string email)
        {
            return GravatarImage(helper, email, 50);
        }

        public static MvcHtmlString GravatarImage(this HtmlHelper helper, string email, int size)
        {
            return GravatarImage(helper, email, GravatarRating.r, IconSet.identicon, size);
        }

        public static MvcHtmlString GravatarImage(this HtmlHelper helper, string email, GravatarRating rating, IconSet iconSet, int size)
        {
            var emailHashed = MD5(email);
            var gravatarUrl = string.Format(BASE_URL, emailHashed, iconSet, size, rating);

            return new MvcHtmlString(string.Format(IMG_TAG, gravatarUrl, size));
        }

        private static string MD5(string theEmail)
        {
            var md5Obj = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var bytesToHash = Encoding.ASCII.GetBytes(theEmail);
            bytesToHash = md5Obj.ComputeHash(bytesToHash);
            return bytesToHash.Aggregate("", (current, b) => current + b.ToString("x2"));
        }
    }

    public enum GravatarRating
    {
        g, pg, r, x
    }

    public enum IconSet
    {
        identicon, monsterid, wavatar
    }
}