using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mission8_agraviet.Models;

namespace mission8_agraviet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private TaskSubmissionContext newContext { get; set; }

        public HomeController(ILogger<HomeController> logger, TaskSubmissionContext thisContext)
        {
            _logger = logger;
            newContext = thisContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var tasks = newContext.responses
                .Include(x => x.Category)
                .ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult EnterTask()
        {
            ViewBag.Categories = newContext.categories.ToList();
            ViewBag.Quadrants = newContext.quadrants.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult EnterTask(mission8_agraviet.Models.Task newTask)
        {
            if (ModelState.IsValid)
            {
                newContext.Add(newTask);
                newContext.SaveChanges();
                return View("Confirmation", newTask);
            }
            else
            {
                ViewBag.Categories = newContext.categories.ToList();
                ViewBag.Quadrants = newContext.quadrants.ToList();
                return View(newTask);
            }
        }

        public IActionResult AllTasks()
        {
            var tasks = newContext.responses
                .Include(x => x.Category)
                .ToList();

            return View(tasks);
        }

        public IActionResult CompletedTasks()
        {

            var tasks = newContext.responses
                .Include(x => x.Category)
                .ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Edit(int TaskId)
        {
            ViewBag.Categories = newContext.categories.ToList();
            ViewBag.Quadrants = newContext.quadrants.ToList();
            var submission = newContext.responses.Single(x => x.TaskId == TaskId);
            return View("EnterTask", submission);
        }

        [HttpPost]
        public IActionResult Edit(mission8_agraviet.Models.Task newTask)
        {
            newContext.Update(newTask);
            newContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int TaskId)
        {
            var task = newContext.responses.Single(x => x.TaskId == TaskId);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(mission8_agraviet.Models.Task task)
        {
            newContext.responses.Remove(task);
            newContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

