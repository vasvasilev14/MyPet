namespace MyPet.Web.ViewModels.Pets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using MyPet.Data.Models;
    using MyPet.Services.Mapping;

    public class PetsInListViewModel : IMapFrom<Pet>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public Breed Breed { get; set; }

        public int BreedId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age => (DateTime.Today - this.DateOfBirth).Days / 365;

        public Gender Gender { get; set; }

        public City City { get; set; }

        public int CityId { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Pet, PetsInListViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl ?? "/images/pets/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
