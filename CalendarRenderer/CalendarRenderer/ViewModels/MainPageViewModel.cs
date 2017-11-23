using CalendarRenderer.Models;
using CalendarRenderer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalendarRenderer.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Properties

        public string LabelUp
        {

            get
            {
                return this.GetLabelUp();
            }
        }

        public string LabelDown
        {
            get
            {
                return this.GetLabelDown();
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

        private CalendarGridViewModel _calendarGridViewContextModel;
        public CalendarGridViewModel CalendarGridViewModel
        {

            get
            {
                return _calendarGridViewContextModel;
            }
            set
            {
                _calendarGridViewContextModel = value;
                this.NotifyPropertyChanged(nameof(CalendarGridViewModel));
            }
        }

        #region Commands
        public ICommand PreviousButtonCommand { get; protected set; }
        public ICommand CurrentButtonCommand { get; protected set; }
        public ICommand NextButtonCommand { get; protected set; }
        #endregion

        #endregion

        public MainPageViewModel()
        {
            this.PreviousButtonCommand = new Command(this.PreviousButtonClicked);
            this.CurrentButtonCommand = new Command(this.CurrentDateButtonClicked);
            this.NextButtonCommand = new Command(this.NextButtonClicked);

            this.CalendarDateTime = DateTime.Now;
            this.ActualizeDisplayedDate();

            this.CalendarGridViewModel = new CalendarGridViewModel();
            this.CalendarGridViewModel.LoadGridModeMonth(this.CalendarDateTime);


        }

        #region Methods

        /// <summary>
        /// Refresh displayed date
        /// </summary>
        private void ActualizeDisplayedDate()
        {
            this.NotifyPropertyChanged(nameof(this.LabelUp));
            this.NotifyPropertyChanged(nameof(this.LabelDown));
        }

        private string GetLabelUp()
        {
            /// At the beginning of the app, the context may be null
            if (this.CalendarGridViewModel == null)
                return string.Empty;

            switch (this.CalendarGridViewModel.DisplayMode)
            {
                case DisplayMode.MonthMode:
                    return this.CalendarDateTime.ToString(DateTimeHelper.yearFormat);

                case DisplayMode.YearMode:
                    return this.CalendarDateTime.ToString(DateTimeHelper.yearFormat);

                default:
                    throw new NotSupportedException();

            }
        }

        private string GetLabelDown()
        {
            /// At the beginning of the app, the context may be null
            if (this.CalendarGridViewModel == null)
                return string.Empty;

            switch (this.CalendarGridViewModel.DisplayMode)
            {
                case DisplayMode.MonthMode:
                    return this.CalendarDateTime.ToString(DateTimeHelper.monthFormat);

                case DisplayMode.YearMode:
                    return string.Empty;


                default:
                    throw new NotSupportedException();

            }
        }


        private void PreviousButtonClicked()
        {
            switch (this.CalendarGridViewModel.DisplayMode)
            {
                case DisplayMode.MonthMode:
                    /// Decrement month
                    this.CalendarDateTime = this.CalendarDateTime.AddMonths(-1);

                    /// Calculate and display the new grid
                    this.CalendarGridViewModel.LoadGridModeMonth(this.CalendarDateTime);

                    break;
                case DisplayMode.YearMode:
                    /// Decrement year
                    this.CalendarDateTime = this.CalendarDateTime.AddYears(-1);

                    /// Calculate and display the new grid
                    this.CalendarGridViewModel.LoadGridModeYear(this.CalendarDateTime);
                    break;
                default:
                    break;
            }

            /// Refresh displayed date
            this.ActualizeDisplayedDate();

        }

        private void CurrentDateButtonClicked()
        {
            this.CalendarGridViewModel.LoadPreviousGridMode();

            switch (this.CalendarGridViewModel.DisplayMode)
            {
                case DisplayMode.MonthMode:

                    break;
                case DisplayMode.YearMode:

                    /// Calculate and display the new grid
                    this.CalendarGridViewModel.LoadGridModeYear(this.CalendarDateTime);

                    break;
                default:
                    break;
            }

            this.ActualizeDisplayedDate();
        }

        private void NextButtonClicked()
        {
            switch (this.CalendarGridViewModel.DisplayMode)
            {
                case DisplayMode.MonthMode:
                    /// Increment month
                    this.CalendarDateTime = this.CalendarDateTime.AddMonths(1);

                    /// Calculate and display the new grid
                    this.CalendarGridViewModel.LoadGridModeMonth(this.CalendarDateTime);

                    break;
                case DisplayMode.YearMode:
                    /// Increment year
                    this.CalendarDateTime = this.CalendarDateTime.AddYears(1);

                    /// Calculate and display the new grid
                    this.CalendarGridViewModel.LoadGridModeYear(this.CalendarDateTime);

                    break;
                default:
                    break;
            }

            /// Refresh displayed date
            this.ActualizeDisplayedDate();

        }

        #endregion
    }
}
