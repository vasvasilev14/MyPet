namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MyPet.Data.Common.Repositories;
    using MyPet.Data.Models;
    using MyPet.Web.ViewModels.About;

    public class AboutService : IAboutService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Breed> breedsRepository;
        private readonly IDeletableEntityRepository<Image> imagesRepository;
        private readonly IDeletableEntityRepository<Pet> petsRepository;

        public AboutService(
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Breed> breedsRepository,
            IDeletableEntityRepository<Image> imagesRepository,
            IDeletableEntityRepository<Pet> petsRepository)
        {
            this.usersRepository = usersRepository;
            this.breedsRepository = breedsRepository;
            this.imagesRepository = imagesRepository;
            this.petsRepository = petsRepository;
        }

        public SiteAboutViewModel GetAboutInfo()
        {
            var usersCount = this.usersRepository.AllAsNoTracking().Count();
            var breedsCount = this.breedsRepository.AllAsNoTracking().Count();
            var imagesCount = this.imagesRepository.AllAsNoTracking().Count();
            var petsCount = this.petsRepository.AllAsNoTracking().Count();

            return new SiteAboutViewModel
            {
                UsersCount = usersCount,
                BreedsCount = breedsCount,
                ImagesCount = imagesCount,
                PetsCount = petsCount,
            };
        }
    }
}
