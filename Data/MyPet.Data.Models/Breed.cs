namespace MyPet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using MyPet.Data.Common.Models;

    public class Breed : BaseDeletableModel<int>
    {
        public Breed()
        {
            this.Pets = new HashSet<Pet>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public int SpecieId { get; set; }

        public virtual Specie Specie { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
