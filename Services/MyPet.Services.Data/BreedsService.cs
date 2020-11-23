namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MyPet.Data.Common.Repositories;
    using MyPet.Data.Models;

    public class BreedsService : IBreedsService
    {
        private readonly IDeletableEntityRepository<Breed> breedsRepository;

        public BreedsService(IDeletableEntityRepository<Breed> breedsRepository)
        {
            this.breedsRepository = breedsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs(int specieId)
        {
            return this.breedsRepository.AllAsNoTracking().Where(x => x.SpecieId == specieId).Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).OrderBy(x => x.Value);
        }
    }
}
