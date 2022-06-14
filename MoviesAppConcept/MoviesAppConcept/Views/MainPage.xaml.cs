using MoviesAppConcept.ViewModels;
using Xamarin.Forms;

namespace MoviesAppConcept.Views
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel _vm;
        private bool _isFirstLoading = true;
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!_isFirstLoading) return;

            _vm = ((MainViewModel)BindingContext);

            await _vm.Load();

            _isFirstLoading = false;
        }
        private async void LstMovies_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;

            var movie = (Models.Movie)e.Item;

            await Navigation.PushAsync(new MovieDetailsPage(movie));
        }
        private async void BtnCategory_Clicked(object sender, System.EventArgs e)
        {
            string[] options = { "IN THEATERS", "UPCOMING", "POPULAR" };
            string category = await DisplayActionSheet("Categories", "Cancel", null, options);

            if (string.IsNullOrEmpty(category) || category == "Cancel")
                return;

            _vm.RefreshCommand.Execute(null);
            _vm.Category = category;

            await _vm.Load();
        }
    }

}
