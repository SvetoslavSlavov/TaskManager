using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tasks.Web.Models;

namespace Tasks.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var tasks = this.db.Tasks
                .OrderBy(e => e.StartDateTime)
                .Where(e => e.IsPublic)
                .Select(e => new TaskViewModel()
                {
                    Id=e.Id,
                    Title=e.Title,
                    StartDateTime=e.StartDateTime,
                    Duration=e.Duration,
                    Author=e.Author.FullName,
                    Location=e.Location
                });
            var upcomingTasks = tasks.Where(e => e.StartDateTime > DateTime.Now);
            var passedTasks = tasks.Where(e => e.StartDateTime <= DateTime.Now);
            return View(new UpcomingPassedTasksViewModel()
            {
                UpcomingTasks=upcomingTasks,
                PassedTasks=passedTasks
            });
        }   
    }
}