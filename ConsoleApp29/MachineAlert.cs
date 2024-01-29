using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnc.cs
{
    public class MachineAlert : IAlert
    {
        public void SendAlert(string message)
        {
            Console.WriteLine("Machine Alert: " + message);
        }
    }
}
