using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Network
{
    class Connector
    {
        public bool isConnected = false;
        public ConnectorListener clientListener = new ConnectorListener();

        public ConnectorListener GetListener() {
            return clientListener;
        }
    }
}
