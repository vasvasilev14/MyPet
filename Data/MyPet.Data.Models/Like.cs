﻿namespace MyPet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyPet.Data.Common.Models;

    public class Like : BaseModel<int>
    {
        public int PetId { get; set; }

        public virtual Pet Pet { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int Counter { get; set; }
    }
}