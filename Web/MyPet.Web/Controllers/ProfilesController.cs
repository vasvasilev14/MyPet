﻿namespace MyPet.Web.Controllers
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
    using MyPet.Web.ViewModels.Pets;
    using MyPet.Web.ViewModels.Profiles;

    public class ProfilesController : BaseController
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IProfilesService profilesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly Cloudinary cloudinary;
        private readonly ICommentsService commentsService;

        public ProfilesController(
            SignInManager<ApplicationUser> signInManager,
            IProfilesService profilesService,
            UserManager<ApplicationUser> userManager,
            Cloudinary cloudinary,
            ICommentsService commentsService)
        {
            this.signInManager = signInManager;
            this.profilesService = profilesService;
            this.userManager = userManager;
            this.cloudinary = cloudinary;
            this.commentsService = commentsService;
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
            var isDeleted = await this.profilesService.DeleteAsyncPhoto(id, userId);
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

            if (input.Name == null)
            {
                input.Name = this.profilesService.GetName(input.Id);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            if (input.Images != null)
            {
                var result = await CloudinaryExtentsion.UploadAsync(this.cloudinary, input.Images);
                await this.profilesService.UpdateAsync(input.Id, input, user.Id, result);
            }

            await this.profilesService.UpdateAsync(input.Id, input, user.Id);

            return this.Redirect($"/Profiles/Index?petId={input.Id}");
        }

        [Authorize]
        public IActionResult AddComment()
        {
            return this.Redirect("/");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment(string description, int petId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (description != null)
            {
                await this.commentsService.AddCommentAsync(description, petId, userId);
            }

            return this.Redirect($"/Profiles/Index?petId={petId}");
        }

        [Authorize]
        public async Task<IActionResult> DeleteComment(int id, int petId)
        {
            var userId = this.userManager.GetUserId(this.User);
            var isDeleted = await this.commentsService.DeleteCommentAsync(id, userId);
            if (!isDeleted)
            {
                return this.Redirect("/Home/Error");
            }

            return this.Redirect($"/Profiles/Index?petId={petId}");
        }
    }
}
