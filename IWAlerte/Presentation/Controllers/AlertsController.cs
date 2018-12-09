using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using Presentation.Hubs;

namespace Presentation.Controllers
{
    public class AlertsController : Controller
    {
        // GET: Alerts
        public ActionResult Index()
        {
            return View();
        }
    }
}