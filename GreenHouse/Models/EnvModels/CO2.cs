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
            //TODO: Convert to one class and foreach loop iterate with switch case and enum Timescale?
            List<ChartEntry> ChartPlotPoints = new List<ChartEntry>();
            switch (_chosenTimescale)
            {
                case "1H":
                    for (int i = 0; i < 6; i++)
                    {
                        ChartPlotPoints.Add(_1H[i].Convert2ChartEntry(i));
                    } 
                    return ChartPlotPoints;
                case "4H":
                    for (int i = 0; i < 6; i++)
                    {
                        ChartPlotPoints.Add(_4H[i].Convert2ChartEntry(i));
                    }
                    return ChartPlotPoints;
                case "12H":
                    for (int i = 0; i < 6; i++)
                    {
                        ChartPlotPoints.Add(_12H[i].Convert2ChartEntry(i));
                    }
                    return ChartPlotPoints;
                case "24H":
                    for (int i = 0; i < 6; i++)
                    {
                        ChartPlotPoints.Add(_24H[i].Convert2ChartEntry(i));
                    }
                    return ChartPlotPoints;
                case "6D":
                    for (int i = 0; i < 6; i++)
                    {
                        ChartPlotPoints.Add(_6D[i].Convert2ChartEntry(i));
                    }
                    return ChartPlotPoints;
                case "30D":
                    for (int i = 0; i < 6; i++)
                    {
                        ChartPlotPoints.Add(_30D[i].Convert2ChartEntry(i));
                    }
                    return ChartPlotPoints;
                default:
                    Console.WriteLine("No Timescale string provided");
                    throw new NotImplementedException();
            }
        }
    }
}
