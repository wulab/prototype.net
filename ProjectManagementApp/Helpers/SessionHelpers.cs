using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagementApp.Models;
using System.Web.Security;

namespace ProjectManagementApp.Helpers
{
    public static class SessionHelpers
    {
        public static User GetCurrentUser()
        {
            if (HttpContext.Current.Session["current_user"] != null)
            {
                return HttpContext.Current.Session["current_user"] as User;
            }
            else
            {
                return null;
            }
        }

        public static void SignIn(User user)
        {
            FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
            HttpContext.Current.Session["current_user"] = user;
        }

        public static void SignOut()
        {
            HttpContext.Current.Session["current_user"] = null;
            FormsAuthentication.SignOut();
        }
    }
}