namespace MyPet.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyPet.Data.Models;
    using MyPet.Services.Data;
    using MyPet.Web.ViewModels.Pets;

    public class PetsController : BaseController
    {
        private readonly IBreedsService breedsService;
        private readonly IPetsService petsService;
        private readonly ICitiesService citiesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public PetsController(
            IBreedsService breedsService,
            IPetsService petsService,
            ICitiesService citiesService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.breedsService = breedsService;
            this.petsService = petsService;
            this.citiesService = citiesService;
            this.userManager = userManager;
            this.environment = environment;
        }

        [Authorize]
        public IActionResult Add(int specieId)
        {
            var viewModel = new AddPetInputModel();

            viewModel.Breeds = this.breedsService.GetAllAsKeyValuePairs(specieId);
            viewModel.Cities = this.citiesService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddPetInputModel input, int specieId)
        {
            if (!this.ModelState.IsValid)
            {
                input.Breeds = this.breedsService.GetAllAsKeyValuePairs(specieId);
                input.Cities = this.citiesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.petsService.AddAsync(input, specieId, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.Breeds = this.breedsService.GetAllAsKeyValuePairs(specieId);
                input.Cities = this.citiesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            return this.Redirect("/");
        }

      

        public IActionResult All(int id = 1)
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
                Pets = this.petsService.GetAll<PetsInListViewModel>(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }
    }
}
