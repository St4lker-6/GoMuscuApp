using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;
using GoMuscuApp.Interfaces;
using System.Globalization;
using GoMuscuApp.Droid.Helpers;
using GoMuscuApp.Common.Enum;

[assembly: Xamarin.Forms.Dependency(typeof(LocaleHelper_Android))]
namespace GoMuscuApp.Droid.Helpers
{
    public class LocaleHelper_Android : ILocaleHelper
    {
        public void SetLocale(string language)
        {
            Console.WriteLine("--- Set --- ");
            Java.Util.Locale.Default = new Java.Util.Locale(language);
            var netLocale = Java.Util.Locale.Default.ToString().Replace("_", "-");
            var cultureInfo = new CultureInfo(netLocale);

            Console.WriteLine("android:  " + Java.Util.Locale.Default.ToString());
            Console.WriteLine("netlocale:" + netLocale);

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            Console.WriteLine("thread:  " + Thread.CurrentThread.CurrentCulture);
            Console.WriteLine("threadui:" + Thread.CurrentThread.CurrentUICulture);
            Console.WriteLine("---------");
        }

        public CultureInfo GetCurrent()
        {
            var androidLocale = Java.Util.Locale.Default;
            // en, es, ja
            var netLanguage = androidLocale.Language.Replace("_", "-");
            // en-US, es-ES, ja-JP
            var netLocale = androidLocale.ToString().Replace("_", "-");

            #region Debugging output
            Console.WriteLine("--- Get --- ");
            Console.WriteLine("android:  " + androidLocale.ToString());
            Console.WriteLine("netlang:  " + netLanguage);
            Console.WriteLine("netlocale:" + netLocale);

            var ci = new System.Globalization.CultureInfo(netLocale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            Console.WriteLine("thread:  " + Thread.CurrentThread.CurrentCulture);
            Console.WriteLine("threadui:" + Thread.CurrentThread.CurrentUICulture);
            Console.WriteLine("---------");
            #endregion

            return ci;
        }
    }
}