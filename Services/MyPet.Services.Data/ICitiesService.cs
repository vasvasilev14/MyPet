namespace MyPet.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICitiesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
