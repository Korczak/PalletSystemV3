using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.PLCConnector
{
    public class Config
    {
        public string WebApiUrl { get; set; }
        public LogEventLevel ConsoleLogLevel { get; set; } = LogEventLevel.Information;
        public string Ip { get; set; }
        public int Port { get; set; }
        public short Rack { get; set; }
        public short Slot { get; set; }
        public string Stations { get; set; }
    }
}
