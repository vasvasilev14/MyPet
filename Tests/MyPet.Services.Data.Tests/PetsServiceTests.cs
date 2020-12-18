namespace MyPet.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Moq;
    using MyPet.Data.Common.Repositories;
    using MyPet.Data.Models;
    using MyPet.Web.ViewModels.Pets;
    using Xunit;

    public class PetsServiceTests
    {
        [Fact]
        public async Task AddingAsyncAPetTestAndGetCount()
        {
            var list = new List<Pet>();
            var mockRepo = new Mock<IDeletableEntityRepository<Pet>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Pet>()))
                    .Callback(
                    (Pet pet) => list.Add(pet));
            var service = new PetsService(mockRepo.Object);

            var inputModel = new AddPetInputModel
            {
                BreedId = 1,
                CityId = 1,
                Id = 1,
                Name = "Gosho",
                DateOfBirth = new DateTime(2008, 3, 1, 7, 0, 0),
                Gender = "Male",

            };
            var imagePaths = new List<string>();
            imagePaths.Add("vasko.com");
            await service.AddAsync(inputModel, 1, "Pesho", imagePaths);
            Assert.Equal(1, service.GetCount());
        }

        [Fact]
        public async Task DeleteAsyncPet()
        {
            var list = new List<Pet>();
            var mockRepo = new Mock<IDeletableEntityRepository<Pet>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Pet>()));
            mockRepo.Setup(x => x.Delete(It.IsAny<Pet>()))
                  .Callback(
                  (Pet pet) => list.Remove(pet));
            var service = new PetsService(mockRepo.Object);

            var pet = new Pet
            {
                BreedId = 1,
                CityId = 1,
                Id = 1,
                Name = "GoshoCat",
                DateOfBirth = new DateTime(2008, 3, 1, 7, 0, 0),
                SpecieId = 1,
                AddedByUserId = "PeshoId",
            };
            list.Add(pet);

            await service.DeleteAsync(1, "PeshoId");

            Assert.Equal(0, service.GetCount());
        }

        [Fact]
        public async Task DeleteAsyncPetWithWrongUserId()
        {
            var list = new List<Pet>();
            var mockRepo = new Mock<IDeletableEntityRepository<Pet>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.Delete(It.IsAny<Pet>()));
            var service = new PetsService(mockRepo.Object);

            var pet = new Pet
            {
                BreedId = 1,
                CityId = 1,
                Id = 1,
                Name = "GoshoCat",
                DateOfBirth = new DateTime(2008, 3, 1, 7, 0, 0),
                SpecieId = 1,
                AddedByUserId = "PeshoId",
            };
            list.Add(pet);
            Assert.False(await service.DeleteAsync(1, "WrongId"));
        }

        [Fact]
        public async Task MethodShoudReturnAllPets()
         {
            var list = new List<Pet>();
            var mockRepo = new Mock<IDeletableEntityRepository<Pet>>();
            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());

            var service = new PetsService(mockRepo.Object);
            var viewModel = new PetsInListViewModel
            {
                AddedByUserId = "PeshoId",
                BreedId = 1,
                CityId = 1,
                DateOfBirth = new DateTime(2008, 3, 1, 7, 0, 0),
                Id = 1,
                Name = "PeshoCat",
            };
            var pet = new Pet
            {
                AddedByUserId = "PeshoId",
                BreedId = 1,
                CityId = 1,
                DateOfBirth = new DateTime(2008, 3, 1, 7, 0, 0),
                Id = 1,
                Name = "PeshoCat",
            };
            list.Add(pet);
           service.GetAll<PetsInListViewModel>(1);

        }
}
}
