using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using System.IO;
using GoMuscuApp;
using GoMuscuApp.iOS.Helpers;
using GoMuscuApp.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(FileAccessHelper_iOS))]
namespace GoMuscuApp.iOS.Helpers
{
    public class FileAccessHelper_iOS : IFileAccessHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
                Directory.CreateDirectory(libFolder);

            return Path.Combine(libFolder, fileName);
        }

        public bool CheckFileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}