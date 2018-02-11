using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Cryptography
{
    public partial class Form1 : Form
    {
        static TcpClient client;
        static TcpClient RunTheClient;
        static TcpListener server;
        static bool ServerItIs = false;

        public Form1()
        {
            InitializeComponent();
        }

        // go to start server page
        private void RunServer_Click(object sender, EventArgs e)
        {
            StartServerPanel.BringToFront();
        }

        // go to start client page
        private void RunClient_Click(object sender, EventArgs e)
        {
            StartClientPanel.BringToFront();
        }

        // start the server
        private void StartServer_Click(object sender, EventArgs e)
        {
            ServerItIs = true;
            string portString = ServerPort.Text;
            ServerPort.Clear();
            bool valid = false;

            int temp = 0;
            int.TryParse(portString, out temp);

            if (temp > 0)
                valid = true;

            if (valid)
            {
                Int32 port = Int32.Parse(portString);
                IPAddress ip = IPAddress.Parse("127.0.0.1");

                server = new TcpListener(ip, port);

                // start server
                server.Start();

                // bring chat panel to front
                ChatPanel.BringToFront();
                TypeBox.Focus();
                ConnectionInfo.Text = "IP: " + GetLocalIPAddress() + "   Port: " + port;

                ThreadPool.QueueUserWorkItem(HandleClient);
                    

            }
        }

        private void HandleClient(object o)
        {
            // wait for client to join
            client = server.AcceptTcpClient();

            try
            {
                StreamReader sr = new StreamReader(client.GetStream());

                string msg = "";

                while (true)
                {
                    msg = sr.ReadLine();
                    ChatHistory.Items.Add("Client: " + msg);

                    if (msg.Contains("shutdown"))
                    {
                        MessageBox.Show("Breaking out now");
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
                client.Close();
                server.Stop();
                Application.Exit();
            }
        }

        // start the server
        private void EnterPressedServerPort(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                StartServer_Click(sender, e);

        }

      

        private void SendNormal_Click(object sender, EventArgs e)
        {
            string msg = TypeBox.Text;
            TypeBox.Clear();
            StreamWriter sw;

            if (ServerItIs)
                sw = new StreamWriter(client.GetStream());
            else
                sw = new StreamWriter(RunTheClient.GetStream());

            sw.AutoFlush = true;

            sw.WriteLine(msg);
            ChatHistory.Items.Add("Me: " + msg);
            TypeBox.Focus();
        }


        private void StartClient_Click(object sender, EventArgs e)
        {
            bool valid = false;
            IPAddress ip;
            int port = 0;            

            if (IPAddress.TryParse(ipbox.Text, out ip) && int.TryParse(clientport.Text, out port))
            {
                if (port > 0)
                    valid = true;
            }

            if(valid)
            {
                RunTheClient = new TcpClient();

                try
                {
                    // connect to server
                    RunTheClient.Connect(ip, port);              

                    if (RunTheClient.Connected)
                    {
                       // MessageBox.Show("Bringing clint chat to front");
                        ChatPanel.BringToFront();
                        ConnectionInfo.Text = "Connected to server " + ip.ToString() + " at port " + port;
                        TypeBox.Focus();
                        ThreadPool.QueueUserWorkItem(HandleServer);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }

        public void HandleServer(object o)
        {
            string msg = "";

            try
            {
                StreamReader sr = new StreamReader(RunTheClient.GetStream());

                while (true)
                {
                    msg = sr.ReadLine();
                    if (msg.Contains("shutdown"))
                        break;

                      ChatHistory.Items.Add("Server: " + msg);                    
                }
            }
            catch(Exception ex)
            {
                RunTheClient.Close();
                Application.Exit();
            }
        }


        // stackoverflow: get ip address
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private void EnterPressedOnTypeBox(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {            
                e.Handled = true;
                SendNormal_Click(sender, e);
            }
        }
    }
}
