﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalendarRenderer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarYearCellView : ContentView
    {
        public CalendarYearCellView()
        {
            InitializeComponent();
        }
    }
}