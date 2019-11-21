using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Network;

namespace ConsoleApp1.Module.TestNetwork
{
    class TestModule: BaseModule
    {
        public override void ProcessPackages(short cmdId) {
            switch (cmdId) {
                case 1:
                    if (this.curPacket.GetError() == ErrorDefine.SUCCESS) {
                        Console.WriteLine("ProcessPackages ");
                    }
                    
                    break;
            }
        }

        public override InPacket CreateReceivePackage(short cmdId, byte[] rawData) {
            InPacket pk = null;
            switch (cmdId) {
                case 1:
                    pk = new TestInPacket();
                    break;
            }
            return pk;
        }
    }
}
