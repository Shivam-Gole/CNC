using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnc.cs
{
    public class StartUpObserver : IObserver
    {
        private readonly IAlert alert;
        private SelfTestStatusCode statusCode;

        public StartUpObserver(IAlert alert)
        {
            this.alert = alert;
        }

        public void Update(double temperature, double variation, int duration, SelfTestStatusCode statusCode)
        {
            this.statusCode = statusCode;
            switch (statusCode)
            {
                case SelfTestStatusCode.NoData:
                    alert.SendAlert("No data received from CNC machine. Check power or connection.");
                    break;
                case SelfTestStatusCode.ControllerBoardNotOk:
                    alert.SendAlert("Controller board in the machine is not okay. Machine needs attention.");
                    break;
                case SelfTestStatusCode.ConfigurationDataCorrupted:
                    alert.SendAlert("Configuration data in the machine is corrupted. Machine needs attention.");
                    break;
                default:
                    break;
            }
        }
    }
}

