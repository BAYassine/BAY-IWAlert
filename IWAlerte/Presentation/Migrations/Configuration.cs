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
            IServiceDisease ServiceDisease = new ServiceDisease();
            Disease Disease = new Disease() {
                Name = "Chikungunya",
                Description = "Chikungunya is a mosquito-borne viral disease first described during an outbreak in southern Tanzania in 1952. It is an RNA virus that belongs to the alphavirus genus of the family Togaviridae. The name “chikungunya” derives from a word in the Kimakonde language, meaning “to become contorted”, and describes the stooped appearance of sufferers with joint pain (arthralgia)." 
            };
            ServiceDisease.Add(Disease);
            string name = "Admin";
            string password = "123456";
            if (!RoleManager.RoleExists(name))
            {
                var roleresult = RoleManager.Create(new IdentityRole(name));
                RoleManager.Create(new IdentityRole("Membre"));
            }
            var user = new User();
            
            Place place = new Place()
            {
                Country = "Tunisia" ,
                Town = "Tunis"
            };
            user.Place = place;
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
