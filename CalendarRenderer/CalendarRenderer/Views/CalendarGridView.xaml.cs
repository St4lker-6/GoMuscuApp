using CalendarRenderer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
                this.NotifyPropertyChanged(nameof(Weeks));
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
                this.NotifyPropertyChanged(nameof(CalendarDateTime));
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
                this.NotifyPropertyChanged(nameof(montext));
            }
        }

        public CalendarGridView()
        {
            InitializeComponent();
            this.Weeks = new ObservableCollection<Week>();
        }

        public void UpdateDate(DateTime newDate)
        {
            this.Weeks = DateTimeHelper.GetDateInformations(newDate);
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