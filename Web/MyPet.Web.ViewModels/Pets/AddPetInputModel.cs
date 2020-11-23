using MyFirstAspNetCoreApplication.ValidationAttributes;
using MyPet.Data.Models;
using MyPet.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPet.Web.ViewModels.Pets
{
    public class AddPetInputModel : IMapFrom<Pet>
    {
        [MinLength(2)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [CurrentYearMaxValueAttribute(1950)]
        [Display(Name = "Date of Birthday")]
        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public int BreedId { get; set; }

        public int CityId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Breeds { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Cities { get; set; }

    }
}
