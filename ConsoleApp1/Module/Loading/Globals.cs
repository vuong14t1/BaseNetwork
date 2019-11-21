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
        public static ModuleMgr moduleMgr;

        public static Connector GetConnector() {
            if (connector == null) {
                connector = new Connector();
            }
            return connector;
        }

        public static ModuleMgr GetModuleMgr() {
            if (moduleMgr == null) {
                moduleMgr = new ModuleMgr();
            }

            return moduleMgr;
        }


           
    }
}
