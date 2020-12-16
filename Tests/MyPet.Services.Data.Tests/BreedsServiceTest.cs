namespace MyPet.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Moq;
    using MyPet.Data;
    using MyPet.Data.Common.Repositories;
    using MyPet.Data.Models;
    using MyPet.Data.Repositories;
    using Xunit;

    public class BreedsServiceTest
    {
        [Fact]
        public void AddingBreeds()
        {
            var list = new List<Breed>();
            var mockRepo = new Mock<IDeletableEntityRepository<Breed>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Breed>()));
            var service = new BreedsService(mockRepo.Object);
            service.GetAllAsKeyValuePairs(1);
        }
    }
}
