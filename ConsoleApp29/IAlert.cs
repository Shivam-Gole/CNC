using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnc.cs
{
    public interface IAlert
    {
        void SendAlert(string message);
    }
}
