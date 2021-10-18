using System;
using System.Collections.Generic;
using System.Text;

namespace GreenHouse.Logging
{
    public interface IXamarinLog
    {
        //We call Log, Debug, Error, Warning Where appropriate
        //TODO: Anytime a Debug, Error or Warning comes up we call these and log to file
        void Log(object _sender, string _message);
        void Debug(object _sender, string _message);
        void Error(object _sender, string _message);
        void Warning(object _sender, string _message);

    }
}
