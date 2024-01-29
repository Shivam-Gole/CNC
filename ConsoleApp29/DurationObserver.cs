using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Cnc.cs
{
    public class DurationObserver : IObserver
    {
        private readonly IAlert alert;
        private int duration;
        private Timer timer; // Timer for monitoring duration every 15 minutes
        private const int ReportingInterval = 15 * 60 * 1000; // 15 minutes in milliseconds
        private const int ThresholdDuration = 6 * 60; // 6 hours in minutes

        public DurationObserver(IAlert alert)
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
            if (duration > ThresholdDuration)
            {
                alert.SendAlert("Continuous operation duration is more than 6 hours. Machine needs attention.");
            }
        }

        public void Update(double temperature, double variation, int duration, SelfTestStatusCode statusCode)
        {
            this.duration = duration;
        }
    }
}


