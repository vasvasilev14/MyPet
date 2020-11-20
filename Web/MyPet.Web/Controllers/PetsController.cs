namespace MyPet.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyPet.Web.ViewModels.Pets;

    public class PetsController : BaseController
    {
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddPetInputModel input, string specie)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.Redirect("/");
        }
    }
}
