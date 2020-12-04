namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyPet.Data.Common.Repositories;
    using MyPet.Data.Models;
    using MyPet.Services.Mapping;
    using MyPet.Web.ViewModels.Pets;

    public class PetsService : IPetsService
    {
        private readonly IDeletableEntityRepository<Pet> petsRepository;

        public PetsService(IDeletableEntityRepository<Pet> petsRepository)
        {
            this.petsRepository = petsRepository;
        }

        public async Task AddAsync(AddPetInputModel input, int specieId, string userId, List<string> imagePaths)
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

            string genderAsString = input.Gender;
            Gender gender = (Gender)Enum.Parse(typeof(Gender), genderAsString);

            var pet = new Pet()
            {
                AddedByUserId = userId,
                BreedId = input.BreedId,
                Name = input.Name,
                Gender = gender,
                DateOfBirth = input.DateOfBirth,
                CityId = input.CityId,
                SpecieId = specieId,
                Images = images,
            };

            await this.petsRepository.AddAsync(pet);
            await this.petsRepository.SaveChangesAsync();
        }

        public int GetCount()
        {
            return this.petsRepository.All().Count();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var pets = this.petsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();
            return pets;
        }

        public IEnumerable<T> GetMine<T>(int page, string addedByUserId, int itemsPerPage = 12)
        {
            var pets = this.petsRepository.AllAsNoTracking().Where(x => x.AddedByUserId == addedByUserId)
               .OrderByDescending(x => x.Id)
               .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
               .To<T>().ToList();
            return pets;
        }

        public async Task<bool> DeleteAsync(int petId, string userId)
        {
            var pet = this.petsRepository.All().FirstOrDefault(x => x.Id == petId);

            if (userId != pet.AddedByUserId)
            {
                return false;
            }

            this.petsRepository.Delete(pet);
            await this.petsRepository.SaveChangesAsync();
            return true;
        }
    }
}
