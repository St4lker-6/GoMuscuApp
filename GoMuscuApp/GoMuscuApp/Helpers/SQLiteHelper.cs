using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using Xamarin.Forms;
using GoMuscuApp.Common;
using GoMuscuApp.Interfaces;

namespace GoMuscuApp.Helpers
{
    public class SQLiteHelper : IDisposable
    {
        public SQLiteConnection Connection { get; private set; }

        public SQLiteHelper(ISQLitePlatform platform)
        {
            var dbFilePath = GetDatabasePath();

            Connection = new SQLiteConnection(platform, dbFilePath);
        }

        public static string GetDatabasePath()
        {
            return DependencyService.Get<IFileAccessHelper>().GetLocalFilePath(SQLiteConstants.DatabaseFileName);
        }

        public void Dispose()
        {
            if (Connection != null)
                Connection.Dispose();
        }
    }
}
