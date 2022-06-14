using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoviesAppConcept.Models
{
    public class MovieCredits
    {
        [JsonProperty("id")]
        public uint Id { get; set; }
        [JsonProperty("cast")]
        public IList<Cast> Cast { get; set; }
        //[JsonProperty("crew")]
        //public IList<Cast> Crew { get; set; }
    }
}