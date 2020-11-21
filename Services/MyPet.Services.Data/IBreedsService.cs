using System;
using System.Collections.Generic;
using System.Text;

namespace MyPet.Services.Data
{
   public interface IBreedsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
