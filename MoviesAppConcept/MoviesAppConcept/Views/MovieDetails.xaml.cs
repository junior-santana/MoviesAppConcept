using MoviesAppConcept.Models;
using MoviesAppConcept.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesAppConcept.Views
{
    public partial class MovieDetailsPage : ContentPage
    {
        private Movie _movie = new Movie();
        private bool _isFirstLoading = true;

        public MovieDetailsPage(Models.Movie movie)
        {
            InitializeComponent();

            _movie = movie;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (!_isFirstLoading) return;

            var vm = ((MovieDetailsViewModel)this.BindingContext);

            await vm.Load(_movie);

            _isFirstLoading = true;
        }

        private void BackButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }      
    }
}