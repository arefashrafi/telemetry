using System;
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
        // Client  socket.  
        public Socket WorkSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 1024;
        // Receive buffer.  
        public byte[] Buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }

    public class AsynchronousSocketListener:Constants
    {
        // Thread signal.  
        public static ManualResetEvent allDone = new ManualResetEvent(false);
    
        public AsynchronousSocketListener()
        {
        }

        public static void StartListening()
        {
            string configIp = System.Configuration.ConfigurationManager.AppSettings["IP"];
            IPAddress ipAddress = IPAddress.Parse(configIp);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 20526);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
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
                                         new AsyncCallback(AcceptCallback),
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
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.  
            StateObject state = new StateObject();
            state.WorkSocket = handler;
            handler.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0,
                                 new AsyncCallback(ReadCallback), state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.WorkSocket;

            // Read data from the client socket.   
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                foreach (byte item in state.Buffer)
                {
                    RxByteQueue.Enqueue(item);
                }
            }
        }

    }
}