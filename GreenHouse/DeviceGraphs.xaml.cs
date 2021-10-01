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
                await DisplayAlert("Error", $"{e.Message}", "OK!"); //TODO: Replace Reconnect with OK?
                                                                    //"No Internet", "Please reconnect and then pull down to refresh", "Reconnect!"
            }
        }
        public DeviceGraphs()
        {
            //1. Load from API
            //2. Then load Xaml form componenets

            InitializeComponent();
            //TODO: Call GraphHandler here and pass in currTimescale
        }

        

        //TODO: Call Api Fetch in Update UI save time?
        //TODO: Pass Timescale to GraphHandler here
        private void UpdateUI()
        {
            
            if (GraphDataObj == null || GraphDataObj.unprocessedDeviceData == null)
            {
                Console.WriteLine("No internet pull down to refresh");
            }

            Label_DeviceTitle.Text = $"Device {currDevice} dashboard";
            Label_CurrentTimescale.Text = $"Displaying {currTimescale} Timescale";


            //TODO: SET EACH GRAPH HERE

            //LineChart baseChart = new LineChart { Entries = null, ValueLabelOrientation = Orientation.Vertical, LabelTextSize = 30, PointSize=5};// Will IsAnimated breaK?

            //Will these overriding of baseChart templates work? or will we have to make new LineCharts

            GraphDataObj.ReturnAllChartPlots(currTimescale);

            //
            Chart_Temp.Chart = new LineChart { Entries = GraphDataObj.GraphReadyData[0], ValueLabelOrientation = Orientation.Vertical, LabelTextSize = 30, PointSize = 5 };

            Chart_Humidity.Chart = new LineChart { Entries = GraphDataObj.GraphReadyData[1], ValueLabelOrientation = Orientation.Vertical, LabelTextSize = 30, PointSize = 5 };

            Chart_CO2.Chart = new LineChart { Entries = GraphDataObj.GraphReadyData[2], ValueLabelOrientation = Orientation.Vertical, LabelTextSize = 30, PointSize = 5 };

            Chart_TVOC.Chart = new LineChart { Entries = GraphDataObj.GraphReadyData[3], ValueLabelOrientation = Orientation.Vertical, LabelTextSize = 30, PointSize = 5 };

            Chart_Moisture.Chart = new LineChart { Entries = GraphDataObj.GraphReadyData[4], ValueLabelOrientation = Orientation.Vertical, LabelTextSize = 30, PointSize = 5 };
        }

        //TODO NOT SET TO AN INSTANCE OF OBJECT
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

        //TODO: Maybe just one Eventhandler for the buttons and we detect what string is passed through

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
                await DisplayAlert("No Internet", "Please reconnect and then pull down to refresh", "Reconnect!"); //TODO: Replace Reconnect with OK?
    }
}
}
