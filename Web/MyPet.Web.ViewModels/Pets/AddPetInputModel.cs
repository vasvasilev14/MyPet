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
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [CurrentYearMaxValueAttribute(1950)]
        [Display(Name = "Date of Birthday")]
        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public int BreedId { get; set; }

        public int CityId { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Breeds { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Cities { get; set; }
            }
}
