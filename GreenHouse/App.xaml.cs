using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;
using GreenHouse.Logging;

namespace GreenHouse
{
    public partial class App : Application
    {
        public App()
        {

            InitializeComponent();

            MainPage = new NavigationPage();

            themeSetup();
        }

        /// <summary>
        /// Takes in user preference and sets our App.Xaml elements to either have a light or dark mode theme
        /// </summary>
        public void themeSetup()
        {
            bool dark = Preferences.Get("settings_Theme", false);
            if (dark)
            {
                App.Current.UserAppTheme = OSAppTheme.Dark;
            }
            else
            {
                App.Current.UserAppTheme = OSAppTheme.Light;
            }
            DependencyService.Get<IXamarinLog>().Log(this, "Theme Setup loaded!");
        }

        private void NavigateMainPage()
        {
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
