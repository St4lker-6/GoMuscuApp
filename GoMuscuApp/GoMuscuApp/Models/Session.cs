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

    [Table("Session")]
    public class Session
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Exercise))]
        public int IdExercise { get; set; }

        public int SetNumber{ get; set; }

        public int RepNumber { get; set; }

        [ManyToOne]
        public Exercise Exercise { get; set; }

        [ManyToMany(typeof(WorkOut))]
        public List<WorkOut> WorkOuts { get; set; }
    }
}
