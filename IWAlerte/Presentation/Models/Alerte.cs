using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class Alerte
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public virtual Disease Disease { get; set; }
    }
}