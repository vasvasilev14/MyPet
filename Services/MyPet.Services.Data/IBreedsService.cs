﻿namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IBreedsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs(int specieId);
    }
}
