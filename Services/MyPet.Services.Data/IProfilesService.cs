namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MyPet.Web.ViewModels.Pets;

    public interface IProfilesService
    {
       SinglePetViewModel PetProfileInfo(int petId);

       Task<bool> DeleteAsync(string imageUrl, string userId);
    }
}
