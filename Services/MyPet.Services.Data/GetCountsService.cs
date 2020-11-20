namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MyPet.Data.Common.Repositories;
    using MyPet.Data.Models;
    using MyPet.Web.ViewModels.Home;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Breed> breedsRepository;
        private readonly IDeletableEntityRepository<Image> imagesRepository;

        public GetCountsService(IDeletableEntityRepository<Breed> breedsRepository, IDeletableEntityRepository<Image> imagesRepository)
        {
            this.breedsRepository = breedsRepository;
            this.imagesRepository = imagesRepository;
        }

        public IndexViewModel GetCounts()
        {
            var data = new IndexViewModel
            {
                BreedsCount = this.breedsRepository.All().Count(),
                ImagesCount = this.imagesRepository.All().Count(),
            };
            return data;
        }
    }
}
