namespace MyPet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyPet.Data.Common.Models;

    public class Specie : BaseDeletableModel<int>
    {
        public Specie()
        {
            this.Animals = new HashSet<Animal>();
            this.Breeds = new HashSet<Breed>();
        }

        public string Name { get; set; }

        public virtual ICollection<Breed> Breeds { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
