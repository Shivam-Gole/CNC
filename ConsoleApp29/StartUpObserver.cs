using System;
using System.Collections.Generic;

namespace Cnc.cs
{
    public class StartUpObserver : IObserver
    {
        private readonly IAlert alert;
        private readonly Dictionary<SelfTestStatusCode, string> alertMessages;

        public StartUpObserver(IAlert alert)
        {
            this.alert = alert;
            this.alertMessages = new Dictionary<SelfTestStatusCode, string>
            {
                { SelfTestStatusCode.NoData, "No data received from CNC machine. Check power or connection." },
                { SelfTestStatusCode.ControllerBoardNotOk, "Controller board in the machine is not okay. Machine needs attention." },
                { SelfTestStatusCode.ConfigurationDataCorrupted, "Configuration data in the machine is corrupted. Machine needs attention." }
            };
        }

        public void Update(double temperature, double variation, int duration, SelfTestStatusCode statusCode)
        {
            if (alertMessages.TryGetValue(statusCode, out string alertMessage))
            {
                alert.SendAlert(alertMessage);
            }
        }
    }
}
