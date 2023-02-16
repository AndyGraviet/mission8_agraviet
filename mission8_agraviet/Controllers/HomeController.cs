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

        public IActionResult AllTasks()
        {
            var tasks = newContext.responses
                .Include(x => x.Category)
                .ToList();
            return View(tasks);
        }

        public IActionResult CompletedTasks()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

