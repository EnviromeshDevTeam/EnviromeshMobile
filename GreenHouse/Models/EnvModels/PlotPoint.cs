using System;
using System.Collections.Generic;
using System.Text;
using Microcharts;
using Newtonsoft.Json;
using SkiaSharp;


namespace GreenHouse.Models.EnvModels
{
    /// <summary>
    /// To Manipulate API Json Into PlotPoints
    /// </summary>
     public class PlotPoint
     {
        [JsonProperty("date")]
        public string DateString { get; set; }

        [JsonProperty("value")]
        public float PlotValue { get; set; }

        public PlotPoint(string _dateString, float _plotValue)
        {
            DateString = _dateString;
            PlotValue = _plotValue;
        }

        public ChartEntry Convert2ChartEntry(int _index)
        {
            List<string> list_DarkHexCodes = new List<string> { "#770087", "#9600B3", "#AA00D7", "C030ED", "#DC86FA", "#FBF2FF" };
            var random = new Random();
            ChartEntry entryObject = new ChartEntry(PlotValue)
            {
                Label = DateString,
                ValueLabel = PlotValue.ToString(),
                Color = SKColor.Parse(list_DarkHexCodes[_index])
            };
        return entryObject;
        }
        //Color Randomizer from hex colors assign to color
        //Get set random color, Why dont we just overwrite ChartEntry
    }
}
