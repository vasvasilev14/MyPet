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
            this.Comments = new HashSet<Comment>();
        }

        public decimal Price { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
