﻿namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MyPet.Web.ViewModels.Pets;

    public interface IPetsService
    {
        Task AddAsync(AddPetInputModel inputModel);
    }
}