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
            int port = 8080;
            string ip = "127.0.0.1";
            webSocket = new WebSocket(ip + ":" + port);

            webSocket.OnOpen += (sender, e) => {
            };

            webSocket.OnMessage += (sender, e) => {
                Byte[] rawData = e.RawData;
                clientListener.onReceived(rawData);
            };

            webSocket.OnError += (sender, e) => {

            };

            webSocket.OnClose += (sender, e) => {
                
            };
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
                webSocket.Connect();
            }
        }

        public void CLose() {
            if(webSocket != null) {
                webSocket.Close();
            }
        }
        

        public ConnectorListener GetListener() {
            return clientListener;
        }
    }
}
