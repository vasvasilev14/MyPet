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
        [Required]
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Display(Name = "Upload Images")]
        public IEnumerable<IFormFile> Images { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}
