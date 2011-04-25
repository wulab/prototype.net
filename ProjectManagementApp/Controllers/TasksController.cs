using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagementApp.Models;

namespace ProjectManagementApp.Controllers
{
    public class TasksController : Controller
    {
        ProjectManagementModelContainer db = new ProjectManagementModelContainer();

        //
        // GET: /Tasks/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Tasks/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Projects/5/Tasks/Create

        public ActionResult Create(int pid)
        {
            Task task = new Task
            {
                TaskTypeId = 1,
                TaskStatusId = 1
            };

            ViewBag.TaskTypes = db.TaskTypes.ToList();
            ViewBag.TaskStatuses = db.TaskStatuses.ToList();
            ViewBag.CurrentProject = db.Projects.Find(pid);

            return View(task);
        } 

        //
        // POST: /Projects/5/Tasks/Create

        [HttpPost]
        public ActionResult Create(int pid, Task task)
        {
            if (!Request.IsAuthenticated) return RedirectToAction("Create", "Sessions");

            var project = db.Projects.Find(pid);
            task.Project = project;
            task.DateCreated = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();

                TempData["success"] = "Task has successfully been created.";
                return RedirectToAction("Tasks", "Projects", new { id = pid });
            }

            return View(task);
        }
        
        //
        // GET: /Tasks/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Tasks/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Tasks/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Tasks/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
