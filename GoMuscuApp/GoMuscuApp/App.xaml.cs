using GoMuscuApp.Helpers;
using GoMuscuApp.Interfaces;
using GoMuscuApp.Repositories;
using GoMuscuApp.Seed;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GoMuscuApp
{
    public partial class App : Application
    {
        public static MuscleGroupRepository MuscleGrpRepo { get; private set; }

        public static ISQLitePlatform CurrentPlatform { get; private set; }

        public App(ISQLitePlatform platform)
        {
            InitializeComponent();

            CurrentPlatform = platform;

            DatabaseSeed.CheckDatabaseState();

            MainPage = new NavigationPage(new MainPage());
            //MainPage = new GoMuscuApp.Views.SessionDetailsPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
