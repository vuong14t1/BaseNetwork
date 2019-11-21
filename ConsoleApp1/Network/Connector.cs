using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Threading;
using ConsoleApp1.Module.Loading;
namespace ConsoleApp1.Network
{
    class Connector
    {
        static ASCIIEncoding encoding = new ASCIIEncoding();
        public bool isConnected = false;
        public ConnectorListener clientListener = new ConnectorListener();
        private string uri;
        private TcpClient clientSocket = new TcpClient();
        private Thread listenDataThread; 

        //private WebSocket webSocket;

        public Connector() {
            
        }

        public void LoadConfig () {
            
        }

        public void ListenerData() {

        }

        public void Connect() {
            //khoi tao module
            Globals.GetModuleMgr();

            int port = 1102;
            string ip = "127.0.0.1";
            clientSocket.Connect(ip, port);
            isConnected = true;
            Console.WriteLine("create thread");
            listenDataThread = new Thread(ReadDataFromServer);
            listenDataThread.Start();

            Thread.Sleep(3000);
            TestSend();
        }

        public bool IsConnected() {
            return isConnected;
        }

        public void CLose() {
            clientSocket.Close();
            
        }
        

        public ConnectorListener GetListener() {
            return clientListener;
        }

        public static short GetCmdIdFromRawData(byte[] rawData) {
            int indexCmdId = 1;
            return (short)((rawData[indexCmdId] << 8) + (rawData[indexCmdId + 1] << 0));
        }

        public void ReadDataFromServer() {
            Stream stream = clientSocket.GetStream();
            while (true) {
                try {
                    byte[] data = new byte[5000];
                    int length = stream.Read(data, 0, data.Length);
                    Array.Resize(ref data, length);
                    if (data.Length > 0)
                    {
                        short cmdId = GetCmdIdFromRawData(data);
                        clientListener.onReceived(cmdId, data);
                        Console.WriteLine("data received cmdId: " + cmdId);
                        Console.WriteLine("data received length: " + length);

                    }
                    else
                    {
                        Console.WriteLine("data not received");
                    }
                } catch (Exception e) {
                    Console.WriteLine("disconnected");
                    break;
                }
                
            }
        }

        public void Send(byte[] rawData) {
            if (clientSocket != null) {
                Stream stream = clientSocket.GetStream();
                stream.Write(rawData, 0, rawData.Length);
            }
        }

        public void TestSend() {
            Console.WriteLine("vao day send");
            TestOutPacket opk = new TestOutPacket(1);
            opk.CreateData();
            Send(opk.GetData());
        }
    }
}
