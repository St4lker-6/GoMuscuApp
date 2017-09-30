using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Globalization;
using GoMuscuApp.Common.Enum;
using Xamarin.Forms;
using GoMuscuApp.Interfaces;
using System.Diagnostics;
using System.Reflection;

namespace GoMuscuApp.Managers
{
    public static class LanguageManager
    {
        public static void ListResxFile()
        {
            // TODO: Revoir car les fichier resx.fr.xml ne sont pas affichés
            System.Diagnostics.Debug.WriteLine("====== resource debug info =========");
            var assembly = typeof(App).GetTypeInfo().Assembly;

            foreach (var res in assembly.GetManifestResourceNames())
            {
                System.Diagnostics.Debug.WriteLine("found resource: " + res);
            }
            System.Diagnostics.Debug.WriteLine("====================================");
        }

        public static void SwitchLanguage(CultureLanguageEnum language)
        {
            // Get the string corresponding to the new language
            var languageName = TranslateLanguageEnum(language);

            // Get the old language
            var currentCultureInfo = DependencyService.Get<ILocaleHelper>().GetCurrent();

            // Create and set the new language
            var newCultureInfo = new CultureInfo(languageName);
            AppResources.AppResource.Culture = newCultureInfo;              // set the RESX for resource localization
            DependencyService.Get<ILocaleHelper>().SetLocale(languageName); // set the Thread for locale-aware methods

            Debug.WriteLine($"Switched from {currentCultureInfo.DisplayName} language to {newCultureInfo.DisplayName}");
        }

        public static CultureInfo GetCurrentLanguage()
        {
            // Get the current language
            var currentCultureInfo = DependencyService.Get<ILocaleHelper>().GetCurrent();
            Debug.WriteLine($"Current language: {currentCultureInfo.DisplayName}");
            return currentCultureInfo;
        }

        private static string TranslateLanguageEnum(CultureLanguageEnum language)
        {
            switch (language)
            {
                case CultureLanguageEnum.French:
                    return "fr-FR";
                case CultureLanguageEnum.English:
                    return "en-US";
                case CultureLanguageEnum.Spain:
                case CultureLanguageEnum.Deutsch:
                case CultureLanguageEnum.Italian:
                default:
                    throw new NotImplementedException("language not managed yet");
            }
        }
    }
}
