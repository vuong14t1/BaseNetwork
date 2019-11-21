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
                    Console.WriteLine("ProcessPackages");
                    break;
            }
        }
    }
}
