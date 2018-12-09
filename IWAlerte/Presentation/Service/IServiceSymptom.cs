using Presentation.IService;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Service
{
    public interface IServiceSymptom : IService<Symptom>
    {
        ICollection<Symptom> GetByDisease(Disease disease);
    }
}