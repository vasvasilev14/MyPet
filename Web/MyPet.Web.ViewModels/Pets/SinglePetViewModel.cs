namespace MyPet.Web.ViewModels.Pets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using MyPet.Data.Models;
    using MyPet.Services.Mapping;

    public class SinglePetViewModel : IMapFrom<Pet>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string AddedByUserId { get; set; }

        public int SpecieId { get; set; }

        public int BreedId { get; set; }

        public int CityId { get; set; }

        public string ImageUrl { get; set; }

        public int? ContactId { get; set; }

        public virtual Contact Contact { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Pet, SinglePetViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "/images/recipes/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
