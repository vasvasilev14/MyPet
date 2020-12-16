namespace MyPet.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.EntityFrameworkCore;
    using MyPet.Data;
    using MyPet.Data.Models;
    using MyPet.Data.Repositories;
    using MyPet.Web.ViewModels.About;
    using Xunit;

    public class AboutServiceTests
    {
        [Fact]
        public void IsGetAboutInfoRight()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase(Guid.NewGuid().ToString());
            var userRepository = new EfDeletableEntityRepository<ApplicationUser>(new ApplicationDbContext(options.Options));
            var breedsRepository = new EfDeletableEntityRepository<Breed>(new ApplicationDbContext(options.Options));
            var imagesRepository = new EfDeletableEntityRepository<Image>(new ApplicationDbContext(options.Options));
            var petsRepository = new EfDeletableEntityRepository<Pet>(new ApplicationDbContext(options.Options));

            var aboutService = new AboutService(userRepository, breedsRepository, imagesRepository, petsRepository);

            var userCount = userRepository.AllAsNoTracking().Count();
            var breedsCount = breedsRepository.AllAsNoTracking().Count();
            var imagesCount = imagesRepository.AllAsNoTracking().Count();
            var petsCount = petsRepository.AllAsNoTracking().Count();

            var expexted = new SiteAboutViewModel
            {
                UsersCount = userCount,
                BreedsCount = breedsCount,
                ImagesCount = imagesCount,
                PetsCount = petsCount,
            };
            var actual = aboutService.GetAboutInfo();

            Assert.Equal(expexted.UsersCount, actual.UsersCount);
            Assert.Equal(expexted.BreedsCount, actual.BreedsCount);
            Assert.Equal(expexted.ImagesCount, actual.ImagesCount);
            Assert.Equal(expexted.PetsCount, actual.PetsCount);
        }
    }
}
