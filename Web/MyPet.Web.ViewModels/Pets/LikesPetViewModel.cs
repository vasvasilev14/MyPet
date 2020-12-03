using System;
using System.Collections.Generic;
using System.Text;

namespace MyPet.Web.ViewModels.Pets
{
    public class LikesPetViewModel
    {
        public string Email { get; set; }

        public string UserId { get; set; }

        public int PetId { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
