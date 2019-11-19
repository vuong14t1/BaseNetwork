using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Network;

namespace ConsoleApp1.Network
{
    class ConnectorListener
    {
        public ArrayList modulesRegisterd = new ArrayList();

        public void AddModule(BaseModule baseModule) {
            modulesRegisterd.Add(baseModule);
        }

        public void onFinishConnect() {

        }

        public void onDisconnect() {

        }

        public void onReceived (byte[] rawData) {

        }
        
    }
}
