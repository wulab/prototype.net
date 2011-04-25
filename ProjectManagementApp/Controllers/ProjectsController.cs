using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagementApp.Models;

namespace ProjectManagementApp.Controllers
{
    public class ProjectsController : Controller
    {
        ProjectManagementModelContainer db = new ProjectManagementModelContainer();

        //
        // GET: /Projects/

        public ActionResult Index()
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");

            var projects = db.Projects.ToList();

            return View(projects);
        }

        //
        // GET: /Projects/Details/5

        public ActionResult Details(int id)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");

            var project = db.Projects.Find(id);

            int currentUserId = int.Parse(User.Identity.Name);
            ViewBag.CurrentUser = db.Users.Find(currentUserId);

            return View(project);
        }

        //
        // GET: /Projects/Create

        public ActionResult Create()
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");

            Project project = new Project();

            return View(project);
        } 

        //
        // POST: /Projects/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Project project)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");

            project.DateCreated = DateTime.Now;

            if (ModelState.IsValid)
            {                
                db.Projects.Add(project);
                db.SaveChanges();

                TempData["success"] = "Project has successfully been created.";
                return RedirectToAction("Details", "Projects", new { id = project.Id });
            }

            return View(project);
        }
        
        //
        // GET: /Projects/Edit/5
 
        public ActionResult Edit(int id)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");
            var currentUser = db.Users.Find(int.Parse(User.Identity.Name));
            if (!currentUser.IsAdmin) return RedirectToAction("Index", "Projects");

            var project = db.Projects.Find(id);

            return View(project);
        }

        //
        // POST: /Projects/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");
            var currentUser = db.Users.Find(int.Parse(User.Identity.Name));
            if (!currentUser.IsAdmin) return RedirectToAction("Index", "Projects");

            var project = db.Projects.Find(id);

            if (TryUpdateModel(project))
            {
                db.SaveChanges();
                TempData["success"] = "Project was successfully updated.";
                return RedirectToAction("Details", "Projects", new { id = project.Id });
            }

            return View(project);
        }

        //
        // GET: /Projects/Delete/5
 
        public ActionResult Delete(int id)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");
            var currentUser = db.Users.Find(int.Parse(User.Identity.Name));
            if (!currentUser.IsAdmin) return RedirectToAction("Index", "Projects");

            var project = db.Projects.Find(id);

            return View(project);
        }

        //
        // POST: /Projects/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");
            var currentUser = db.Users.Find(int.Parse(User.Identity.Name));
            if (!currentUser.IsAdmin) return RedirectToAction("Index", "Projects");

            var project = db.Projects.Find(id);

            db.Projects.Remove(project);
            db.SaveChanges();

            TempData["success"] = "Project was successfully deleted.";
            return RedirectToAction("Index", "Projects");
        }

        //
        // GET: /Projects/5/Users

        public ActionResult Users(int id)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");

            var project = db.Projects.Find(id);

            int currentUserId = int.Parse(User.Identity.Name);
            ViewBag.CurrentUser = db.Users.Find(currentUserId);

            ViewBag.People = db.Users.OrderBy(u => u.Name).ToList();

            return View(project);
        }

        //
        // POST: /Projects/5/AddUser

        [HttpPost]
        public ActionResult AddUser(int id, int userId)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");
            var currentUser = db.Users.Find(int.Parse(User.Identity.Name));
            if (!currentUser.IsAdmin) return RedirectToAction("Index", "Projects");

            var project = db.Projects.Find(id);
            var user = db.Users.Find(userId);

            project.Users.Add(user);
            db.SaveChanges();

            return RedirectToAction("Users", "Projects", new { id = project.Id });
        }

        //
        // POST: /Projects/5/RemoveUser

        [HttpPost]
        public ActionResult RemoveUser(int id, int userId)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");
            var currentUser = db.Users.Find(int.Parse(User.Identity.Name));
            if (!currentUser.IsAdmin) return RedirectToAction("Index", "Projects");

            var project = db.Projects.Find(id);
            var user = db.Users.Find(userId);

            project.Users.Remove(user);
            db.SaveChanges();

            return RedirectToAction("Users", "Projects", new { id = project.Id });
        }

        //
        // GET: /Projects/5/Tasks

        public ActionResult Tasks(int id)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");

            var project = db.Projects.Find(id);

            return View(project);
        }

    }
}
