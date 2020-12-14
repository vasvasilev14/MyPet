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
    using MyPet.Web.ViewModels.Profiles;

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

        public string GetName(int id)
        {
            var targetPet = this.petsRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == id);
            var name = targetPet.Name;
            return name;
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
                Images = x.Images.Select(x => new PetImagesViewModel { ImageUrl = x.Url, Id = x.Id, CreatedOn = x.CreatedOn }).OrderByDescending(x => x.CreatedOn).ToList(),
                ImageUrl = x.Images.OrderBy(x => x.CreatedOn).FirstOrDefault().Url,
                Name = x.Name,
                Likes = x.Likes.Select(x => new LikesPetViewModel { Email = x.User.Email, PetId = x.Id, UserId = x.UserId, CreatedOn = x.CreatedOn }).ToList(),
                TotalLikes = x.Likes.Count() == 0 ? 0 : x.Likes.Sum(c => c.Counter),
                Description = x.Description ?? string.Empty,
                Comments = x.Comments.Select(x => new PetCommentViewModel { AddedByUserId = x.AddedByUserId, CreatedOn = x.CreatedOn, Description = x.Description, Id = x.Id, Email = x.AddedByUser.Email }).OrderByDescending(x => x.CreatedOn).ToList(),
            }).FirstOrDefault();
        }

        public async Task UpdateAsync(int id, EditProfileInputModel input, string userId, List<string> imagePaths)
        {
            var images = new List<Image>();

            foreach (var imagePath in imagePaths)
            {
                var image = new Image()
                {
                    Url = imagePath,
                    AddedByUserId = userId,
                    PetId = input.Id,
                };
                images.Add(image);
            }

            var profiles = this.petsRepository.All().FirstOrDefault(x => x.Id == id);
            profiles.Name = input.Name;
            profiles.Images = images;
            if (input.Description != null)
            {
                profiles.Description = input.Description;
            }

            await this.petsRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, EditProfileInputModel input, string userId)
        {
            var profiles = this.petsRepository.All().FirstOrDefault(x => x.Id == id);
            profiles.Name = input.Name;
            if (input.Description != null)
            {
                profiles.Description = input.Description;
            }

            await this.petsRepository.SaveChangesAsync();
        }
    }
}
