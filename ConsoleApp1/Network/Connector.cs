using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
namespace ConsoleApp1.Network
{
    class Connector
    {
        public bool isConnected = false;
        public ConnectorListener clientListener = new ConnectorListener();
        private string uri;

        private WebSocket webSocket;

        public Connector() {
            LoadConfig();

            webSocket.OnOpen += (sender, e) => {
                clientListener.onFinishConnect();
            };

            webSocket.OnMessage += (sender, e) => {
                if(e.IsPing == true) {
                    return;
                }
                Byte[] rawData = e.RawData;
                short cmdId = GetCmdIdFromRawData(rawData);
                clientListener.onReceived(cmdId, rawData);
            };

            webSocket.OnError += (sender, e) => {
                clientListener.onDisconnect();
            };

            webSocket.OnClose += (sender, e) => {
                
            };
        }

        public void LoadConfig () {
            int port = 8080;
            string ip = "ws://127.0.0.1";
            webSocket = new WebSocket(ip + ":" + port);
            webSocket.EmitOnPing = true;
        }

        public void ListenerData() {

        }

        public void Send(byte[] rawData) {
            webSocket.Send(rawData);
        }

        public void SendAsyn(byte[] rawData) {
            webSocket.SendAsync(rawData, null);
        }

        public void Connect() {
            if(webSocket != null) {
                isConnected = true;
                webSocket.Connect();
            }
        }

        public bool IsConnected() {
            return isConnected;
        }

        public void CLose() {
            if(webSocket != null) {
                webSocket.Close();
                isConnected = false;
            }
        }
        

        public ConnectorListener GetListener() {
            return clientListener;
        }

        public static short GetCmdIdFromRawData(byte[] rawData) {
            int indexCmdId = 1;
            return (short)((rawData[indexCmdId] << 8) + (rawData[indexCmdId + 1] & 255));
        }
    }
}
