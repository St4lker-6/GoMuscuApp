using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;

namespace GoMuscuApp.Repositories
{
    public class WorkOutRepository
    {
        private readonly SQLiteConnection _conn;

        public WorkOutRepository(SQLiteConnection conn)
        {
            _conn = conn;
        }
    }
}
