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
    [Table("Exercise")]
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(MuscleGroup))]
        public int IdMuscleGroup { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        [ManyToOne]
        public MuscleGroup MuscleGrp { get; set; }

        [OneToMany]
        public List<Session> Sessions { get; set; }
    }
}
