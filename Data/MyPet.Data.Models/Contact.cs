namespace MyPet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyPet.Data.Common.Models;

    public class Contact : BaseDeletableModel<int>
    {
        public Contact()
        {
            this.Animals = new HashSet<Animal>();
        }

        public string Name { get; set; }

        public string TelephoneNumber { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
