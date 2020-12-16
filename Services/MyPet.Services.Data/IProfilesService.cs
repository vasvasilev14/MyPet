namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MyPet.Web.ViewModels.Pets;
    using MyPet.Web.ViewModels.Profiles;

    public interface IProfilesService
    {
       SinglePetViewModel PetProfileInfo(int petId);

       Task<bool> DeleteAsyncPhoto(string imageUrl, string userId);

       Task UpdateAsync(int id, EditProfileInputModel input, string userId, List<string> imagePaths);

       Task UpdateAsync(int id, EditProfileInputModel input, string userId);

       string GetName(int id);
    }
}
