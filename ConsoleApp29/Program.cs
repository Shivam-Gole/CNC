using System;
using System.Collections.Generic;

namespace Cnc.cs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IAlert machineAlert = new MachineAlert();
            IAlert environmentAlert = new EnvironmentAlert();

            List<IObserver> observers = new List<IObserver>
        {
            new TempObserver(environmentAlert),
            new VariationObserver(machineAlert),
            new DurationObserver(machineAlert),
            new StartUpObserver(machineAlert)
        };

            // Simulate CNC monitor updates
            CNCMonitor monitor = new CNCMonitor(observers);
            monitor.Update(40, 0.06, 400, SelfTestStatusCode.ControllerBoardNotOk);

            // Simulate further updates
            monitor.Update(30, 0.03, 300, SelfTestStatusCode.AllOk);
        }
    }


}

