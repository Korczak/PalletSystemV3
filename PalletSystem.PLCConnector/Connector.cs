using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.PLCConnector
{
    public class Connector
    {
        public string Name { get; }

        private Connector() { }

        public Connector(string name)
        {
            Name = name;
        }

        public static Connector Empty => new Connector();
    }
}
