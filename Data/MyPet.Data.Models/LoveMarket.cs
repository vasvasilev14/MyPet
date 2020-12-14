namespace MyPet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyPet.Data.Common.Models;

    public class LoveMarket : BaseDeletableModel<int>
    {
        public LoveMarket()
        {
            this.Pets = new HashSet<Pet>();
        }

        public string Description { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }

    }
}
