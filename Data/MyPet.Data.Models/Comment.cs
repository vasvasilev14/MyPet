namespace MyPet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using MyPet.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public int PetId { get; set; }

        public virtual Pet Pet { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
