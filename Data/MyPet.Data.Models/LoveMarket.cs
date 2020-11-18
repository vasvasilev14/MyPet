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
            this.Comments = new HashSet<Comment>();
        }

        public string Description { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
