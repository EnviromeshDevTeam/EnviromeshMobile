using System;
using System.Collections.Generic;
using System.Text;
using Microcharts;
using Newtonsoft.Json;
using SkiaSharp;


namespace GreenHouse.Models.EnvModels
{
    //TODO: No point in this class
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

        public ChartEntry Convert2ChartEntry()
        {
            var random = new Random();
            ChartEntry entryObject = new ChartEntry(PlotValue)
            {
                Label = DateString,
                ValueLabel = PlotValue.ToString(),
                Color = SKColor.Parse(String.Format("#{0:X6}", random.Next(0x1000000)))
            };
            return entryObject;
        }
        //Color Randomizer from hex colors assign to color
        //Get set random color, Why dont we just overwrite ChartEntry
    }
}
