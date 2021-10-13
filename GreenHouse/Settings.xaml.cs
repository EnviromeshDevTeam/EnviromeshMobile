using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        private void themeswitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                App.Current.UserAppTheme = OSAppTheme.Dark;

            }
            else
            {
                App.Current.UserAppTheme = OSAppTheme.Light;
            }
        }
    }
}