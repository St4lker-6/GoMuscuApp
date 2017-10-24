using CalendarRenderer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalendarRenderer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarGridView : ContentView, INotifyPropertyChanged
    {
        private const string monthFormat = "MMMM";
        private const string yearFormat = "yyyy";

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Week> _weeks;
        public ObservableCollection<Week> Weeks
        {

            get
            {
                return _weeks;
            }

            set
            {
                _weeks = value;
                this.NotifyPropertyChanged("Weeks");

            }
        }

        private DateTime _calendarDateTime;
        public DateTime CalendarDateTime
        {

            get
            {
                return _calendarDateTime;
            }

            set
            {
                _calendarDateTime = value;
                this.NotifyPropertyChanged("CalendarDateTime");
            }
        }


        private string _montext;
        public string montext
        {

            get
            {
                return _montext;
            }

            set
            {
                _montext = value;
                this.NotifyPropertyChanged("montext");
            }
        }

        public CalendarGridView()
        {
            InitializeComponent();
        }

        public CalendarGridView(DateTime calendarDateTime)
        {
            InitializeComponent();

            this.Weeks = DateTimeHelper.GetDateInformations(calendarDateTime);
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}