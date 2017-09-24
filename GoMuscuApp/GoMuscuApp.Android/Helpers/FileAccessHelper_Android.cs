using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GoMuscuApp.Droid.Helpers;
using GoMuscuApp.Interfaces;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(FileAccessHelper_Android))]
namespace GoMuscuApp.Droid.Helpers
{
    public class FileAccessHelper_Android : IFileAccessHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, fileName);
        }

        public bool CheckFileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}