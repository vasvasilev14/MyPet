namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyPet.Web.ViewModels.About;

    public interface IAboutService
    {
        SiteAboutViewModel GetAboutInfo();
    }
}
