using GreenHouse.Backend;
using GreenHouse.Models;
using Microcharts;
using Microcharts.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GreenHouse
{
    public partial class DeviceGraphs : ContentPage
    {
        public int currDevice { get; set; } = 1;
        public string currTimescale { get; set; } = "1H";
        private GraphHandler GraphDataObj { get; set; }


        //Do we initialize graphs here?
        /// <summary>
        /// Loads Before InitializeComponent() Create Initial API ref
        /// </summary>
        
        //erroring at Object ref Not set to an instance of object. Dependant on our loading of items
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                GraphDataObj = new GraphHandler();
                await GraphDataObj.AsyncRefreshFromApi(currDevice);
                GraphDataObj.ReturnAllChartPlots(currTimescale);
                UpdateUI();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await DisplayAlert("Error", $"{e.Message}", "OK!");
            }
        }
        public DeviceGraphs()
        {
            InitializeComponent();
        }

        private void UpdateUI()
        {
            
            if (GraphDataObj == null || GraphDataObj.unprocessedDeviceData == null)
            {
                Console.WriteLine("No internet pull down to refresh");
            }

            Label_DeviceTitle.Text = $"Device {currDevice} Dashboard";
            Label_CurrentTimescale.Text = $"Displaying {currTimescale} Timescale";


            GraphDataObj.ReturnAllChartPlots(currTimescale);

            SkiaSharp.SKColor dateColor = SkiaSharp.SKColor.Parse("ffffff");//fff or white for Dark mode and 000000 for Light mode
            if (!Preferences.Get("settings_Theme", false))
            {
                dateColor = SkiaSharp.SKColor.Parse("000000");
            }

            SkiaSharp.SKColor transparentCol = SkiaSharp.SKColor.Parse("#00ffffff");


            Chart_Temp.Chart = new LineChart { Entries = GraphDataObj.GraphReadyData[0],  ValueLabelOrientation = Orientation.Vertical, LabelTextSize = 35, PointSize = 25, LabelColor= dateColor, BackgroundColor = transparentCol };

            Chart_Humidity.Chart = new LineChart { Entries = GraphDataObj.GraphReadyData[1], ValueLabelOrientation = Orientation.Vertical, LabelTextSize = 35, PointSize = 25, LabelColor = dateColor, BackgroundColor = transparentCol };

            Chart_CO2.Chart = new LineChart { Entries = GraphDataObj.GraphReadyData[2], ValueLabelOrientation = Orientation.Vertical, LabelTextSize = 35, PointSize = 25, LabelColor = dateColor, BackgroundColor = transparentCol };

            Chart_TVOC.Chart = new LineChart { Entries = GraphDataObj.GraphReadyData[3], ValueLabelOrientation = Orientation.Vertical, LabelTextSize = 35, PointSize = 25, LabelColor = dateColor, BackgroundColor = transparentCol };

            Chart_Moisture.Chart = new LineChart { Entries = GraphDataObj.GraphReadyData[4], ValueLabelOrientation = Orientation.Vertical, LabelTextSize = 35, PointSize = 25, LabelColor = dateColor, BackgroundColor = transparentCol };
        }

        private async void RefreshView_Dashboard_Refreshing(object sender, EventArgs e)
        {
            try
            {
                await GraphDataObj.AsyncRefreshFromApi(currDevice);
                UpdateUI();
                RefreshView_Dashboard.IsRefreshing = false;
            }
            catch (Exception _e)
            {
                FailedConnectFunc(_e);
                RefreshView_Dashboard.IsRefreshing = false;
            }
        }

        private void Button_TimeScaleChange(object sender, EventArgs e)
        {
            Button button = sender as Button;
            RefreshView_Dashboard.IsRefreshing = true;
            currTimescale = button.Text;
            GraphDataObj.ReturnAllChartPlots(button.Text
                );
            UpdateUI();
            RefreshView_Dashboard.IsRefreshing = false;
        }

        private async void FailedConnectFunc (Exception _e)
            {
                Console.WriteLine(_e.Message);
                await DisplayAlert("No Internet", "Please reconnect and then pull down to refresh", "Ok!"); 
    }
}
}
