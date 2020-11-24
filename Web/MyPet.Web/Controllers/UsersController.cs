using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPet.Web.Controllers
{
    public class UsersController : BaseController
    {
        public IActionResult MyPets()
        {
            return this.View();
        }
    }
}
