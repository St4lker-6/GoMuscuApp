using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarRenderer.Models
{
    public class Day
    {
        public int NumberDay { get; set; }
        public string NameDay { get; set; }

        /// <summary>
        /// Invalid if the day is a day of an another month
        /// </summary>
        public bool Valid { get; set; }
    }
}
