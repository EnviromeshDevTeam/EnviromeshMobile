using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Util;
using GreenHouse.Logging;
using GreenHouse.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DroidLogger))]

namespace GreenHouse.Droid
{
    public class DroidLogger : IXamarinLog
    {
        //ANDROID IMPLEMENTATION
        //TODO: Anytime a Debug, Error or Warning comes up we call these and log to file
        //TODO: We make one for IOS as well??? OPTIONAL
        public void Debug(object _sender, string _message)
        {
            Android.Util.Log.Debug($"Origin: {_sender.ToString()}", $"Debug Message: {_message}");
            Console.WriteLine($"Origin: {_sender.ToString()}", $"Debug Message: {_message}");
        }

        public void Error(object _sender, string _message)
        {
            Android.Util.Log.Error($"Origin: {_sender.ToString()}", $"Debug Message: {_message}");
            Console.WriteLine($"Origin: {_sender.ToString()}", $"Debug Message: {_message}");
        }

        public void Log(object _sender, string _message)
        {
            Android.Util.Log.Info($"Origin: {_sender.ToString()}", $"Debug Message: {_message}");
            Console.WriteLine($"Origin: {_sender.ToString()}", $"Debug Message: {_message}");
        }

        public void Warning(object _sender, string _message)
        {
            Android.Util.Log.Warn($"Origin: {_sender.ToString()}", $"Debug Message: {_message}");
            Console.WriteLine($"Origin: {_sender.ToString()}", $"Debug Message: {_message}");
        }
    }
}