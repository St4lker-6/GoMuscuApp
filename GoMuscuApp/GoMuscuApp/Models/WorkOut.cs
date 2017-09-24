using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMuscuApp.Models
{
    [Table("WorkOut")]
    public class WorkOut
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ManyToMany(typeof(Session))]
        public List<Session> Sessions { get; set; }

        public DateTime Date { get; set; }
    }
}
