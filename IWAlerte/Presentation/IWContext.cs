using Microsoft.AspNet.Identity.EntityFramework;
using Presentation.Models;
using Presentation.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Presentation
{

    public class IWContext : IdentityDbContext<ApplicationUser>
    {
        public IWContext() : base("name=IWConnection")
        {
            //Database.SetInitializer<IWContext>(new MyCustomStrategy());
        }
        public static IWContext Create()
        {
            return new IWContext();
        }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Danger> Dangers { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Prevention_Control> Prevention_Controls { get; set; }
        public DbSet<Advice> Advices { get; set; }
        public DbSet<Statistic> Statistic { get; set; }
        public DbSet<Diagnostic> Diagnostics { get; set; }
        public DbSet<Treatement> Treatements { get; set; }
        public DbSet<Alerte> Alertes { get; set; }
    }
}