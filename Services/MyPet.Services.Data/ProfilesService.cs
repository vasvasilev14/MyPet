namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MyPet.Data.Common.Repositories;
    using MyPet.Data.Models;
    using MyPet.Services.Mapping;
    using MyPet.Web.ViewModels.Pets;

    public class ProfilesService : IProfilesService
    {
        private readonly IDeletableEntityRepository<Pet> petsRepository;

        public ProfilesService(IDeletableEntityRepository<Pet> petsRepository)
        {
            this.petsRepository = petsRepository;
        }

        public SinglePetViewModel PetProfileInfo(int petId)
        {
            return this.petsRepository.AllAsNoTracking().Where(x => x.Id == petId).Select(x => new SinglePetViewModel
            {
                SpecieName = x.Specie.Name,
                AddedByUserId = x.AddedByUserId,
                BreedName = x.Breed.Name,
                CityName = x.City.Name,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender,
                Id = x.Id,
                Images = x.Images.Select(x => new PetImagesViewModel { ImageUrl = "/images/pets/" + x.Id + "." + x.Extension }).ToList(),
                ImageUrl = x.Images.FirstOrDefault().RemoteImageUrl ?? "/images/pets/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension,
                Name = x.Name,
                TotalLikes = x.Likes.Count() == 0 ? 0 : x.Likes.Sum(c => c.Counter),
            }).FirstOrDefault();
        }
    }
}
