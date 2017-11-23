using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarRenderer.Models
{
    public class Month
    {
        public ObservableCollection<Week> Weeks { get; set; }
        public string NameMonth { get; private set; }

        public Month(string nameMonth)
        {
            this.NameMonth = nameMonth;
            Weeks = new ObservableCollection<Week>();
        }
    }
}
