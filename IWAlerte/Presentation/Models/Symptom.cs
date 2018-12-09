using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class Symptom
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public Disease Disease { get; set; }
    }
}