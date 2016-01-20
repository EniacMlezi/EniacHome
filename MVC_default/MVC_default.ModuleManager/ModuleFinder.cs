using MVC_default.ModuleManager;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

// State object for reading client data asynchronously
namespace MVC_default.ModuleManager
{
    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    public class ModuleFinder
    {
        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public ModuleFinder()
        {
        }

        public static void StartListening()
        {
            File.AppendAllText(@"C:\log.txt", System.DateTime.Now.ToString() + " -> Started listening for modules: " + Environment.NewLine);
            // Establish the local endpoint for the socket.
            // The DNS name of the computer
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            //Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                File.AppendAllText(@"C:\log.txt", System.DateTime.Now.ToString() + " -> ModuleFinder Exception: " + Environment.NewLine + Environment.NewLine +
                    e.ToString() + Environment.NewLine + Environment.NewLine);
            }
        }

        private static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();

            File.AppendAllText(@"C:\log.txt", System.DateTime.Now.ToString() + " -> Found new module" + Environment.NewLine);

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            StateObject state = new StateObject();
            state.workSocket = handler;
            // Get values in order to create the module
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        private static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket. 
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read 
                // more data.
                content = state.sb.ToString();
                if (!(content.IndexOf("<EOF>") > -1))
                {
                    // Not all data received. Get more.
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
                else
                {
                    AddModule(state);
                    handler.Disconnect(true);
                    handler.Close();
                }
            }
        }

        private static void AddModule (StateObject state)
        {
            string[] ModuleInfo = state.sb.ToString().Split('|');

            // Create the module object.
            Module module = new Module();
            module.Socket = state.workSocket;
            module.Name = ModuleInfo[0];
            module.Plugin = PluginManager.PluginManager.Current.GetPlugin(ModuleInfo[1].Substring(0, ModuleInfo[1].Length - 5));


            File.AppendAllText(@"C:\log.txt", System.DateTime.Now.ToString() + " -> [ModuleFinder] Adding module : " + state.sb.ToString() + Environment.NewLine);
            ModuleManager.Current.Add(module);
        }
    }
}