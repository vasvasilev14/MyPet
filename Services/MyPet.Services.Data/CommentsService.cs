namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MyPet.Data.Common.Repositories;
    using MyPet.Data.Models;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task AddCommentAsync(string description, int petId, string userId)
        {
            var comment = new Comment
            {
                Description = description,
                AddedByUserId = userId,
                PetId = petId,
            };

            await this.commentsRepository.AddAsync(comment);
            var petIdTest = comment.Id;
            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteCommentAsync(int id, string userId)
        {
            var comment = this.commentsRepository.All().FirstOrDefault(x => x.Id == id);

            if (userId != comment.AddedByUserId)
            {
                return false;
            }

            this.commentsRepository.Delete(comment);
            await this.commentsRepository.SaveChangesAsync();
            return true;
        }
    }
}
