using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Presentation.Hubs;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class DangerController : Controller
    {
        // GET: Danger
        public ActionResult Approve(int id)
        {
            IWContext context = new IWContext();
            //string userid = User.Identity.GetUserId();
            ApplicationUser user = context.Users.FirstOrDefault(x => x.Id == userid);
            Danger danger = context.Dangers.FirstOrDefault(d => d.Id == id);
            if (danger == null)
                return View("Error");
            danger.ApprovedBy++;
            if (danger.ApprovedBy > 1000 && !danger.Notified)
            {
                Notifier notifier = Notifier.getInstance().Value;
                danger.Notified = true;
                notifier.NotifyAllNearBy("New danger","");
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            IWContext context = new IWContext();
            DateTime monthAgo = DateTime.Now.AddDays(-30);
            var dangers = context.Dangers.Where(d => d.Date > monthAgo).Include("Disease").Include("Alertes");
            ViewData["dangers"] = dangers;
            return View();
        }

        public ActionResult Create()
        {
            Danger Danger1 = new Danger
            {
                Date = DateTime.Now,
                ApprovedBy = 50,
                Disease = new Disease
                {
                    Name = "Disease 1"
                }
            };
            Danger Danger2 = new Danger
            {
                Date = DateTime.Now.AddDays(-50),
                ApprovedBy = 500,
                Disease = new Disease
                {
                    Name = "Disease 2"
                }
            };
            Danger Danger3 = new Danger
            {
                Date = DateTime.Now.AddDays(-10),
                ApprovedBy = 50,
                Disease = new Disease
                {
                    Name = "Disease 3"
                }
            };
            IWContext context = new IWContext();
            context.Dangers.AddRange(new List<Danger>(){ Danger1, Danger2 , Danger3});
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}