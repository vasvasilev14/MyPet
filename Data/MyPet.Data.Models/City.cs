namespace MyPet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using MyPet.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {
        public City()
        {
            this.Pets = new HashSet<Pet>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
