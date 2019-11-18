using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Network
{
    class OutPacket
    {
        private byte pos = 0;
        private short cmdId;
        private byte controllerId;
        private byte[] data;
        private int capacity;
        private int length = 0;

        public OutPacket(int capacity) {
            this.data = new byte[capacity];
            this.capacity = capacity;
        }

        public void PutData() {
        }

        public void CreateData() {
            this.PackHeader();
            this.PutData();
            this.UpdateSize();
        }

        public void PackHeader() {

        }

        public void PutByte(byte b) {
            this.data[this.pos++] = b;
            this.length = this.pos;
        }

        public void PutBool(bool b) {
            byte rawByte = (byte)(b ? 1 : 0);
            PutByte(rawByte);
        }

        public void PutBytes(byte[] bytes) {
            int i = 0;
            while (i < bytes.Length) {
                this.PutByte(bytes[i++]);
            }
        }

        public void PutShort(short v) {
            this.PutByte((byte)((v >> 8) & 0xFF));
            this.PutByte((byte)((v >> 0) & 0xFF));
        }

        public void PutInt(int v) {
            this.PutByte((byte)((v >> 24) & 0xff));
            this.PutByte((byte)((v >> 16) & 0xff));
            this.PutByte((byte)((v >> 8) & 0xff));
            this.PutByte((byte)((v >> 0) & 0xff));
        }

        public void PutLong(long v) {
            int length = 7;
            byte[] bytes = { };
            int i = 0;
            while (length >= 0)
            {
                bytes[i++] = (byte)((v >> 0) & 0xff);
                v /= 256;
                length--;
            }

            i = 0;
            while (i < bytes.Length)
            {
                this.PutByte(bytes[bytes.Length - i - 1]);
                i++;
            }
        }

        public void PutString(string str) {
            byte[] rawByte = Encoding.ASCII.GetBytes(str);
            PutByteArray(rawByte);
        }

        public void PutByteArray(byte[] bytes) {
            this.PutShort((short)bytes.Length);
            this.PutBytes(bytes);
        }

        public void UpdateUnsignedShortAtPos(int v, int pos) {
            this.data[this.pos] = (byte)(v >> 8);
            this.data[pos + 1] = (byte)(v >> 0);
        }
        public void UpdateSize() {
            UpdateUnsignedShortAtPos(this.length - 3, 1);
        }

        public byte[] GetData()
        {
            byte[] dest = new byte[this.length];
            Array.Copy(this.data, 0, dest, 0, this.length);
            return dest;
        }
    }
}
