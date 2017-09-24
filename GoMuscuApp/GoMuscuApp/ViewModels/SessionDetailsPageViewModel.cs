using GoMuscuApp.Models.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMuscuApp.ViewModels
{
    public class SessionDetailsPageViewModel : CustomNotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _myVar;

        public int MyProperty
        {
            get
            {
                return _myVar;
            }
            set
            {
                _myVar = value;
                this.OnPropertyChanged("MyProperty");
            }
        }

    }
}
