using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LampModule
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

    public partial class Lamp : Form
    {
        public Socket Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);

        public Lamp()
        {
            InitializeComponent();
            InitializeConnection();
        }

        private void InitializeConnection()
        {
            lblError.Text = "";
            try
            {
                Socket.Connect(ip);
                byte[] message = Encoding.ASCII.GetBytes("Lamp Woonkamer|LampPlugin<EOF>");
                int bytesSent = Socket.Send(message, message.Length, SocketFlags.None);

                Thread Receiving = new Thread(BeginReceive);
                Receiving.Start();
            }
            catch 
            {
                lblError.Text = "Could not connect to server";
            }
        }

        private void chkLamp_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblError_Click(object sender, EventArgs e)
        {
            InitializeConnection();
        }

        private void BeginReceive()
        {
            Thread.CurrentThread.IsBackground = true;
            while (true)
            {
                StateObject state = new StateObject();
                Receive(state);
            }
        }

        private void Receive(StateObject state)
        {
            int bytesRead = 0;
            try
            {
                bytesRead = Socket.Receive(state.buffer, Socket.Available, SocketFlags.None);
                if (bytesRead > 0)
                {
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    String content = state.sb.ToString();
                    if (!(content.IndexOf("<EOF>") > -1))
                    {
                        Receive(state);
                    }
                    else
                    {
                        Process(state.sb.ToString());
                    }
                }
            }
            catch
            {
                Disconnect();
            }
        }

        private void Disconnect()
        {
            try
            {
                Socket.Shutdown(SocketShutdown.Both);
                Socket.Disconnect(false);
                Socket.Close();
            }
            catch { }
            finally
            {
                MethodInvoker inv = delegate
                {
                    this.lblError.Text = "Server Disconnected";
                };
                this.Invoke(inv);
            }
        }

        private void Process(string Received)
        {
            switch (Received)
            {
                case "disconnect<EOF>":
                    MessageBox.Show("Server disconnected", "Disconnected", MessageBoxButtons.OK);
                    Disconnect();
                    break;
                case "get<EOF>":
                    byte[] msg = Encoding.ASCII.GetBytes(chkLamp.Checked.ToString() + "<EOF>");
                    int bytesSend = Socket.Send(msg, msg.Length, SocketFlags.None);
                    if (!(bytesSend > 0))
                    {
                        lblError.Text = "Could not send to server";
                    }
                    break;
                case "toggle<EOF>":
                    if (chkLamp.Checked)
                        chkLamp.Checked = false;
                    else
                        chkLamp.Checked = true;
                    break;
            }
        }
    }
}
