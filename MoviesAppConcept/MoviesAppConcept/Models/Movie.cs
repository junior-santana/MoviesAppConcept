using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoviesAppConcept.Models
{
    //public class Movie
    //{
    //    public long Id { get; set; }
    //    public string Title { get; set; }
    //    public string Year { get; set; }
    //    public string Runtime { get; set; }
    //    public List<string> Genres { get; set; }
    //    public string Director { get; set; }
    //    public string Actors { get; set; }
    //    public string Plot { get; set; }
    //    public string PosterUrl { get; set; }
    //    public int AudienceScore { get; set; }
    //    public int Tomatometer { get; set; }

    //    private static Random _random = new Random();
    //    public Movie()
    //    {
    //        this.AudienceScore = _random.Next(70, 100);
    //        this.Tomatometer = _random.Next(70, 100);
    //    }
    //}

    public class Movie
    {
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("genre_ids")]
        public List<int> GenreIds { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }
    }
}