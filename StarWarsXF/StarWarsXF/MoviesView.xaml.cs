using StarWarsUniverse.Data;
using StarWarsUniverse.Data.Repositories;
using StarWarsUniverse.Data.Repositories.Db;
using StarWarsUniverse.Domain;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StarWarsXF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesView : ContentPage
    {

        public CollectionView MyCollectionView { get; private set; }

        public MoviesView()
        {
            InitializeComponent();

            IMovieRepository repository = new MovieDbRepository(StarWarsContextFactory.Create());
            IList<Movie> movieList = repository.GetAllMovies();
            SWMoviesCollectionView.ItemsSource = movieList;

            MyCollectionView = SWMoviesCollectionView;
        }
    }
}