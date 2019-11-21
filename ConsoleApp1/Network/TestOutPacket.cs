using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Network
{
    class TestOutPacket: OutPacket
    {
        public TestOutPacket(short cmdId) {
            InitData(1);
            SetCmdId(cmdId);
        }

        public override void PutData() {
            Console.WriteLine("vao day put data");
            PutString("vuong");
            PutString("_");
            PutString("_");
        }

    }

    class TestInPacket : InPacket {
        public byte res;
        public TestInPacket() {

        }

        public new void ReadData() {
            res = GetByte();
            Console.WriteLine("date recevied login " + res);
        }
    }
}
