using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Network;
using ConsoleApp1.Module.Loading;

namespace ConsoleApp1.Network
{
    class ConnectorListener
    {
        public ArrayList modulesRegisterd = new ArrayList();

        public void AddModule(BaseModule baseModule) {
            modulesRegisterd.Add(baseModule);
        }

        public void onFinishConnect() {
            //khi websocket thiet lap
            //gui goi handshake
        }

        public void onDisconnect() {

        }

        public void onReceived (short cmdId, byte[] rawData) {
            if(!Globals.GetConnector().IsConnected()) return;
            Console.WriteLine("vao day cmd " + cmdId);
            foreach(BaseModule baseModule in  modulesRegisterd) {
               
                if (baseModule.IsInRangeListener(cmdId)) {
                    baseModule.OnListener(cmdId, rawData);
                }
            }
        }
        
    }
}
