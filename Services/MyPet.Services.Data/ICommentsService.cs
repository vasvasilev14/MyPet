namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task AddCommentAsync(string description, int petId, string userId);

        Task<bool> DeleteCommentAsync(int id, string userId);
    }
}
