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
    using MyPet.Web.ViewModels.Profiles;
    using Xunit;

    public class ProfilesServiceTests
    {

        [Fact]
        public async Task DeleteAsyncPhoto()
        {
            var listImage = new List<Image>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();
            mockRepoImage.Setup(x => x.All()).Returns(listImage.AsQueryable());
            mockRepoImage.Setup(x => x.Delete(It.IsAny<Image>()))
                  .Callback(
                  (Image image) => listImage.Remove(image));

            var mockRepoPet = new Mock<IDeletableEntityRepository<Pet>>();

            var mockRepoUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();

            var service = new ProfilesService(mockRepoPet.Object, mockRepoUser.Object, mockRepoImage.Object);

            var image = new Image
            {
                AddedByUserId = "PeshoId",
                Id = "ImageId",
                PetId = 1,
                Url = "vasko.com",
            };
            listImage.Add(image);
            await service.DeleteAsyncPhoto("ImageId", "PeshoId");
            Assert.Empty(listImage);

        }

        [Fact]
        public async Task DeleteAsyncPhotoWithWrongUserId()
        {
            var listImage = new List<Image>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();
            mockRepoImage.Setup(x => x.All()).Returns(listImage.AsQueryable());
            mockRepoImage.Setup(x => x.AddAsync(It.IsAny<Image>()));
            mockRepoImage.Setup(x => x.Delete(It.IsAny<Image>()));
            var mockRepoPet = new Mock<IDeletableEntityRepository<Pet>>();
            var mockRepoUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            var service = new ProfilesService(mockRepoPet.Object, mockRepoUser.Object, mockRepoImage.Object);

            var image = new Image
            {
                AddedByUserId = "PeshoId",
                Id = "ImageId",
                PetId = 1,
                Url = "vasko.com",
            };
            listImage.Add(image);
            Assert.False(await service.DeleteAsyncPhoto("ImageId", "WrongId"));
        }

        [Fact]
        public void ShouldReturnName()
        {
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();
            var listPet = new List<Pet>();
            var mockRepoPet = new Mock<IDeletableEntityRepository<Pet>>();
            mockRepoPet.Setup(x => x.AllAsNoTracking()).Returns(listPet.AsQueryable());
            mockRepoPet.Setup(x => x.AddAsync(It.IsAny<Pet>()));
            mockRepoPet.Setup(x => x.Delete(It.IsAny<Pet>()));
            var mockRepoUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            var service = new ProfilesService(mockRepoPet.Object, mockRepoUser.Object, mockRepoImage.Object);

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

            listPet.Add(pet);
            var actualName = service.GetName(1);
            Assert.Equal("GoshoCat", actualName);
        }

        [Fact]
        public void ShouldReturnPetProfileInfo()
        {
            var listImage = new List<Image>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();
            mockRepoImage.Setup(x => x.All()).Returns(listImage.AsQueryable());
            mockRepoImage.Setup(x => x.AddAsync(It.IsAny<Image>()));
            mockRepoImage.Setup(x => x.Delete(It.IsAny<Image>()));

            var listPet = new List<Pet>();
            var mockRepoPet = new Mock<IDeletableEntityRepository<Pet>>();
            mockRepoPet.Setup(x => x.AllAsNoTracking()).Returns(listPet.AsQueryable());
            mockRepoPet.Setup(x => x.AddAsync(It.IsAny<Pet>()));
            mockRepoPet.Setup(x => x.Delete(It.IsAny<Pet>()));

            var listUser = new List<ApplicationUser>();
            var mockRepoUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockRepoUser.Setup(x => x.All()).Returns(listUser.AsQueryable());
            mockRepoUser.Setup(x => x.Delete(It.IsAny<ApplicationUser>()));
            var service = new ProfilesService(mockRepoPet.Object, mockRepoUser.Object, mockRepoImage.Object);
            var comments = new List<Comment>();
            var images = new List<Image>();
            var likes = new List<Like>();
            var pet = new SinglePetViewModel
            {
                SpecieName = "Cat",
                AddedByUserId = "AddedByUserId",
                BreedName = "British",
                CityName = "Sofia",
                DateOfBirth = new DateTime(2008, 3, 1, 7, 0, 0),
                Gender = Gender.Male,
                Id = 1,
                Email = "Email",
                Images = images.Select(x => new PetImagesViewModel { ImageUrl = x.Url, Id = x.Id, CreatedOn = x.CreatedOn }).OrderByDescending(x => x.CreatedOn).ToList(),
                ImageUrl = "vasko.com",
                Name = "PeshoCat",
                Likes = likes.Select(x => new LikesPetViewModel { Email = x.User.Email, PetId = x.Id, UserId = x.UserId, CreatedOn = x.CreatedOn }).ToList(),
                TotalLikes = 2,
                Description = "Az sum kotka",
                Comments = comments.Select(x => new PetCommentViewModel { AddedByUserId = x.AddedByUserId, CreatedOn = x.CreatedOn, Description = x.Description, Id = x.Id, Email = x.AddedByUser.Email }).OrderByDescending(x => x.CreatedOn).ToList(),
            };
            service.PetProfileInfo(1);
        }

        [Fact]
        public void ShouldUpdateYourPetProfile()
        {
            var listImage = new List<Image>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();
            mockRepoImage.Setup(x => x.All()).Returns(listImage.AsQueryable());
            mockRepoImage.Setup(x => x.AddAsync(It.IsAny<Image>()));
            mockRepoImage.Setup(x => x.Delete(It.IsAny<Image>()));

            var listPet = new List<Pet>();
            var mockRepoPet = new Mock<IDeletableEntityRepository<Pet>>();
            mockRepoPet.Setup(x => x.All()).Returns(listPet.AsQueryable());
            mockRepoPet.Setup(x => x.AddAsync(It.IsAny<Pet>()));
            mockRepoPet.Setup(x => x.Delete(It.IsAny<Pet>()));

            var listUser = new List<ApplicationUser>();
            var mockRepoUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockRepoUser.Setup(x => x.All()).Returns(listUser.AsQueryable());
            mockRepoUser.Setup(x => x.Delete(It.IsAny<ApplicationUser>()));
            var service = new ProfilesService(mockRepoPet.Object, mockRepoUser.Object, mockRepoImage.Object);

            var imageList = new List<string>()
            {
                "vasko.com",
            };


            var pet = new Pet
            {
                BreedId = 1,
                CityId = 1,
                Id = 1,
                Name = "GoshoCat",
                DateOfBirth = new DateTime(2008, 3, 1, 7, 0, 0),
                SpecieId = 1,
                AddedByUserId = "PeshoId",
                Description = "test",
                Images = listImage,
            };
            listPet.Add(pet);
            var viewModel = new EditProfileInputModel
            {
                Description = "newTest",
                Id = 1,
                Name = "newGoshoCat",
            };

            service.UpdateAsync(1,viewModel,"PeshoId");
            Assert.Equal("newGoshoCat", pet.Name);
            Assert.Equal("newTest", pet.Description);
        }
        [Fact]
        public void ShouldUpdateYourPetProfileWithImage()
        {
            var listImage = new List<Image>();
            var mockRepoImage = new Mock<IDeletableEntityRepository<Image>>();
            mockRepoImage.Setup(x => x.All()).Returns(listImage.AsQueryable());
            mockRepoImage.Setup(x => x.AddAsync(It.IsAny<Image>()));
            mockRepoImage.Setup(x => x.Delete(It.IsAny<Image>()));

            var listPet = new List<Pet>();
            var mockRepoPet = new Mock<IDeletableEntityRepository<Pet>>();
            mockRepoPet.Setup(x => x.All()).Returns(listPet.AsQueryable());
            mockRepoPet.Setup(x => x.AddAsync(It.IsAny<Pet>()));
            mockRepoPet.Setup(x => x.Delete(It.IsAny<Pet>()));

            var listUser = new List<ApplicationUser>();
            var mockRepoUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockRepoUser.Setup(x => x.All()).Returns(listUser.AsQueryable());
            mockRepoUser.Setup(x => x.Delete(It.IsAny<ApplicationUser>()));
            var service = new ProfilesService(mockRepoPet.Object, mockRepoUser.Object, mockRepoImage.Object);

            var imageList = new List<string>()
            {
                "vasko.com",
            };


            var pet = new Pet
            {
                BreedId = 1,
                CityId = 1,
                Id = 1,
                Name = "GoshoCat",
                DateOfBirth = new DateTime(2008, 3, 1, 7, 0, 0),
                SpecieId = 1,
                AddedByUserId = "PeshoId",
                Description = "test",
                Images = listImage,
            };
            listPet.Add(pet);
            var viewModel = new EditProfileInputModel
            {
                Description = "newTest",
                Id = 1,
                Name = "newGoshoCat",
            };

            service.UpdateAsync(1, viewModel, "PeshoId", imageList);
            Assert.Equal("newGoshoCat", pet.Name);
            Assert.Equal("newTest", pet.Description);
        }
    }
}
