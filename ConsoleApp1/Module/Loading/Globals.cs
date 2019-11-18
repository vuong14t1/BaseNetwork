using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Network;

namespace ConsoleApp1.Module.Loading
{
     class Globals
    {
        public static Connector connector;

        public static Connector GetConnector() {
            if (connector == null) {
                connector = new Connector();
            }
            return connector;
        }


           
    }
}
