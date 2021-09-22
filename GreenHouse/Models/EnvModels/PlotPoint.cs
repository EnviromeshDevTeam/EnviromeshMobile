using System;
using System.Collections.Generic;
using System.Text;
using Microcharts;
using SkiaSharp;


namespace GreenHouse.Models.EnvModels
{
     public class PlotPoint: ChartEntry
     {
        public string DateString;
        public float PlotValue;

        public PlotPoint(string Label, float Value) : base(Value)
        {
            DateString = Label;
            PlotValue = Value;
        }



        //Color Randomizer from hex colors assign to color
        //Get set random color, Why dont we just overwrite ChartEntry
    }
}
