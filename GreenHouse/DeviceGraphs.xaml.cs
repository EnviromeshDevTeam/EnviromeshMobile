using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GreenHouse
{
    public partial class DeviceGraphs : ContentPage
    {
        public string currTimescale { get; set; } = "1H";
        public DeviceGraphs()
        {
            InitializeComponent();
            //TODO: Call GraphHandler here and pass in currTimescale
        }

        private void Button_1H_Graphs_Clicked(object sender, EventArgs e)
        {
            currTimescale = "1H";
        }

        private void Button_4H_Graphs_Clicked(object sender, EventArgs e)
        {
            currTimescale = "4H";
        }

        private void Button_12H_Graphs_Clicked(object sender, EventArgs e)
        {
            currTimescale = "12H";
        }

        private void Button_24H_Graphs_Clicked(object sender, EventArgs e)
        {
            currTimescale = "24H";
        }

        private void Button_6D_Graphs_Clicked(object sender, EventArgs e)
        {
            currTimescale = "6D";
        }

        private void Button_30D_Graphs_Clicked(object sender, EventArgs e)
        {
            currTimescale = "30D";
        }
    }
}
