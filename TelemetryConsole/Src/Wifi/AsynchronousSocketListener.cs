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
        // Thread signal.  
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public static void StartListening()
        {
            string configIp = ConfigurationManager.AppSettings["IP"];
            var ipAddress = IPAddress.Parse(configIp);
            var localEndPoint = new IPEndPoint(ipAddress, 20526);

            // Create a TCP/IP socket.  
            var listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    // Set the event to nonsignaled state.  
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.  
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(
                        AcceptCallback,
                        listener);

                    // Wait until a connection is made before continuing.  
                    allDone.WaitOne();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.  
            allDone.Set();

            // Get the socket that handles the client request.  
            var listener = (Socket) ar.AsyncState;
            var handler = listener.EndAccept(ar);

            // Create the state object.  
            var state = new StateObject();
            state.WorkSocket = handler;
            handler.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0,
                ReadCallback, state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            var state = (StateObject) ar.AsyncState;
            var handler = state.WorkSocket;

            // Read data from the client socket.   
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                Console.Write("Received");
                Console.Write(new string(' ', Console.BufferWidth));
                foreach (byte item in state.Buffer)
                {
                    RxByteQueue.Enqueue(item);
                }
                handler.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0,
                    ReadCallback, state);
            }

        }
    }
}