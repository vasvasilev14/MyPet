namespace MyPet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using MyPet.Data.Common.Models;

    public class Specie : BaseDeletableModel<int>
    {
        public Specie()
        {
            this.Pets = new HashSet<Pet>();
            this.Breeds = new HashSet<Breed>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Breed> Breeds { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
