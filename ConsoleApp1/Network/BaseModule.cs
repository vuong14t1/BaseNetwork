using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Module.Loading;

namespace ConsoleApp1.Network
{
    abstract class BaseModule
    {
        public InPacket curPacket;
        public byte errorCode;
        public short minListenerValue = 0;
        public short maxListenerValue = 0;

        public void RegisterListener() {
            Globals.GetConnector().GetListener().AddModule(this);
        }

        public void SetListenerValue(short min, short max) {
            minListenerValue = min;
            maxListenerValue = max;
        }

        public bool IsInRangeListener(short cmdId) {
            return cmdId >= minListenerValue && cmdId <= maxListenerValue;
        }

        public void OnListener(short cmdId, byte[] data) {
            this.curPacket = CreateReceivePackage(cmdId, data);
            if (this.curPacket != null) {
                this.curPacket.Init(data);
                this.errorCode = (byte)this.curPacket.GetError();
                if (this.curPacket.GetError() == ErrorDefine.SUCCESS) {
                    this.curPacket.ReadData();
                }
                ProcessPackages(cmdId);
            }
        }

        public virtual void ProcessPackages(short cmdId) {

        }

        public virtual InPacket CreateReceivePackage(short cmdId, byte[] data) {
            return null;
        }

        public static InPacket GetInPacket(Type clazz) {
            InPacket inPacket = (InPacket)Activator.CreateInstance(clazz);
            return inPacket;
        }

        public static OutPacket GetOutPacket(Type clazz) {
            OutPacket inPacket = (OutPacket)Activator.CreateInstance(clazz);
            return inPacket;
        }

        public InPacket GetCurPacket() {
            return this.curPacket;
        }

        public void Send(OutPacket opk) {
            opk.CreateData();
            Globals.GetConnector().Send(opk.GetData());
        }
    }
}
