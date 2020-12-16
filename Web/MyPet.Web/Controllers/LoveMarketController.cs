﻿namespace MyPet.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class LoveMarketController : BaseController
    {
        [Authorize]
        public IActionResult Index()
            {
                return this.View();
            }
    }
}
