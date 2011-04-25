using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagementApp.Models;

namespace ProjectManagementApp.Controllers
{
    public class MicropostsController : Controller
    {
        ProjectManagementModelContainer db = new ProjectManagementModelContainer();

        //
        // POST: /Microposts/Create

        [HttpPost]
        public ActionResult Create(Micropost micropost)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");

            int currentUserId = int.Parse(User.Identity.Name);
            var currentUser = db.Users.Find(currentUserId);

            micropost.User = currentUser;
            micropost.DateCreated = DateTime.Now;

            try
            {
                db.Microposts.Add(micropost);
                db.SaveChanges();

                TempData["success"] = "A new micropost was successfully created.";
                return RedirectToAction("Dashboard", "Home");
            }
            catch
            {
                TempData["error"] = "Can not create a micropost.";
                return RedirectToAction("Dashboard", "Home");
            }
        }

        //
        // GET: /Microposts/Delete/5

        public ActionResult Delete(int id)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");
            
            var micropost = db.Microposts.Find(id);

            if (micropost.UserId == int.Parse(User.Identity.Name))
            {
                db.Microposts.Remove(micropost);
                db.SaveChanges();

                TempData["success"] = "Micropost was successfully deleted.";
                return RedirectToAction("Dashboard", "Home");
            }

            TempData["error"] = "Can not delete micropost.";
            return RedirectToAction("Index", "Home");
        }

    }
}
