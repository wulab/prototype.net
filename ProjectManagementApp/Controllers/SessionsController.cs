using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagementApp.Models;
using System.Web.Security;

namespace ProjectManagementApp.Controllers
{
    public class SessionsController : Controller
    {
        ProjectManagementModelContainer db = new ProjectManagementModelContainer();

        //
        // GET: /Sessions/Create
        // GET: /Signin

        public ActionResult Create()
        {
            if (Request.IsAuthenticated) return RedirectToAction("Dashboard", "Home");

            return View();
        } 

        //
        // POST: /Sessions/Create
        // POST: /Signin

        [HttpPost]
        public ActionResult Create(SignInViewModel model)
        {
            var users = db.Users.Where(u => u.Email == model.Email).ToList();

            foreach (var user in users)
            {
                if (user.Password == model.Password)
                {
                    TempData["success"] = "Welcome back, " + user.Name;
                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                    // Session["CurrentUser"] = user;
                    return RedirectToAction("Dashboard", "Home");
                }
            }

            TempData["error"] = "Invalid email/password combination.";
            return View();
        }
        
        //
        // GET: /Sessions/Delete
        // GET: /Signout

        public ActionResult Delete()
        {
            Session["CurrentUser"] = null;
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
