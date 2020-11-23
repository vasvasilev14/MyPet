namespace MyPet.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyPet.Data.Models;

    internal class CitySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cities.Any())
            {
                return;
            }

            var cityNames = new List<string>() { "Asenovgrad", "Blagoevgrad", "Burgas", "Dobrich", "Gabrovo", "Haskovo", "Pazardzhik", "Pernik", "Pleven", "Plovdiv", "Ruse", "Shumen", "Sliven", "Sofia", "Stara Zagora", "Varna", "Veliko Tarnovo", "Vidin", "Vratsa", "Yambol" };

            foreach (var cityName in cityNames)
            {
                await dbContext.Cities.AddAsync(new City { Name = cityName });
            }
        }
    }
}
