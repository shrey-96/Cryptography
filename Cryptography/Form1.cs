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
        BlowFish b = new BlowFish("04B915BA43FEB5B6");

        public Form1()
        {
            InitializeComponent();
        }

        // go to start server page
        private void RunServer_Click(object sender, EventArgs e)
        {
            StartServerPanel.BringToFront();
            ServerPort.Focus();
        }

        // go to start client page
        private void RunClient_Click(object sender, EventArgs e)
        {
            StartClientPanel.BringToFront();
            ipbox.Focus();
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

                try
                {
                    server = new TcpListener(ip, port);

                    // start server
                    server.Start();

                    // bring chat panel to front
                    ChatPanel.BringToFront();
                    TypeBox.Focus();
                    ConnectionInfo.Text = "IP: " + GetLocalIPAddress() + "   Port: " + port;

                    ThreadPool.QueueUserWorkItem(HandleClient);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
                MessageBox.Show("Port cannot be alphabet, special character or negative number." +
                    "Please try again");
        }

        private void HandleClient(object o)
        {
            // wait for client to join
            client = server.AcceptTcpClient();

            try
            {
                StreamReader sr = new StreamReader(client.GetStream());

                string msg = "";
                string key = "#=%913-#^";
                string encrypted = "";

                while (true)
                {
                    string SignalDecrypt = "";
                    msg = sr.ReadLine();

                    if (msg.Contains(key))
                    {
                        encrypted = msg.Replace(key, string.Empty);
                        ChatHistory.Items.Add("Client: |EC| " + encrypted);
                        msg = b.Decrypt_CBC(encrypted);
                        SignalDecrypt = "|DC| ";
                    }


                    ChatHistory.Items.Add("Client: " + SignalDecrypt + msg);
                    ScrollToBottom();
                }
            }
            catch (Exception)
            {
                client.Close();
                server.Stop();
                Application.Exit();
            }
        }

        // start the server
        private void EnterPressedServerPort(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                StartServer_Click(sender, e);

        }



        private void SendNormal_Click(object sender, EventArgs e)
        {
            string msg = TypeBox.Text;
            if (msg == "")
                return;

            TypeBox.Clear();
            StreamWriter sw;

            try
            {
                if (ServerItIs)
                    sw = new StreamWriter(client.GetStream());
                else
                    sw = new StreamWriter(RunTheClient.GetStream());

                sw.AutoFlush = true;

                sw.WriteLine(msg);
                ChatHistory.Items.Add("Me: " + msg);
                TypeBox.Focus();
                ScrollToBottom();
            }
            catch (Exception)
            {
                MessageBox.Show("No clients have connected yet... Try again later!", "Error 643");
            }
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

            if (valid)
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
                MessageBox.Show("Invalid entry. Please try again.");

        }

        public void HandleServer(object o)
        {
            string msg = "";
            string key = "#=%913-#^";
            string encrypted = "";

            try
            {
                StreamReader sr = new StreamReader(RunTheClient.GetStream());

                while (true)
                {
                    string SignalDecrypt = "";
                    msg = sr.ReadLine();

                    if (msg.Contains(key))
                    {
                        encrypted = msg.Replace(key, string.Empty);
                        ChatHistory.Items.Add("Server: |EC| " + encrypted);
                        msg = b.Decrypt_CBC(encrypted);
                        SignalDecrypt = "|DC| ";
                    }

                    ChatHistory.Items.Add("Server: " + SignalDecrypt + msg);
                    ScrollToBottom();
                }
            }
            catch (Exception)
            {
                RunTheClient.Close();
                Application.Exit();
            }
        }

        private void ScrollToBottom()
        {
            ChatHistory.SelectedIndex = ChatHistory.Items.Count - 1;
            ChatHistory.SelectedIndex = -1;
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

        private void SendEncrypted_Click(object sender, EventArgs e)
        {
            string msg = TypeBox.Text;
            if (msg == "")
                return;

            TypeBox.Clear();
            StreamWriter sw;
            string key = "#=%913-#^";

            string encrypted = key + b.Encrypt_CBC(msg);

            try
            {
                if (ServerItIs)
                    sw = new StreamWriter(client.GetStream());
                else
                    sw = new StreamWriter(RunTheClient.GetStream());

                sw.AutoFlush = true;

                sw.WriteLine(encrypted);
                ChatHistory.Items.Add("Me: " + msg);
                TypeBox.Focus();
                ScrollToBottom();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No clients have connected yet... Try again later!", "Error 643");
            }
        }

        private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(ChatHistory.Items[e.Index].ToString(), ChatHistory.Font, ChatHistory.Width).Height;
        }

        private void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(ChatHistory.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }

        private void ConnectToServer_Return(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                StartClient_Click(sender, e);
            }
        }
    }
}
