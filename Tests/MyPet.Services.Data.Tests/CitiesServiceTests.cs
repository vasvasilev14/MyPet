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
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<City>()));
            var service = new CitiesService(mockRepo.Object);
            service.GetAllAsKeyValuePairs();
        }
    }
}
