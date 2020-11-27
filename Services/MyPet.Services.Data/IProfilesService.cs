namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyPet.Web.ViewModels.Pets;

    public interface IProfilesService
    {
       SinglePetViewModel PetProfileInfo(int petId);
    }
}
