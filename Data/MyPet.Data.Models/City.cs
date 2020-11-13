namespace MyPet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyPet.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {
        public City()
        {
            this.Animals = new HashSet<Animal>();
        }

        public string Name { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
