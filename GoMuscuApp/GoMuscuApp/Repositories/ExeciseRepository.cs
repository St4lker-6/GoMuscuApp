using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;

namespace GoMuscuApp.Repositories
{
    public class ExeciseRepository
    {
        private readonly SQLiteConnection _conn;

        public ExeciseRepository(SQLiteConnection conn)
        {
            _conn = conn;
        }
    }
}
