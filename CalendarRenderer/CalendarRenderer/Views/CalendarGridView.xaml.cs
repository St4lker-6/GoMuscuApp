using CalendarRenderer.Models;
using CalendarRenderer.Models.Enums;
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

        private Month _currentMonth;
        public Month CurrentMonth
        {

            get
            {
                return _currentMonth;
            }
            set
            {
                _currentMonth = value;
                this.NotifyPropertyChanged(nameof(CurrentMonth));
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
        private DisplayMode _displayMode;
        public DisplayMode DisplayMode
        {

            get
            {
                return _displayMode;
            }
            set
            {
                _displayMode = value;
                this.NotifyPropertyChanged(nameof(DisplayMode));
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
            this.DisplayMode = (DisplayMode)1;
        }

        public void UpdateDate(DateTime newDate)
        {
            this.CurrentMonth = DateTimeHelper.GetDateInformations(newDate);
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