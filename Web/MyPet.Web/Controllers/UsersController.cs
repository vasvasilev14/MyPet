using Microsoft.AspNetCore.Mvc;
using MyPet.Services.Data;
using MyPet.Web.ViewModels.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPet.Web.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IPetsService petsService;

        public UsersController(IPetsService petsService)
        {
            this.petsService = petsService;
        }

        public IActionResult MyPets(string addedByUserId,int id = 1)
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
    }
}
