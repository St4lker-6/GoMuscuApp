using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarRenderer.Models.Events
{
    public class DayClickedEvent : PubSubEvent<bool> { }

    public class DayClickedEventArgs : EventArgs
    {
        public DayClickedEventArgs(string message)
        {

        }

    }
}
