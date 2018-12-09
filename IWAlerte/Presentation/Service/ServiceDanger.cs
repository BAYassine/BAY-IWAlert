using Presentation.Infrastructure;
using Presentation.IService;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Service
{
    public class ServiceDanger : Service<Danger>, IServiceDanger
    {
        static IDatabaseFactory Factory = new DatabaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);
        public ServiceDanger() : base(utk)
        {

        }

        public Danger GetDangerByAlert(Alerte alerte)
        {
            if (alerte.Danger == null)
                return null;
            foreach (var danger in GetMany(c => c.Id > 0).ToList())
            {              
                if (alerte.Danger.Id == danger.Id)
                    return danger;
            }
            return null;
        }
    }
}