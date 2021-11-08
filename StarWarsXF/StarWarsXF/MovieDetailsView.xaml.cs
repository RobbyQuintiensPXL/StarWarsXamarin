﻿using StarWarsUniverse.Domain;
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
    public partial class MovieDetailsView : ContentPage
    {

        private Movie _selectedMovie;

        public Button MyPlanetsButton { get; private set; }
        public MovieDetailsView()
        {
            InitializeComponent();
            MyPlanetsButton = PlanetsButton;

            CheckEnabledUpButton();
            CheckEnabledDownButton();
        }

        private void CheckEnabledDownButton()
        {
            DownButton.IsEnabled = _selectedMovie?.Rating > 0;
        }

        private void CheckEnabledUpButton()
        {
            UpButton.IsEnabled = _selectedMovie?.Rating < 10;
        }

        public void FillMovieDetails(Movie movie)
        {
            _selectedMovie = movie;

            CheckEnabledUpButton();
            CheckEnabledDownButton();

            var imageFileName = System.Convert.ToString(_selectedMovie.Title).ToLower();
            imageFileName = imageFileName.Replace(' ', '_') + ".jpg";
            PosterImage.Source = imageFileName;

            ReleaseDateLabel.Text = $"{_selectedMovie.ReleaseDate:dd/MM/yyyy}";
            DirectorLabel.Text = _selectedMovie.Director;
            ProducerLabel.Text = _selectedMovie.Producer;
            RatingProgress.Progress = ConvertRating(_selectedMovie.Rating);
        }

        private double ConvertRating(float value)
        {
            double valueOnScaleOfTen = (double)value;
            return valueOnScaleOfTen / 10.0;
        }

        private void UpButton_Clicked(object sender, EventArgs e)
        {
            _selectedMovie.Rating += 0.5f;
            FillMovieDetails(_selectedMovie);
        }

        private void DownButton_Clicked(object sender, EventArgs e)
        {
            _selectedMovie.Rating -= 0.5f;
            FillMovieDetails(_selectedMovie);
        }

        private void PlanetsButton_OnClicked(object sender, EventArgs e)
        {
            //var planetsView = new PlanetsView();
            //planetsView.FillPlanetDetails(_selectedMovie);
            //Navigation.PushAsync(planetsView);
        }
    }
}
