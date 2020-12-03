namespace MyPet.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyPet.Data.Models;
    using MyPet.Services.Data;
    using MyPet.Web.ViewModels.Pets;

    public class UsersController : BaseController
    {
        private readonly IPetsService petsService;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(IPetsService petsService, UserManager<ApplicationUser> userManager)
        {
            this.petsService = petsService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult MyPets(string addedByUserId, int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 8;
            var viewModel = new PetsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                PetsCount = this.petsService.GetCount(),
                Pets = this.petsService.GetMine<PetsInListViewModel>(id, addedByUserId, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int petId)
        {
            var userId = this.userManager.GetUserId(this.User);
            var isDeleted = await this.petsService.DeleteAsync(petId, userId);
            if (!isDeleted)
            {
                return this.Redirect("/Home/Error");
            }

            return this.Redirect($"/Users/MyPets?addedByUserId={userId}");
        }
    }
}
