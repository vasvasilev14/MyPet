namespace MyPet.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyPet.Data.Models;
    using MyPet.Services.Data;

    public class ProfilesController : BaseController
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IProfilesService profilesService;

        public ProfilesController(
            SignInManager<ApplicationUser> signInManager,
            IProfilesService profilesService)
        {
            this.signInManager = signInManager;
            this.profilesService = profilesService;
        }

        public IActionResult Index(int petId)
        {
            if (this.signInManager.IsSignedIn(this.User))
            {
                var viewModel = this.profilesService.PetProfileInfo(petId);
                return this.View(viewModel);
            }

            return this.Redirect("/Pets/All");
        }
    }
}
