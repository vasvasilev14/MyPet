using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPet.Web.Controllers
{
    public class SaleMarketController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
