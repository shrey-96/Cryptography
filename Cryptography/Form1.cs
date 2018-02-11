/*
 *  Project:        Cryptography
 *  File:           Form1.cs
 *  Author:         Shreyansh Tiwari
 *  Date:           11th February, 2018
 *  Description:    This file contains all the logic for running server and client.
 *                  This file takes the strings from the interface and validates them,
 *                  makes sure connection is established or else user will be displayed
 *                  error. Exceptions have been covered such as user trying to send message
 *                  without connection, either client or server closes, other closes as well
 *                  shutting down the connection on their end. 
 */

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

        // variable to determine whether application is running server or client
        static bool ServerItIs = false;

        // Initialising Bruce schneier's Blowfish class with a Key 
        BlowFish b = new BlowFish("04B915BA43FEB5B6");

        public Form1()
        {
            InitializeComponent();
        }

        // Method:      RunServer_Click()
        // Description: This method brings the Server panel, where user gets to enter the
        //              port, to the front and focuses on ServerPort textbox.
        private void RunServer_Click(object sender, EventArgs e)
        {
            StartServerPanel.BringToFront();
            ServerPort.Focus();
        }

        // Method:      RunClient_Click()
        // Description: This method brings the Client panel, where user gets to enter the
        //              IP and port of server, to the front and focuses on ClientPort textbox.
        private void RunClient_Click(object sender, EventArgs e)
        {
            StartClientPanel.BringToFront();
            ipbox.Focus();
        }

        // Method:      StartServer_Click()
        // Description: This method takes the port from the interface, validates it
        //              and once validated, it fire ups the server and send user to
        //              chat screen.
        private void StartServer_Click(object sender, EventArgs e)
        {
            // application is running server, update the variable to let other methods know
            ServerItIs = true;

            // get port from interface and clear the textbox
            string portString = ServerPort.Text;
            ServerPort.Clear();
            bool valid = false;


            // validate port
            int temp = 0;
            int.TryParse(portString, out temp);

            if (temp > 0)
                valid = true;

            // start server if port is valid
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

                    // update textbox at the top with IP address and port
                    ConnectionInfo.Text = "IP: " + GetLocalIPAddress() + "   Port: " + port;

                    // start thread to handle the client
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

        // Method:      HandleClient()
        // Description: This method keeps looping and receiving the messages from client
        //              and update the chat history with it. If message is encrypted,
        //              it displays the encrypted message first followed by decrypted 
        //              version of same message.
        private void HandleClient(object o)
        {
            // wait for client to join
            client = server.AcceptTcpClient();

            try
            {
                // establish reader to read from stream
                StreamReader sr = new StreamReader(client.GetStream());

                string msg = "";
                string key = "#981#-";
                string encrypted = "";

                // keep reading until client is closed
                while (true)
                {
                    string SignalDecrypt = "";
                    msg = sr.ReadLine();

                    // if received message is encrypted
                    if (msg.Contains(key))
                    {
                        encrypted = msg.Replace(key, string.Empty);
                        ChatHistory.Items.Add("Client: |EC| " + encrypted);

                        // decrypt the message
                        msg = b.Decrypt_CBC(encrypted);
                        SignalDecrypt = "|DC| ";
                    }


                    ChatHistory.Items.Add("Client: " + SignalDecrypt + msg);
                    ScrollToBottom();
                }
            }
            // client has left
            catch (Exception)
            {
                // close connection with client and stop server and exit
                client.Close();
                server.Stop();
                Application.Exit();
            }
        }

        // Method:      EnterPressedServerPort()
        // Description: This method is invoked when a key is pressed on ServerPort text box
        //              and if the key is "Enter", then StartServer_Click is invoked.
        private void EnterPressedServerPort(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                StartServer_Click(sender, e);
            }

        }


        // Method:      SendNormal_Click()
        // Description: This method takes the message from textbox, and send it over on
        //              the established TCP stream (unencrypted).
        private void SendNormal_Click(object sender, EventArgs e)
        {
            // get message from interface and make sure it is not empty
            string msg = TypeBox.Text;
            if (msg == "")
                return;

            // clear typebox after reading message
            TypeBox.Clear();
            StreamWriter sw;

            try
            {
                // start the stream based on whether or not it is server
                if (ServerItIs)
                    sw = new StreamWriter(client.GetStream());
                else
                    sw = new StreamWriter(RunTheClient.GetStream());

                sw.AutoFlush = true;

                // write message to stream
                sw.WriteLine(msg);

                // add the chat history
                ChatHistory.Items.Add("Me: " + msg);
                TypeBox.Focus();
                ScrollToBottom();
            }
            catch (Exception)
            {
                MessageBox.Show("No clients have connected yet... Try again later!", "Error 643");
            }
        }

        // Method:      StartClient_Click()
        // Description: This method takes the IP and port from the interface, validates it
        //              and once validated, it tries to connect to server, once connected,
        //              send user to chat screen.
        private void StartClient_Click(object sender, EventArgs e)
        {
            bool valid = false;
            IPAddress ip;
            int port = 0;

            // validate ip and port
            if (IPAddress.TryParse(ipbox.Text, out ip) && int.TryParse(clientport.Text, out port))
            {
                if (port > 0)
                    valid = true;
            }

            // initialise client and connect to server if valid
            if (valid)
            {
                RunTheClient = new TcpClient();

                try
                {
                    // connect to server
                    RunTheClient.Connect(ip, port);

                    if (RunTheClient.Connected)
                    {                        
                        ChatPanel.BringToFront();                                               
                        ConnectionInfo.Text = "Connected to server " + ip.ToString() + " at port " + port;
                        TypeBox.Focus();

                        // start thread to receive messages from server
                        ThreadPool.QueueUserWorkItem(HandleServer);
                    }
                }
                // connection refused
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
                MessageBox.Show("Invalid entry. Please try again.");

        }

        // Method:      HandleClient()
        // Description: This method keeps looping and receiving the messages from client
        //              and update the chat history with it. If message is encrypted,
        //              it displays the encrypted message first followed by decrypted 
        //              version of same message.
        public void HandleServer(object o)
        {
            string msg = "";
            string key = "#981#-";
            string encrypted = "";

            try
            {
                // establish reader to read from the stream
                StreamReader sr = new StreamReader(RunTheClient.GetStream());

                while (true)
                {
                    string SignalDecrypt = "";
                    msg = sr.ReadLine();

                    // if message is encrypted
                    if (msg.Contains(key))
                    {
                        encrypted = msg.Replace(key, string.Empty);
                        ChatHistory.Items.Add("Server: |EC| " + encrypted);

                        // decrypt the message
                        msg = b.Decrypt_CBC(encrypted);
                        SignalDecrypt = "|DC| ";
                    }

                    // add to chat history
                    ChatHistory.Items.Add("Server: " + SignalDecrypt + msg);
                    ScrollToBottom();
                }
            }
            // server left, close client connection and exit
            catch (Exception)
            {
                RunTheClient.Close();
                Application.Exit();
            }
        }

        private void ScrollToBottom()
        {
            // scroll to very last item added
            ChatHistory.SelectedIndex = ChatHistory.Items.Count - 1;
            ChatHistory.SelectedIndex = -1;
        }


        // Method:      EnterPressedOnTypeBox()
        // Parameters:  void
        // Returns:     string - ip address of current machine
        // Description: This method gets the IPv4 of current machine and returns it.       
        public static string GetLocalIPAddress()
        {
            // get hostname and IPv4 of current machine
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

        // Method:      EnterPressedOnTypeBox()
        // Description: This method checks if the pressed key is return, and if it is,
        //              SendNormal_Click method is invoked.             
        private void EnterPressedOnTypeBox(object sender, KeyEventArgs e)
        {
            // Enter is pressed instead of button being clicked to send the message
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                SendNormal_Click(sender, e);
            }
        }

        // Method:      SendEncrypted_Click()
        // Description: This method takes the message from textbox, and send it over on
        //              the established TCP stream encrypted with Bruce Scheneir's algorithm.
        private void SendEncrypted_Click(object sender, EventArgs e)
        {
            // get message from textbox to be sent
            string msg = TypeBox.Text;
            if (msg == "")
                return;

            TypeBox.Clear();
            StreamWriter sw;
            string key = "#981#-";

            // encrypt it and add the key to let the other server/client know that it is 
            // encrypyed
            string encrypted = key + b.Encrypt_CBC(msg);

            try
            {
                // establish writer to write to stream
                if (ServerItIs)
                    sw = new StreamWriter(client.GetStream());
                else
                    sw = new StreamWriter(RunTheClient.GetStream());

                sw.AutoFlush = true;

                // send encrypted message
                sw.WriteLine(encrypted);

                // add to chat history
                ChatHistory.Items.Add("Me: " + msg);
                TypeBox.Focus();
                ScrollToBottom();
            }
            catch (Exception)
            {
                MessageBox.Show("No clients have connected yet... Try again later!", "Error 643");
            }
        }

        // Method:      lst_MeasureItem()
        // Description: This method sets the item width, so if item is longer, it will be added as next
        //              item instead.
        // Reference:   https://stackoverflow.com/questions/17613613/winforms-dotnet-listbox-items-to-word-wrap-if-content-string-width-is-bigger-tha
        private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(ChatHistory.Items[e.Index].ToString(), ChatHistory.Font, ChatHistory.Width).Height;
        }


        // Method:      lst_DrawItem()
        // Description: This method parts item in multiple if their width is bigger than 
        //              listbox width
        // Reference:   https://stackoverflow.com/questions/17613613/winforms-dotnet-listbox-items-to-word-wrap-if-content-string-width-is-bigger-tha
        private void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(ChatHistory.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }

        // Method:      ConnectToServer_Return()
        // Description: This method invokes the StartClient_Click method if pressed key is Enter.
        private void ConnectToServer_Return(object sender, KeyEventArgs e)
        {
            // Return key is down, start client
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                StartClient_Click(sender, e);
            }
        }
    }
}
