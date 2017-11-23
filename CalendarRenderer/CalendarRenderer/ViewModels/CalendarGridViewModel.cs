using CalendarRenderer.Models;
using CalendarRenderer.Models.Enums;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarRenderer.ViewModels
{
    public class CalendarGridViewModel : ViewModelBase
    {
        #region Fields
        private IEventAggregator _eventAgregator;
        #endregion

        #region Properties
        private ObservableCollection<Year> _years;
        public ObservableCollection<Year> Years
        {
            get
            {
                return _years;
            }
            set
            {
                _years = value;
                this.NotifyPropertyChanged(nameof(Years));
            }
        }

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

        private DisplayMode _displayMode;
        public DisplayMode DisplayMode
        {

            get
            {
                return _displayMode;
            }
            private set
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


        #endregion


        public CalendarGridViewModel()
        {
            /// Set the month mode by default
            this.DisplayMode = DisplayMode.MonthMode;

            
        }

        #region Methods
        public void LoadGridModeMonth(DateTime newDate)
        {
            this.CurrentMonth = DateTimeHelper.GetDateInformationsMonthMode(newDate);
        }

        public void LoadGridModeYear(DateTime newDate)
        {
            this.Years = DateTimeHelper.GetDateInformationsYearMode(newDate);
        }

        internal void LoadPreviousGridMode()
        {
            switch (this.DisplayMode)
            {
                case DisplayMode.MonthMode:
                    this.DisplayMode = DisplayMode.YearMode;
                    break;

                case DisplayMode.YearMode:
                    /// Nothing to do, last mode 
                    break;

                default:
                    throw new NotSupportedException();

            }
        }
        #endregion
    }
}
