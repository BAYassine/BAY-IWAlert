using Microsoft.AspNet.Identity.EntityFramework;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Presentation
{
    public class IWContext : IdentityDbContext<User>
    {
        public IWContext() : base("name=IWConnection")
        {

        }
        public static IWContext Create()
        {
            return new IWContext();
        }
    }
}