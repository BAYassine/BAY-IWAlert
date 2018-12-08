using Presentation.Infrastructure;
using Presentation.IService;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Service
{
    public class ServiceDisease : Service<Disease> , IServiceDisease
    {
        static IDatabaseFactory Factory = new DatabaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);
        public ServiceDisease() : base(utk)
        {

        }
    }
}