
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Tasks.Data;
using Tasks.Web.Extensions;
using Tasks.Web.Models;

namespace Tasks.Web.Controllers
{
    [Authorize]
    public class TasksController : BaseController
    {
        public ActionResult My()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var e = new Task()
                {
                    AuthorId = this.User.Identity.GetUserId(),
                    Title = model.Title,
                    StartDateTime = model.StartDateTime,
                    Duration = model.Duration,
                    Description = model.Description,
                    Location = model.Location,
                    IsPublic = model.IsPublic
                };
                this.db.Tasks.Add(e);
                this.db.SaveChanges();
                this.AddNotification("Event created.", NotificationType.INFO);
                return this.RedirectToAction("My");
            }

            return this.View(model);
        }


    }
}