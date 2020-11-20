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
        
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public int BreedId { get; set; }
    }
}
