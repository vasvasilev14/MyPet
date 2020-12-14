namespace MyPet.Web.ViewModels.Pets
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;
    using MyFirstAspNetCoreApplication.ValidationAttributes;
    using MyPet.Data.Models;
    using MyPet.Services.Mapping;

    public class AddPetInputModel : IMapFrom<Pet>
    {
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CurrentYearMaxValueAttribute(1950)]
        [Display(Name = "Date of Birthday")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]

        [Display(Name = "Breed")]
        public int BreedId { get; set; }

        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }

        [Required]
        [Display(Name = "Upload Images")]
        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Breeds { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Cities { get; set; }
            }
}
