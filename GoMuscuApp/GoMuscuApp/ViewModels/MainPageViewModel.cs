using GoMuscuApp.Models.MVVM;
using GoMuscuApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GoMuscuApp.ViewModels
{
    public class MainPageViewModel : CustomNotifyPropertyChanged
    {
        private Command _loadPage1;

        public Command LoadPage1
        {
            get { return _loadPage1; }
            set { _loadPage1 = value; }
        }

        public MainPageViewModel()
        {
            this.LoadPage1 = new Command(async () => await LoadPage());
        }

        private async Task LoadPage()
        {
            var page = new SessionDetailsPage();
            await Application.Current.MainPage.Navigation.PushAsync(page);
            NavigationPage.SetHasBackButton(page, true);
            //NavigationPage.SetHasNavigationBar(page, false);
            //NavigationPage.SetBackButtonTitle(page, "Back");
        }
    }
}
