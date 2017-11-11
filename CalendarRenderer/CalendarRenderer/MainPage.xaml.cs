﻿using CalendarRenderer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalendarRenderer
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private const string monthFormat = "MMMM";
        private const string yearFormat = "yyyy";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Year
        {

            get
            {
                return this.CalendarDateTime.ToString(yearFormat);
            }
        }

        public string Month
        {
            get
            {
                return this.CalendarDateTime.ToString(monthFormat);
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

        private CalendarGridView _calendarGridViewContext;
        public CalendarGridView CalendarGridViewContext
        {

            get
            {
                return _calendarGridViewContext;
            }
            set
            {
                _calendarGridViewContext = value;
                this.NotifyPropertyChanged(nameof(CalendarGridViewContext));
            }
        }

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;

            this.CalendarDateTime = DateTime.Now;
            this.ActualizeDisplayedDate();

            this.CalendarGridViewContext = new CalendarGridView();
            this.CalendarGridViewContext.UpdateDate(this.CalendarDateTime);
        }


        private void PreviousButtonClicked(object sender, EventArgs e)
        {
            /// decrement and Refresh displayed date
            this.CalendarDateTime = this.CalendarDateTime.AddMonths(-1);
            this.ActualizeDisplayedDate();

            /// Calculate and display the new grid
            this.CalendarGridViewContext.UpdateDate(this.CalendarDateTime);
        }

        private void CurrentDateButtonClicked(object sender, EventArgs e)
        {

        }

        private void NextButtonClicked(object sender, EventArgs e)
        {
            /// Increment and Refresh displayed date
            this.CalendarDateTime = this.CalendarDateTime.AddMonths(1);
            this.ActualizeDisplayedDate();

            /// Calculate and display the new grid
            this.CalendarGridViewContext.UpdateDate(this.CalendarDateTime);
        }

        private void ActualizeDisplayedDate()
        {
            this.NotifyPropertyChanged(nameof(Year));
            this.NotifyPropertyChanged(nameof(Month));
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
