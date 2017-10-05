using CalendarRenderer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarRenderer
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Week> _weeks;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            this.Weeks = new ObservableCollection<Week>();
            var days = new ObservableCollection<Day>();
            days.Add(new Day { numberDay = 1, nameDay = "Lundi" });
            days.Add(new Day { numberDay = 2, nameDay = "Mardi" });
            days.Add(new Day { numberDay = 3 });
            days.Add(new Day { numberDay = 4 });
            days.Add(new Day { numberDay = 5 });
            days.Add(new Day { numberDay = 6 });
            days.Add(new Day { numberDay = 7 });

            var week = new Week();
            week.Days = days;
            this.Weeks.Add(week);

            days = new ObservableCollection<Day>();
            days.Add(new Day { numberDay = 8, nameDay = "Lundi" });
            days.Add(new Day { numberDay = 9, nameDay = "Mardi" });
            days.Add(new Day { numberDay = 10 });
            days.Add(new Day { numberDay = 11 });
            days.Add(new Day { numberDay = 12 });
            days.Add(new Day { numberDay = 13 });
            days.Add(new Day { numberDay = 14 });

            week = new Week();
            week.Days = days;

            this.Weeks.Add(week);
        }

        public ObservableCollection<Week> Weeks
        {

            get
            {
                return _weeks;
            }

            set
            {
                _weeks = value;
                NotifyPropertyChanged("Month");
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
