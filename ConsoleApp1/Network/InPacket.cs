using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Network
{
    class InPacket
    {
        private byte pos;
        private int length;
        private byte controllerId;
        private short cmdId;
        private byte error;
        private byte[] data;
        public InPacket() {

        }

        public void Init(byte[] pkg) {
            this.pos = 0;
            this.length = pkg.Length;
            this.data = pkg;
            this.controllerId = GetByte();
            this.cmdId = GetShort();
            this.error = GetByte();
        }

        public byte[] GetData() {
            return this.data;
        }

        public byte ParseByte() {
            return this.data[this.pos++];
        }

        public byte GetByte() {
            byte b = ParseByte();
            return bb;
        }

        public bool GetBool() {
            return ParseByte() > 0;
        }

        public short GetShort() {
            if (this.pos + 2 > this.length) {
                return 0;
            }
            return (short)((ParseByte() << 8) + (ParseByte() & 255));
            
        }

        public int GetInt() {
            return ((this.ParseByte() & 255) << 24) +
            ((this.ParseByte() & 255) << 16) +
            ((this.ParseByte() & 255) << 8) +
            ((this.ParseByte() & 255) << 0);
        }

        public long GetLong() {
        return ((this.ParseByte() & 255) << 56) +
            ((this.ParseByte() & 255) << 48) +
            ((this.ParseByte() & 255) << 40) +
            ((this.ParseByte() & 255) << 32) +
            ((this.ParseByte() & 255) << 24) +
            ((this.ParseByte() & 255) << 16) +
            ((this.ParseByte() & 255) << 8) +
            ((this.ParseByte() & 255) << 0);
        }

        public double GetDouble () {
            byte[] byteArray = new byte[8];
            for(int i = 7; i >= 0; i--){
                byteArray[i] = ParseByte();
            }
            return BitConverter.ToDouble(byteArray, 0);
        }

        public ushort GetUnsignedShort()
        {
            int a = (this.ParseByte() & 255) << 8;
            int b = (this.ParseByte() & 255) << 0;
            return (ushort)(a + b);
        }

        public byte[] GetBytes(int size)
        {
            byte[] bytes = { };
            var i = 0;
            while (i < size)
            {
                bytes[i] = (this.ParseByte());
                i++;
            }

            return bytes;
        }

        public byte[] GetCharArray()
        {
            var size = this.GetUnsignedShort();
            return GetBytes(size);
        }

        public string GetString() {
            byte[] outChars = this.GetCharArray();
            return Encoding.ASCII.GetString(outChars);
        }

        public byte GetError() {
            return this.error;
        }

        public void ReadData() {
        }
    }
}
