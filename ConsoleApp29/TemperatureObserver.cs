using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Cnc.cs
{
    public class TempObserver : IObserver
    {
        private readonly IAlert alert;
        private double temperature;
        private Timer timer; // Timer for monitoring temperature every half-hour
        private const int ReportingInterval = 30 * 60 * 1000; // 30 minutes in milliseconds

        public TempObserver(IAlert alert)
        {
            this.alert = alert;
            SetupTimer();
        }

        private void SetupTimer()
        {
            timer = new Timer();
            timer.Interval = ReportingInterval;
            timer.Elapsed += OnTimerElapsed;
            timer.AutoReset = true;
            timer.Start();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (temperature > 35)
            {
                alert.SendAlert("Operating temperature is above 35 degrees Celsius. Environment needs attention.");
            }
        }

        public void Update(double temperature, double variation, int duration, SelfTestStatusCode statusCode)
        {
            this.temperature = temperature;
        }
    }
}

