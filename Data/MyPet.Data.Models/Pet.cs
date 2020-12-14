namespace MyPet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using MyPet.Data.Common.Models;

    public class Pet : BaseDeletableModel<int>
    {
        public Pet()
        {
            this.Images = new HashSet<Image>();
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public string Description { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        [Required]
        public int SpecieId { get; set; }

        public virtual Specie Specie { get; set; }

        [Required]
        public int BreedId { get; set; }

        public virtual Breed Breed { get; set; }

        public int? LoveMarketId { get; set; }

        public virtual LoveMarket LoveMarket { get; set; }

        public int? SellMarketId { get; set; }

        public virtual SellMarket SellMarket { get; set; }

        [Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
