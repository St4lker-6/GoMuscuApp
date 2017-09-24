﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GoMuscuApp.Droid.Helpers;

namespace GoMuscuApp.Droid
{
    [Activity(Label = "GoMuscuApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //string dbPath = FileAccessHelper.GetLocalFilePath("MaBase.db3");

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            LoadApplication(new App(platform));
        }
    }
}

