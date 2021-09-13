using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenHouse
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage();
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
