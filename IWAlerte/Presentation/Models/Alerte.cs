﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class Alerte
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public Disease Disease { get; set; }
        public DateTime DateTime { get; set; }
        public Danger Danger { get; set; }
    }
}