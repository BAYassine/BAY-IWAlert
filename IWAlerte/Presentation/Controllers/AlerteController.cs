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
            IServiceSymptom servicesymptom = new ServiceSymptom();
            avm.AllDisease = (ICollection<Disease>)servicealerte.GetAll();
            foreach(var x in avm.AllDisease)
            {
                x.Symptoms = servicesymptom.GetByDisease(x);
            }
            return View(avm);     
        }
        // POST: Alerte/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(AlerteVM avm)
        {
            IServiceDisease service = new ServiceDisease();
            IServiceAlerte serviceAlerte = new ServiceAlerte();
            IServiceDanger servicedanger = new ServiceDanger();
            IWContext context = new IWContext();
            avm.NameDiseas = avm.NameDiseas.Trim();
            Disease disease = context.Diseases.Where(d => d.Name.Equals(avm.NameDiseas)).FirstOrDefault();
            //context.Entry(disease).State = System.Data.Entity.EntityState.Unchanged;
            //Disease disease = service.FindByName(avm.NameDiseas);         
            if (disease != null)
            {
                string userid = User.Identity.GetUserId();               
                ApplicationUser user = context.Users.FirstOrDefault(x => x.Id == userid);
                Alerte LastAlerte = serviceAlerte.GetAlerteByUser(user);
                if( (LastAlerte != null /* && LastAlerte.DateTime.Subtract(DateTime.Today).Days >= 7 */) || LastAlerte == null)
                {
                    if (user != null)
                    {
                                               
                        Alerte a = context.Alertes.Where(c => c.Disease.Name.Equals(disease.Name)).FirstOrDefault();
                        if(a != null)
                        {
                            Alerte alerte = new Alerte()
                            {
                                Disease = disease,
                                User = user,
                                DateTime = DateTime.Today,
                                Danger = a.Danger
                            };
                            context.Alertes.Add(alerte);
                            context.SaveChanges();
                        }
                        else
                        {
                            Danger d = new Danger() {
                                Date = DateTime.Now                                     
                            };
                            Alerte alerte = new Alerte()
                            {
                                Disease = disease,
                                User = user,
                                DateTime = DateTime.Today,
                                Danger = d
                            };
                            context.Alertes.Add(alerte);
                            context.SaveChanges();
                        }
                        

                       /* ICollection<Danger> Dangers = context.Dangers.Include("Alertes").ToList();
                        Danger danger = new Danger();
                        foreach(var D in Dangers)
                        {
                            foreach(var x in D.Alertes)
                            {
                                Alerte y = context.Alertes.Include("Disease").Where(c => c.Id == x.Id).SingleOrDefault();
                                if (y.Disease.Name.Equals(alerte.Disease.Name))
                                    danger = D;
                            }
                        }
                        danger.Date = DateTime.Now;
                        //Danger danger = servicedanger.GetDangerByAlert(alerte);
                        if(danger == null)
                        {
                            
                            danger.Alertes.Add(alerte);
                            context.Dangers.Add(danger);
                            alerte.Danger = danger;
                            context.SaveChanges();
                      
                        }
                        else
                        {
                            danger.Alertes.Add(alerte);
                            context.SaveChanges();
                        }*/
                        context.Dispose();
                        return View("Sucess");
                    }
                }
                else
                {
                    context.Dispose();
                    return View("Error");
                }
                
            }
            context.Dispose();
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
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Sucess()
        {
            return View();
        }
    }
}
