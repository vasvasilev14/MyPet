namespace MyPet.Web.ViewModels.Pets
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PetCommentViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string AddedByUserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Email { get; set; }
    }
}
