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
    public partial class WebView : ContentPage
    {
        public WebView()
        {
            InitializeComponent();
        }
    }
}