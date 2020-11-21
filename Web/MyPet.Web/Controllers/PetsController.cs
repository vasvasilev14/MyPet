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

        public PetsController(IBreedsService breedsService, IPetsService petsService)
        {
            this.breedsService = breedsService;
            this.petsService = petsService;
        }

        public IActionResult Add()
        {
            var viewModel = new AddPetInputModel();
            viewModel.Breeds = this.breedsService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPetInputModel input, string specie)
        {
            if (!this.ModelState.IsValid)
            {
                input.Breeds = this.breedsService.GetAllAsKeyValuePairs();
                return this.View(input);
            }
            await this.petsService.AddAsync(input);

            return this.Redirect("/");
        }
    }
}
