using GoMuscuApp.Helpers;
using GoMuscuApp.Interfaces;
using GoMuscuApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GoMuscuApp.Seed
{
    public static class DatabaseSeed
    {

        public static void CheckDatabaseState()
        {
            var dbFilePath = SQLiteHelper.GetDatabasePath();

            var fileAccessService = DependencyService.Get<IFileAccessHelper>();

            if (!fileAccessService.CheckFileExists(dbFilePath))
            {
                FillDatabase();
            }
        }

        private static void FillDatabase()
        {
            using (var context = new SQLiteHelper(App.CurrentPlatform))
            {
                var muscleGrpRepo = new MuscleGroupRepository(context.Connection);
                muscleGrpRepo.CreateTableMuscleGroup();
                muscleGrpRepo.AddNewMuscleGroup("Dos");
                muscleGrpRepo.AddNewMuscleGroup("Jambes");


            }
        }
    }
}
