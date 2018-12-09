using Presentation.Infrastructure;
using Presentation.IService;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Service
{
    public class ServiceSymptom : Service<Symptom>, IServiceSymptom
    {
        static IDatabaseFactory Factory = new DatabaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);

        public ICollection<Symptom> GetByDisease(Disease disease)
        {
            ICollection<Symptom> symptoms = new HashSet<Symptom>();
            symptoms = GetMany(c => c.Disease.Id == disease.Id).ToList();
            return symptoms;
        }

        public ServiceSymptom() : base(utk)
        {

        }
    }
}