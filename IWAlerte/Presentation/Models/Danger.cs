using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class Danger
    {
        public Danger()
        {
            Alertes = new HashSet<Alerte>();
        }
        public int Id { get; set; }
        public bool IsCorrect { get; set; }
        public int ApprovedBy { get; set; }
        public Boolean Notified { get; set; } = false;
        public DateTime Date { get; set; }
        public Disease Disease { get; set; }
        public ICollection<Alerte> Alertes { get; set; }
    }
}