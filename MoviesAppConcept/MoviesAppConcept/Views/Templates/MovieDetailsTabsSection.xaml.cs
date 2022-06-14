using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesAppConcept.Views
{
    public partial class MovieDetailsTabsSection : ContentView
    {
        List<VisualElement> _tabSections = new List<VisualElement>();
        public MovieDetailsTabsSection()
        {
            InitializeComponent();

            _tabSections.Add(InfoSection);
            _tabSections.Add(CastSection);
            _tabSections.Add(NewsSection);
            _tabSections.Add(CriticsSection);
            _tabSections.Add(MediaSection);
        }

        private async void Tab_Tapped(object sender, System.EventArgs e)
        {
            var selectedTab = sender as Label;
            var grid = selectedTab.Parent as Grid;

            foreach (Label tab in (selectedTab.Parent as Grid).Children)
            {
                tab.FontAttributes = (tab == selectedTab ? FontAttributes.Bold : FontAttributes.None);
            }

            _ = await TabIndicator.TranslateTo(
                    selectedTab.Bounds.Center.X - TabIndicator.Bounds.Center.X, TabIndicator.Y,
                    200,
                    Easing.SinInOut);

            _tabSections.ForEach(x => x.IsVisible = false);

            var selectedIndex = grid.Children.IndexOf(selectedTab);

            _tabSections[selectedIndex].IsVisible = true;
        }     
    }
}