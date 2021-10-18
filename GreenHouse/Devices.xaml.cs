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
    public partial class Devices : ContentPage
    {
        public Devices()
        {
            InitializeComponent();
        }

        private async void device1_clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new DeviceGraphs ());
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            device_NotImplemented();
        }

        private async void device_NotImplemented()
        {
            await DisplayAlert("Null", "This Device has not been implemented yet :'-( ", "OK!");
        }
    }
}