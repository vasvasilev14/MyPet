namespace MyPet.Web.ViewModels.Profiles
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;
    using MyPet.Data.Models;
    using MyPet.Services.Mapping;

    public class EditProfileInputModel
    {
        public int Id { get; set; }

       // public string Description { get; set; }

        [MinLength(2)]
        public string Name { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

    }
}
