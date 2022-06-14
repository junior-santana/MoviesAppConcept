using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoviesAppConcept.Models
{
    //internal class MovieData
    //{
    //    public Category Pick { get; set; }
    //    public Category Recommended { get; set; }
    //    public Category Recently { get; set; }
    //}
    //internal class Category
    //{
    //    public string Title { get; set; }
    //    public List<Movie> Items { get; set; }
    //}
    public class Paged<T>
    {
        [JsonProperty("results")]
        public List<T> Results;
        [JsonProperty("page")]
        public uint Page;
        [JsonProperty("total_pages")]
        public uint TotalPages;
        [JsonProperty("total_results")]
        public uint TotalResults;
    }
}
