namespace MyPet.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyPet.Data.Models;

    internal class SpecieSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Species.Any())
            {
                return;
            }

            var speciesNames = new List<string>() { "Cat", "Dog" };

            foreach (var specieName in speciesNames)
            {
                await dbContext.Species.AddAsync(new Specie { Name = specieName });
            }
        }
    }
}
