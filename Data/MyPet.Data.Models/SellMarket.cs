namespace MyPet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyPet.Data.Common.Models;

    public class SellMarket : BaseDeletableModel<int>
    {
        public SellMarket()
        {
            this.Pets = new HashSet<Pet>();
        }

        public decimal Price { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }

    }
}
