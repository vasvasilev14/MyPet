using Microsoft.AspNetCore.Mvc;
using MyPet.Services.Data;
using MyPet.Web.ViewModels.About;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPet.Web.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IAboutService aboutService;

        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        public IActionResult Index()
        {            
            var viewModel = this.aboutService.GetAboutInfo();
            
            return this.View(viewModel);
        }
    }
}
