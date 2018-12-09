using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models.ViewModel
{
    public class AlerteVM
    {
        public AlerteVM()
        {
            AllDisease = new HashSet<Disease>();
        }
        public ApplicationUser User { get; set; }
        public Disease Disease { get; set; }
        public string NameDiseas { get; set; }
        public ICollection<Disease> AllDisease { get; set; }
        public DateTime Date { get; set; }
    }
}