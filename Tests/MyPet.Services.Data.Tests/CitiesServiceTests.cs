namespace MyPet.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Moq;
    using MyPet.Data.Common.Repositories;
    using MyPet.Data.Models;
    using Xunit;

    public class CitiesServiceTests
    {
        [Fact]
        public void AddingCities()
        {
            var list = new List<City>();
            var mockRepo = new Mock<IDeletableEntityRepository<City>>();
            mockRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<City>()));
            var service = new CitiesService(mockRepo.Object);
            var city = new City
            {
                Id = 1,
                Name = "Sofia",
            };
            list.Add(city);
            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("1", "Sofia"),
            };
            Assert.Equal(expected, service.GetAllAsKeyValuePairs());
        }
    }
}
