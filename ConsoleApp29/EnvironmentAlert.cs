using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnc.cs
{
    public class EnvironmentAlert : IAlert
    {
        public void SendAlert(string message)
        {
            Console.WriteLine("Environment Alert: " + message);
        }
    }
}
