namespace MyPet.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyPet.Data.Models;
    using MyPet.Services.Data;

    public class ProfilesController : BaseController
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IProfilesService profilesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProfilesController(
            SignInManager<ApplicationUser> signInManager,
            IProfilesService profilesService,
            UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.profilesService = profilesService;
            this.userManager = userManager;
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

        [Authorize]
        public async Task<IActionResult> Delete(string id, int petId)
        {
                var userId = this.userManager.GetUserId(this.User);
                var isDeleted = await this.profilesService.DeleteAsync(id, userId);
                if (!isDeleted)
                {
                    return this.Redirect("/Home/Error");
                }

                return this.Redirect($"/Profiles/Index?petId={petId}");
        }
}
}
