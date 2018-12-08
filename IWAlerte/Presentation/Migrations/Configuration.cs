namespace Presentation.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Service;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Presentation.IWContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Presentation.IWContext context)
        {
            var UserManager = new UserManager<User>(new UserStore<User>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var DiseaseService = new ServiceDisease();
            string name = "Admin";
            string password = "123456";
            if (!RoleManager.RoleExists(name))
            {
                var roleresult = RoleManager.Create(new IdentityRole(name));
                RoleManager.Create(new IdentityRole("Membre"));
            }
            var user = new User();
            user.UserName = name;
            var adminresult = UserManager.Create(user, password);
            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, name);
            }
            base.Seed(context);
        }
    }
}
