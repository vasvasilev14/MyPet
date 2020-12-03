namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using MyPet.Data.Common.Repositories;
    using MyPet.Data.Models;
    using MyPet.Services.Mapping;
    using MyPet.Web.ViewModels.Pets;

    public class ProfilesService : IProfilesService
    {
        private readonly IDeletableEntityRepository<Pet> petsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Image> imagesRepository;

        public ProfilesService(
            IDeletableEntityRepository<Pet> petsRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<Image> imagesRepository)
        {
            this.petsRepository = petsRepository;
            this.userRepository = userRepository;
            this.imagesRepository = imagesRepository;
        }

        public async Task<bool> DeleteAsync(string id, string userId)
        {
            var image = this.imagesRepository.All().FirstOrDefault(x => x.Id == id);

            if (userId != image.AddedByUserId)
            {
                return false;
            }

            this.imagesRepository.Delete(image);
            await this.imagesRepository.SaveChangesAsync();
            return true;
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
                Email = x.AddedByUser.Email,
                Images = x.Images.Select(x => new PetImagesViewModel { ImageUrl = "/images/pets/" + x.Id + "." + x.Extension, Id = x.Id }).ToList(),
                ImageUrl = x.Images.FirstOrDefault().RemoteImageUrl ?? "/images/pets/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension,
                Name = x.Name,
                TotalLikes = x.Likes.Count() == 0 ? 0 : x.Likes.Sum(c => c.Counter),
            }).FirstOrDefault();
        }
    }
}
