﻿namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ILikesService
    {
        Task SetLikeAsync(int petId, string userId, int counter);

        Task DeleteLikeAsync(int petId, string userId, int counter);

        int GetTotalLikes(int petId);

        bool IsUserLikedIt(string userId, int petId);
    }
}
