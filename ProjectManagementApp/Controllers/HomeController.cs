using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagementApp.Models;

namespace ProjectManagementApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Index");

            // var user = Session["CurrentUser"] as User;
            ProjectManagementModelContainer db = new ProjectManagementModelContainer();

            int currentUserId = int.Parse(User.Identity.Name);
            var currentUser = db.Users.Find(currentUserId);

            var viewModel = new DashboardViewModel
            {
                Micropost = new Micropost(),
                Microposts = currentUser.Microposts.OrderByDescending(m => m.DateCreated).ToList()
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
