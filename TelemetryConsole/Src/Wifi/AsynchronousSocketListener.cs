using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TelemetryConsole.Misc;

namespace TelemetryConsole.Src.Wifi
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
        public StringBuilder sb = new StringBuilder();

        // Client  socket.  
        public Socket WorkSocket;
    }

    public class AsynchronousSocketListener : Constants
    {
        private Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private const int bufSize = 8 * 1024;
        private State state = new State();
        private EndPoint epFrom = new IPEndPoint(IPAddress.Any, 0);
        private AsyncCallback recv = null;
        public int counter;



        public class State
        {
            public byte[] buffer = new byte[bufSize];
        }

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
            _socket.BeginReceiveFrom(state.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv = (ar) =>
            {
                State so = (State)ar.AsyncState;
                int bytes = _socket.EndReceiveFrom(ar, ref epFrom);
                _socket.BeginReceiveFrom(so.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv, so);
                foreach (byte item in so.buffer)
                {
                    RxByteQueue.Enqueue(item);
                }
            }, state);
        }

        public static void Send(byte[] data)
        {
            int portRemote = int.Parse(ConfigurationManager.AppSettings["PORTREMOTE"]);
            var ipRemote = IPAddress.Parse(ConfigurationManager.AppSettings["IPREMOTE"]);
            UdpClient udpClient = new UdpClient(portRemote);
            udpClient.Send(data, data.Length, new IPEndPoint(ipRemote, portRemote));
            Console.WriteLine("sent");
        }

        public static void StartListener()
        {

            var connectionString = ConfigurationManager.AppSettings["IP"];
            int connectionPort = int.Parse(ConfigurationManager.AppSettings["PORT"]);
            AsynchronousSocketListener s = new AsynchronousSocketListener();
            s.Server(connectionString,connectionPort);

        }
    }
}