using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using MoviesAppConcept.Models;
using MoviesAppConcept.Services;

namespace MoviesAppConcept.ViewModels
{
    internal class MovieDetailsViewModel : BaseViewModel
    {
        private Movie _movie;
        public Movie Movie
        {
            get { return _movie; }
            set { SetProperty(ref _movie, value); }
        }

        private IList<Cast> _cast;
        public IList<Cast> Cast
        {
            get { return _cast; }
            set {
                if (SetProperty(ref _cast, value))
                {
                    
                }
            }
        }

        public async Task Load(Movie movie)
        {
            try
            {
                IsBusy = true;

                Movie = movie;

                MovieCredits data = await MoviesService.GetMovieCredits(movie.Id);

                Cast = data.Cast;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
