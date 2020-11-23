namespace MyPet.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyPet.Services.Data;
    using MyPet.Web.ViewModels.Pets;

    public class PetsController : BaseController
    {
        private readonly IBreedsService breedsService;
        private readonly IPetsService petsService;
        private readonly ICitiesService citiesService;

        public PetsController(IBreedsService breedsService, IPetsService petsService, ICitiesService citiesService)
        {
            this.breedsService = breedsService;
            this.petsService = petsService;
            this.citiesService = citiesService;
        }

        public IActionResult Add(int specieId)
        {
            var viewModel = new AddPetInputModel();

            viewModel.Breeds = this.breedsService.GetAllAsKeyValuePairs(specieId);
            viewModel.Cities = this.citiesService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPetInputModel input, int specieId)
        {
            if (!this.ModelState.IsValid)
            {
                input.Breeds = this.breedsService.GetAllAsKeyValuePairs(specieId);
                input.Cities = this.citiesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            await this.petsService.AddAsync(input,specieId);

            return this.Redirect("/");
        }
    }
}
