using MvvmHelpers;
using MvvmHelpers.Commands;
using MoviesAppConcept.Models;
using MoviesAppConcept.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoviesAppConcept.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private IList<Movie> _movies;
        public IList<Movie> Movies
        {
            get { return _movies; }
            set { SetProperty(ref _movies, value); }
        }

        private string _category = "IN THEATERS";
        public string Category
        {
            get { return _category; }
            set { SetProperty(ref _category, value); }
        }

        private bool _noMoviesFound;
        public bool NoMoviesFound
        {
            get { return _noMoviesFound; }
            set { SetProperty(ref _noMoviesFound, value); }
        }

        public ICommand RefreshCommand { get; set; }

        public MainViewModel()
        {
            RefreshCommand = new AsyncCommand(Load, _ => !IsBusy);
        }
        public async Task Load()
        {
            try
            {
                IsBusy = true;
                
                Movies = await MoviesService.GetMovies(Category);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
                NoMoviesFound = Movies.Count == 0;
            }
        }
    }
}
