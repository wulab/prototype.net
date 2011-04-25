using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagementApp.Models;
using System.Web.Security;

namespace ProjectManagementApp.Controllers
{
    public class UsersController : Controller
    {
        ProjectManagementModelContainer db = new ProjectManagementModelContainer();

        //
        // GET: /Users/

        public ActionResult Index()
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");

            var users = db.Users.ToList();

            int currentUserId = int.Parse(User.Identity.Name);
            ViewBag.CurrentUser = db.Users.Find(currentUserId);

            return View(users);
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id)
        {
            var user = db.Users.Find(id);
            ViewBag.Microposts = user.Microposts.OrderByDescending(m => m.DateCreated).ToList();

            int currentUserId = int.Parse(User.Identity.Name);
            ViewBag.CurrentUser = db.Users.Find(currentUserId);

            return View(user);
        }

        //
        // GET: /Users/Create
        // GET: /Signup

        public ActionResult Create()
        {
            if (Request.IsAuthenticated) return RedirectToAction("Dashboard", "Home");

            User user = new User();

            return View(user);
        } 

        //
        // POST: /Users/Create
        // POST: /Signup

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (Request.IsAuthenticated) return RedirectToAction("Dashboard", "Home");

            user.DateCreated = DateTime.Now;
            user.IsAdmin = false;

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                TempData["success"] = "Welcome to the Project Management App!";
                FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                // Session["CurrentUser"] = user;
                return RedirectToAction("Dashboard", "Home");
            }

            return View(user);
        }
        
        //
        // GET: /Users/Edit/5
 
        public ActionResult Edit(int id)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");
            if (User.Identity.Name != id.ToString()) return RedirectToAction("Dashboard", "Home");

            var user = db.Users.Find(id);

            return View(user);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");
            if (User.Identity.Name != id.ToString()) return RedirectToAction("Dashboard", "Home");

            var user = db.Users.Find(id);

            if (TryUpdateModel(user))
            {
                db.SaveChanges();
                TempData["success"] = "Your profile was successfully updated.";
                return RedirectToAction("Details", "Users", new { id = user.Id });
            }

            return View(user);
        }

        //
        // GET: /Users/Delete/5
 
        public ActionResult Delete(int id)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");
            var user = db.Users.Find(id);
            if (user.IsAdmin) return RedirectToAction("Index", "Users");
            
            return View(user);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");
            var user = db.Users.Find(id);
            if (user.IsAdmin) return RedirectToAction("Index", "Users");

            db.Users.Remove(user);
            db.SaveChanges();

            TempData["success"] = "User was successfully deleted.";
            return RedirectToAction("Index", "Users");
        }
    }
}
