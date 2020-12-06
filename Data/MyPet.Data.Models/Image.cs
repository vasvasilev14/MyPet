namespace MyPet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using MyPet.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public int PetId { get; set; }

        public virtual Pet Pets { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
