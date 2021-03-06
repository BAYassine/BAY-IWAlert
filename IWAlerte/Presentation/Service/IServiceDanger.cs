﻿using Presentation.IService;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Service
{
    public interface IServiceDanger : IService<Danger>
    {
        Danger GetDangerByAlert(Alerte alerte);
    }
}