using StarWarsUniverse.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StarWarsXF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : FlyoutPage
    {
        public MainView()
        {
            InitializeComponent();
            MyFlyoutPage.MyCollectionView.SelectionChanged += MyCollectionView_SelectionChanged;
        }

        private void MyCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Movie movie = (Movie)e.CurrentSelection.FirstOrDefault();
            if (movie != null)
            {
                var page = new MovieDetailsView { Title = movie.Title };
                page.FillMovieDetails(movie);

                Detail = new NavigationPage(page);

                IsPresented = false;
            }
        }
    }
}