using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IWContext context = new IWContext();
            List<Models.Alerte> alts = context.Alertes.Include("Disease").Include("User").ToList<Models.Alerte>();
            ViewBag.result = alts;




            return View();
        }

        public JsonResult getColors()
        {
            IWContext context = new IWContext();

            //var count =context.Alertes.Include("Disease").Include("User").GroupBy(n => n.User.Place);
            List<Models.PaysCouleur> list = new List<Models.PaysCouleur>();
            foreach (var line in context.Alertes.GroupBy(info => info.User.Place.Country)
                        .Select(group => new
                        {
                            Metric = group.Key,
                            Count = group.Count()
                        }).ToList())
            {

                string couleur = "";
                if (line.Count < 5) couleur = "#F9573B";
                if (line.Count > 5) couleur = "#FF9900";
                if (line.Count > 10) couleur = "#FF9933";
                if (line.Count > 15) couleur = "#FF0000";

                list.Add(new Models.PaysCouleur { Pays = line.Metric, couleur = couleur });
            }

            return new JsonResult { Data = list, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}