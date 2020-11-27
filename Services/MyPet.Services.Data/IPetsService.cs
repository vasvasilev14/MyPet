namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MyPet.Web.ViewModels.Pets;

    public interface IPetsService
    {
        Task AddAsync(AddPetInputModel inputModel, int specieId, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        IEnumerable<T> GetMine<T>(int page, string addedByUserId, int itemsPerPage = 12);

        int GetCount();
    }
}
