using System;
using System.Collections.Generic;


namespace Cnc.cs
{
    public class CNCMonitor
    {
        private readonly List<IObserver> observers;

        public CNCMonitor(List<IObserver> observers)
        {
            this.observers = observers;
        }

        public void Update(double temperature, double variation, int duration, SelfTestStatusCode statusCode)
        {
            foreach (var observer in observers)
            {
                observer.Update(temperature, variation, duration, statusCode);
            }
        }
    }
}
