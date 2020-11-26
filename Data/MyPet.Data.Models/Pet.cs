namespace MyPet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyPet.Data.Common.Models;

    public class Pet : BaseDeletableModel<int>
    {
        public Pet()
        {
            this.Images = new HashSet<Image>();
            this.Likes = new HashSet<Like>();
        }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public int SpecieId { get; set; }

        public virtual Specie Specie { get; set; }

        public int BreedId { get; set; }

        public virtual Breed Breed { get; set; }

        public int? LoveMarketId { get; set; }

        public virtual LoveMarket LoveMarket { get; set; }

        public int? SellMarketId { get; set; }

        public virtual SellMarket SellMarket { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public int? ContactId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
