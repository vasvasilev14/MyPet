﻿namespace MyPet.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class LoveMarketController : BaseController
    {
            public IActionResult Index()
            {
                return this.View();
            }
    }
}
