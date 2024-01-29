using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnc.cs
{
    public enum SelfTestStatusCode
    {
        AllOk = 0xFF,
        NoData = 0x00,
        ControllerBoardNotOk = 0x01,
        ConfigurationDataCorrupted = 0x02
    }
}
