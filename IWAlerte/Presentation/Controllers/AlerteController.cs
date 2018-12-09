using Presentation.Models;
using Presentation.Models.ViewModel;
using Presentation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Presentation.Controllers
{
    public class AlerteController : Controller
    {
        // GET: Alerte
        public ActionResult Index()
        {
            return View();
        }

        // GET: Alerte/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize]
        // GET: Alerte/Create
        public ActionResult Create()
        {
            AlerteVM avm = new AlerteVM();
            IServiceDisease servicealerte = new ServiceDisease();
            avm.AllDisease = (ICollection<Disease>)servicealerte.GetAll();
            return View(avm);     
        }
        // POST: Alerte/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(AlerteVM avm)
        {
            IServiceDisease service = new ServiceDisease();
            IServiceAlerte serviceAlerte = new ServiceAlerte();
            IWContext context = new IWContext();
            avm.NameDiseas = avm.NameDiseas.Trim();
            Disease disease = service.FindByName(avm.NameDiseas);
            if (disease != null)
            {
                string userid = User.Identity.GetUserId();               
                ApplicationUser user = context.Users.FirstOrDefault(x => x.Id == userid);

                if (user != null)
                {
                    Alerte alerte = new Alerte()
                    {
                        Disease = disease,
                        User = user
                    };
                    //serviceAlerte.Add(alerte);
                    //serviceAlerte.Commit();
                    context.Alertes.Add(alerte);
                    context.SaveChanges();
                    context.Dispose();

                }
            }            
            return Create();
        }

        // GET: Alerte/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Alerte/Edit/5
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

        // GET: Alerte/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Alerte/Delete/5
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
