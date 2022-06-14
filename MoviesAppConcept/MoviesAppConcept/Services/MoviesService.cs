using Newtonsoft.Json;
using MoviesAppConcept.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAppConcept.Services
{
    public class MoviesService
    {
        private const string BASE_IMG_URL = "http://image.tmdb.org/t/p";
        public async static Task<IList<Movie>> GetMovies(string category )
        {
            await Task.Delay(1000);    //simulate api call

            string resource;

            switch (category.ToUpper())
            {
                case "UPCOMING":
                    resource = "Data.movies_upcoming.json";
                    break;
                case "POPULAR":
                    resource = "Data.movies_popular.json";
                    break;
                default:
                    resource = "Data.movies_now_playing.json";
                    break;
            }

            string json = await Helpers.ResourceHelper.GetStringFromEmbeddedResource(resource);
                        
            var resp = JsonConvert.DeserializeObject<Paged<Movie>>(json);

            foreach (var movie in resp.Results)
            {
                movie.PosterPath = $"{BASE_IMG_URL}/w342/{movie.PosterPath}";
                movie.BackdropPath = $"{BASE_IMG_URL}/w780/{movie.BackdropPath}";               
                movie.Title = movie.Title.Trim();
            }

            resp.Results = resp.Results.OrderByDescending(x => x.Popularity).ToList();

            return await Task.FromResult(resp.Results);
        }

        public async static Task<MovieCredits> GetMovieCredits(int movieId)
        {
            await Task.Delay(1000);    //simulate api call

            string json = await Helpers.ResourceHelper.GetStringFromEmbeddedResource($"Data.movie_credits_{movieId}.json");

            var resp = JsonConvert.DeserializeObject<MovieCredits>(json);

            foreach (var cast in resp.Cast)
            {
                cast.ProfilePath = $"{BASE_IMG_URL}/w185/{cast.ProfilePath}";
            }

            return await Task.FromResult(resp);
        }
    }
}
