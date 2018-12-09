using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class Disease
    {
        public Disease()
        {
            Symptoms = new HashSet<Symptom>();
            Advice = new HashSet<Advice>();
            Prevention_Controls = new HashSet<Prevention_Control>();
            Diagnostics = new HashSet<Diagnostic>();
            Treatements = new HashSet<Treatement>();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public ICollection<Symptom> Symptoms { get; set; }
        public ICollection<Advice> Advice { get; set; }
        public ICollection<Prevention_Control> Prevention_Controls { get; set; }
        public ICollection<Diagnostic> Diagnostics { get; set; }
        public ICollection<Treatement> Treatements { get; set; }
        public Statistic Statistics { get; set; }
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Disease p = (Disease)obj;
                return p.Id == this.Id;
            }
        }
    }

}