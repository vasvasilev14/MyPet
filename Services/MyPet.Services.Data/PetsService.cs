namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MyPet.Data.Common.Repositories;
    using MyPet.Data.Models;
    using MyPet.Web.ViewModels.Pets;

    public class PetsService : IPetsService
    {
        private readonly IDeletableEntityRepository<Pet> petsRepository;

        public PetsService(IDeletableEntityRepository<Pet> petsRepository)
        {
            this.petsRepository = petsRepository;
        }

        public async Task AddAsync(AddPetInputModel input, int specieId)
        {

            string genderAsString = input.Gender;
            Gender gender = (Gender)Enum.Parse(typeof(Gender), genderAsString);
            var pet = new Pet()
            {
                BreedId = input.BreedId,
                Name = input.Name,
                Gender = gender,
                DateOfBirth = input.DateOfBirth,
                CityId = input.CityId,
                SpecieId= specieId,
            };

            await this.petsRepository.AddAsync(pet);
            await this.petsRepository.SaveChangesAsync();
        }
    }
}
