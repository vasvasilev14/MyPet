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
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Pet> petsRepository;

        public PetsService(IDeletableEntityRepository<Pet> petsRepository)
        {
            this.petsRepository = petsRepository;
        }

        public async Task AddAsync(AddPetInputModel input, int specieId, string userId, string imagePath)
        {

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
            };
            Directory.CreateDirectory($"{imagePath}/pets/");
            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    AddedByUserId = userId,
                    Extension = extension,
                };
                pet.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/pets/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

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
    }
}
