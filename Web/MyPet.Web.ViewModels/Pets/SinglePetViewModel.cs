namespace MyPet.Web.ViewModels.Pets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using MyPet.Data.Models;
    using MyPet.Services.Mapping;

    public class SinglePetViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string AddedByUserId { get; set; }

        public string SpecieName { get; set; }

        public string BreedName { get; set; }

        public string CityName { get; set; }

        public string ImageUrl { get; set; }

        public string Email { get; set; }

        public ICollection<PetImagesViewModel> Images { get; set; }

        public ICollection<LikesPetViewModel> Likes { get; set; }

        public int TotalLikes { get; set; }
    }
}
