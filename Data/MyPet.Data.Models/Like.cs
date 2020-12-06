namespace MyPet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using MyPet.Data.Common.Models;

    public class Like : BaseModel<int>
    {
        [Required]
        public int PetId { get; set; }

        public virtual Pet Pet { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public int Counter { get; set; }
    }
}
