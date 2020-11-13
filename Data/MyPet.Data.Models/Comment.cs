namespace MyPet.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyPet.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string Description { get; set; }

        public int LoveMarketId { get; set; }

        public virtual LoveMarket LoveMarket { get; set; }

        public int SellMarketId { get; set; }

        public virtual SellMarket SellMarket { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
