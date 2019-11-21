using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Module.TestNetwork;

namespace ConsoleApp1.Network
{
   
    class ModuleMgr
    {
        private BaseModule testModule = new TestModule();
        public ModuleMgr() {
            testModule.RegisterListener();
            testModule.SetListenerValue(1, 1000);
        }
    }
}
