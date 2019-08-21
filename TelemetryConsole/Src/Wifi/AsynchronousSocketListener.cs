using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TelemetryConsole.Misc;

namespace TelemetryConsole.Wifi
{
// State object for reading client data asynchronously  
//https://docs.microsoft.com/en-us/dotnet/framework/network-programming/asynchronous-server-socket-example
//TO learn to send data
    public class StateObject
    {
        // Size of receive buffer.  
        public const int BufferSize = 1024;

        // Receive buffer.  
        public byte[] Buffer = new byte[BufferSize];

        // Received data string.  
        public StringBuilder Sb = new StringBuilder();

        // Client  socket.  
        public Socket WorkSocket;
    }

    public class AsynchronousSocketListener : Constants
    {
        private const int BufSize = 8 * 1024;
        private readonly Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private readonly State _state = new State();
        private EndPoint _epFrom = new IPEndPoint(IPAddress.Any, 0);
        private AsyncCallback _recv;
        public int Counter;

        public void Server(string address, int port)
        {
            try
            {
                _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
                _socket.Bind(new IPEndPoint(IPAddress.Parse(address), port));
                Receive();
                Console.WriteLine("WiFi Dongle Running");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void Receive()
        {
            _socket.BeginReceiveFrom(_state.Buffer, 0, BufSize, SocketFlags.None, ref _epFrom, _recv = ar =>
            {
                State so = (State) ar.AsyncState;
                int bytes = _socket.EndReceiveFrom(ar, ref _epFrom);
                _socket.BeginReceiveFrom(so.Buffer, 0, BufSize, SocketFlags.None, ref _epFrom, _recv, so);
                foreach (byte item in so.Buffer)
                {
                    RxByteQueue.Enqueue(item);
                }
            }, _state);
        }

        public static void Send(byte[] data)
        {
            int portRemote = int.Parse(ConfigurationManager.AppSettings["PORTREMOTE"]);
            IPAddress ipRemote = IPAddress.Parse(ConfigurationManager.AppSettings["IPREMOTE"]);
            UdpClient udpClient = new UdpClient(portRemote);
            udpClient.Send(data, data.Length, new IPEndPoint(ipRemote, portRemote));
            Console.WriteLine("sent");
        }

        public static void StartListener()
        {
            string connectionString = ConfigurationManager.AppSettings["IP"];
            int connectionPort = int.Parse(ConfigurationManager.AppSettings["PORT"]);
            AsynchronousSocketListener s = new AsynchronousSocketListener();
            s.Server(connectionString, connectionPort);
        }


        public class State
        {
            public byte[] Buffer = new byte[BufSize];
        }
    }
}