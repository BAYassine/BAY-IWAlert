using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class LandingPageController : Controller
    {
        // GET: LandingPage
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

                list.Add(new Models.PaysCouleur { Pays =line.Metric , couleur = couleur });
            }

            return new JsonResult { Data = list, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }



        // GET: LandingPage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LandingPage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LandingPage/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: LandingPage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LandingPage/Edit/5
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

        // GET: LandingPage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LandingPage/Delete/5
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
