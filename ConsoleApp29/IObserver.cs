using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnc.cs
{
    public interface IObserver
    {
        void Update(double temperature, double variation, int duration, SelfTestStatusCode statusCode);
    }
}
