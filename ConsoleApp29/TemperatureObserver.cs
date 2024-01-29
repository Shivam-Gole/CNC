using System;
using System.Timers;

namespace Cnc.cs
{
    public class TempObserver
    {
        private readonly IAlert alert;
        private Timer timer;
        private double temperature;
        private const int ReportingInterval = 30 * 60 * 1000; // 30 minutes in milliseconds

        public TempObserver(IAlert alert)
        {
            this.alert = alert;
            SetupTimer();
        }

        private void SetupTimer()
        {
            timer = new Timer(ReportingInterval);
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
    }
}
