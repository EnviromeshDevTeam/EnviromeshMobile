using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenHouse
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
            loadToggleStates();
        }

        /// <summary>
        /// TODO: Try catch and Log
        /// </summary>
        private async void loadToggleStates()
        {
            if (!checkForPref("settings_Theme"))
            {
                await DisplayAlert("DEBUG:", "CHECK Pref Key", "Ok!");
                return; 
            }
            themeswitch.IsToggled = Preferences.Get("settings_Theme", false);
        }

        //For Checking new key/unknown prefs
        private bool checkForPref(string _key)
        {
            bool hasKey = Preferences.ContainsKey(_key);
            return hasKey;
        }


        private void setPref(string _settingKey, dynamic _settingValue)
        {
            Preferences.Set(_settingKey, _settingValue);
        }


        private void themeswitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                setPref("settings_Theme", true);
                App.Current.UserAppTheme = OSAppTheme.Dark;
            }
            else
            {
                setPref("settings_Theme", false);
                App.Current.UserAppTheme = OSAppTheme.Light;
            }
        }
    }
}