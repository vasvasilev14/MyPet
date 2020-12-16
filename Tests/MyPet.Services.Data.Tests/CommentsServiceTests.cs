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

   public class CommentsServiceTests
    {
        [Fact]
        public async Task AddingComments()
        {
            var list = new List<Comment>();
            var mockRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Comment>()))
                .Callback(
                (Comment comment) => list.Add(comment));
            var service = new CommentsService(mockRepo.Object);
            await service.AddCommentAsync("test", 1, "Pesho");

            Assert.Equal(1, list.Count);
        }

        [Fact]
        public async Task DeleteComments()
        {
            var list = new List<Comment>();
            var mockRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Comment>()))
                .Callback(
                (Comment comment) => list.Add(comment));
            mockRepo.Setup(x => x.Delete(It.IsAny<Comment>()))
                .Callback((Comment comment) => list.Remove(comment));
            var service = new CommentsService(mockRepo.Object);

            var comment = service.AddCommentAsync("test", 1, "PeshoId");
            await service.DeleteCommentAsync(0, "PeshoId");

            Assert.Equal(0, list.Count);
        }

        [Fact]
        public async Task DeleteCommentsWithOtherUserIdMustReturnFalse()
        {
            var list = new List<Comment>();
            var mockRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Comment>()))
                .Callback(
                (Comment comment) => list.Add(comment));
            mockRepo.Setup(x => x.Delete(It.IsAny<Comment>()))
                .Callback((Comment comment) => list.Remove(comment));
            var service = new CommentsService(mockRepo.Object);

            var comment = service.AddCommentAsync("test", 1, "PeshoId");

            Assert.False(await service.DeleteCommentAsync(0, "GoshoId"));
        }
    }
}
