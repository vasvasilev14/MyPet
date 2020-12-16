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
    using Xunit;

    public class LikesServiceTests
    {
        [Fact]
        public async Task WhenUserLikeTwoTimesSamePetTheTotalLikesShoudBeCorrectAndDelete()
        {
            var list = new List<Like>();
            var mockRepo = new Mock<IRepository<Like>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Like>())).Callback(
                (Like like) => list.Add(like));
            var service = new LikesService(mockRepo.Object);

            await service.SetLikeAsync(2, "Pesho", 1);
            await service.SetLikeAsync(2, "Pesho", 1);
            await service.SetLikeAsync(2, "Gosho", 1);
            await service.DeleteLikeAsync(2, "Gosho", 1);

            mockRepo.Verify(x => x.AddAsync(It.IsAny<Like>()), Times.Exactly(2));

            Assert.Equal(2, list.Count);
            Assert.Equal(2, service.GetTotalLikes(2));
            Assert.False(service.IsUserLikedIt("Pesho", 2));
        }
    }
}
