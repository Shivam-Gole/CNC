using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnc.cs
{
    public class VariationObserver : IObserver
    {
        private readonly IAlert alert;
        private double variation;

        public VariationObserver(IAlert alert)
        {
            this.alert = alert;
        }

        public void Update(double temperature, double variation, int duration, SelfTestStatusCode statusCode)
        {
            this.variation = variation;
            if (variation > 0.05)
            {
                alert.SendAlert("Part dimension variation is more than 0.05 mm. Machine needs attention.");
            }
        }
    }
}
