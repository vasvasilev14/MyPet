namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyPet.Data.Common.Repositories;
    using MyPet.Data.Models;

    public class LikesService : ILikesService
    {
        private readonly IRepository<Like> likesRepository;

        public LikesService(IRepository<Like> likesRepository)
        {
            this.likesRepository = likesRepository;
        }

        public async Task DeleteLikeAsync(int petId, string userId, int counter)
        {
            var like = this.likesRepository.All()
                 .FirstOrDefault(x => x.PetId == petId && x.UserId == userId);
            like.Counter = counter;
            this.likesRepository.Delete(like);
            await this.likesRepository.SaveChangesAsync();
        }

        public int GetTotalLikes(int petId)
        {
            return this.likesRepository.All()
                .Where(x => x.PetId == petId)
                .Sum(x => x.Counter);
        }

        public bool IsUserLikedIt(string userId, int petId)
        {
            var isUserLikedIt = this.likesRepository.AllAsNoTracking().FirstOrDefault(x => x.UserId == userId && x.PetId == petId);
            if (isUserLikedIt != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task SetLikeAsync(int petId, string userId, int counter)
        {
            var like = this.likesRepository.All()
                .FirstOrDefault(x => x.PetId == petId && x.UserId == userId);
            if (like == null)
            {
                like = new Like
                {
                    PetId = petId,
                    UserId = userId,
                };

                await this.likesRepository.AddAsync(like);
            }

            like.Counter = counter;
            await this.likesRepository.SaveChangesAsync();
        }
    }
}
