using GoMuscuApp.Common.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMuscuApp.Interfaces
{
    public interface ILocaleHelper
    {
        void SetLocale(string language);

        CultureInfo GetCurrent();
    }
}
