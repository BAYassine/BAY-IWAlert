﻿using Presentation.Infrastructure;
using Presentation.IService;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Service
{
    public class ServiceAlerte : Service<Alerte>, IServiceAlerte
    {
        static IDatabaseFactory Factory = new DatabaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);
        public ServiceAlerte() : base(utk)
        {

        }

        public Alerte GetAlerteByUser(ApplicationUser user)
        {
            return GetMany(c => c.User.Id == user.Id).LastOrDefault();
        }
    }
}