using GoMuscuApp.Models;
using SQLite;
using SQLite.Net;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMuscuApp.Repositories
{
    public class MuscleGroupRepository
    {
        private readonly SQLiteConnection _conn;

        public MuscleGroupRepository(SQLiteConnection conn)
        {
            _conn = conn;
        }

        public void CreateTableMuscleGroup()
        {
            _conn.CreateTable<MuscleGroup>();
        }

        public void AddNewMuscleGroup(string name)
        {
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                //insert a new person into the Person table
                var result = _conn.Insert(new MuscleGroup { Name = name });
                    //. Configure(continueOnCapturedContext: false);
                //StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
            catch (Exception)
            {
               // StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }
    }
}
