using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class Alerte
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Disease Disease { get; set; }
    }
}