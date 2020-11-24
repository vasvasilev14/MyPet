namespace MyPet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyPet.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int PetId { get; set; }

        public virtual Pet Pets { get; set; }

        public string Extension { get; set; }
        public string RemoteImageUrl { get; set; }

        //// The contents of the image is in the file system

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
