using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using System.Threading;
using GoMuscuApp.Interfaces;
using System.Globalization;
using GoMuscuApp.iOS.Helpers;
using GoMuscuApp.Common.Enum;

[assembly: Xamarin.Forms.Dependency(typeof(LocaleHelper_iOS))]
namespace GoMuscuApp.iOS.Helpers
{
    public class LocaleHelper_iOS : ILocaleHelper
    {
        public void SetLocale(string language)
        {
            Console.WriteLine("--- Set --- ");
            var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;
            var netLocale = iosLocaleAuto.Replace("_", "-");
            var cultureInfo = new CultureInfo(netLocale);

            Console.WriteLine("ios:  " + iosLocaleAuto.ToString());
            Console.WriteLine("netlocale:" + netLocale);

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            Console.WriteLine("thread:  " + Thread.CurrentThread.CurrentCulture);
            Console.WriteLine("threadui:" + Thread.CurrentThread.CurrentUICulture);
            Console.WriteLine("---------");
        }

        public CultureInfo GetCurrent()
        {
            var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;
            var iosLanguageAuto = NSLocale.AutoUpdatingCurrentLocale.LanguageCode;
            var netLocale = iosLocaleAuto.Replace("_", "-");
            var netLanguage = iosLanguageAuto.Replace("_", "-");

            #region Debugging Info
            // prefer *Auto updating properties
            //			var iosLocale = NSLocale.CurrentLocale.LocaleIdentifier;
            //			var iosLanguage = NSLocale.CurrentLocale.LanguageCode;
            //			var netLocale = iosLocale.Replace ("_", "-");
            //			var netLanguage = iosLanguage.Replace ("_", "-");
            Console.WriteLine("--- Get --- ");
            Console.WriteLine("nslocaleid:" + iosLocaleAuto);
            Console.WriteLine("nslanguage:" + iosLanguageAuto);
            Console.WriteLine("ios:" + iosLanguageAuto + " " + iosLocaleAuto);
            Console.WriteLine("net:" + netLanguage + " " + netLocale);

            var ci = new System.Globalization.CultureInfo(netLocale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            Console.WriteLine("thread:  " + Thread.CurrentThread.CurrentCulture);
            Console.WriteLine("threadui:" + Thread.CurrentThread.CurrentUICulture);
            #endregion

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = pref.Replace("_", "-");
                Console.WriteLine("preferred:" + netLanguage);
            }
            else
            {
                netLanguage = "en"; // default, shouldn't really happen :)
            }

            Console.WriteLine("---------");

            return ci;
        }
    }
}