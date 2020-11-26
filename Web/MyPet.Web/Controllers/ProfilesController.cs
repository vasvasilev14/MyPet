namespace MyPet.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyPet.Data.Models;

    public class ProfilesController : BaseController
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public ProfilesController(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult Index(int petId)
        {

            if (this.signInManager.IsSignedIn(this.User))
            {
                return this.View();
            }

            return this.Redirect("/Pets/All");           
        }
    }
}
