namespace MyPet.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyPet.Data.Models;
    using MyPet.Services.Data;
    using MyPet.Web.ClounaryHelper;
    using MyPet.Web.ViewModels.Profiles;

    public class ProfilesController : BaseController
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IProfilesService profilesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly Cloudinary cloudinary;

        public ProfilesController(
            SignInManager<ApplicationUser> signInManager,
            IProfilesService profilesService,
            UserManager<ApplicationUser> userManager,
             Cloudinary cloudinary)
        {
            this.signInManager = signInManager;
            this.profilesService = profilesService;
            this.userManager = userManager;
            this.cloudinary = cloudinary;
        }

        [Authorize]
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

        [Authorize]
        public IActionResult Edit(int id)
        {
            this.ViewData["petId"] = id;
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditProfileInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var result = await CloudinaryExtentsion.UploadAsync(this.cloudinary, input.Images);
            var user = await this.userManager.GetUserAsync(this.User);
            await this.profilesService.UpdateAsync(input.Id, input, user.Id, result);

            return this.Redirect($"/Profiles/Index?petId={input.Id}");
        }

    }
}
