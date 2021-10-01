using Microcharts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenHouse.Models.EnvModels
{
    public class CO2
    {
        // TODO: WE convert all EnvModels to inherit from one superclass? Saves alot of this code?
        [JsonProperty("1H")]
        public List<PlotPoint> _1H { get; set; }

        [JsonProperty("4H")]
        public List<PlotPoint> _4H { get; set; }

        [JsonProperty("12H")]
        public List<PlotPoint> _12H { get; set; }

        [JsonProperty("24H")]
        public List<PlotPoint> _24H { get; set; }

        [JsonProperty("6D")]
        public List<PlotPoint> _6D { get; set; }

        [JsonProperty("30D")]
        public List<PlotPoint> _30D { get; set; }

        public List<ChartEntry> ReturnPlotPoints(string _chosenTimescale)
        {
            List<ChartEntry> ChartPlotPoints = new List<ChartEntry>();
            switch (_chosenTimescale)
            {
                case "1H":
                    foreach (PlotPoint item in _1H)
                    {
                        ChartPlotPoints.Add(item.Convert2ChartEntry());
                    }
                    return ChartPlotPoints;
                case "4H":
                    foreach (PlotPoint item in _4H)
                    {
                        ChartPlotPoints.Add(item.Convert2ChartEntry());
                    }
                    return ChartPlotPoints;
                case "12H":
                    foreach (PlotPoint item in _12H)
                    {
                        ChartPlotPoints.Add(item.Convert2ChartEntry());
                    }
                    return ChartPlotPoints;
                case "24H":
                    foreach (PlotPoint item in _24H)
                    {
                        ChartPlotPoints.Add(item.Convert2ChartEntry());
                    }
                    return ChartPlotPoints;
                case "6D":
                    foreach (PlotPoint item in _6D)
                    {
                        ChartPlotPoints.Add(item.Convert2ChartEntry());
                    }
                    return ChartPlotPoints;
                case "30D":
                    foreach (PlotPoint item in _30D)
                    {
                        ChartPlotPoints.Add(item.Convert2ChartEntry());
                    }
                    return ChartPlotPoints;
                default:
                    Console.WriteLine("No Timescale string provided");
                    throw new NotImplementedException();
            }
        }
    }
}
