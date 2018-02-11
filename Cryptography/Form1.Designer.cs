namespace Cryptography
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ServerOrClient = new System.Windows.Forms.Panel();
            this.RunClient = new System.Windows.Forms.Button();
            this.RunServer = new System.Windows.Forms.Button();
            this.StartServerPanel = new System.Windows.Forms.Panel();
            this.StartServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ServerPort = new System.Windows.Forms.RichTextBox();
            this.StartClientPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ipbox = new System.Windows.Forms.RichTextBox();
            this.StartClient = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.clientport = new System.Windows.Forms.RichTextBox();
            this.ChatPanel = new System.Windows.Forms.Panel();
            this.ConnectionInfo = new System.Windows.Forms.RichTextBox();
            this.SendEncrypted = new System.Windows.Forms.Button();
            this.TypeBox = new System.Windows.Forms.RichTextBox();
            this.SendNormal = new System.Windows.Forms.Button();
            this.ChatHistory = new System.Windows.Forms.ListBox();
            this.ServerOrClient.SuspendLayout();
            this.StartServerPanel.SuspendLayout();
            this.StartClientPanel.SuspendLayout();
            this.ChatPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServerOrClient
            // 
            this.ServerOrClient.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ServerOrClient.BackgroundImage")));
            this.ServerOrClient.Controls.Add(this.RunClient);
            this.ServerOrClient.Controls.Add(this.RunServer);
            this.ServerOrClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerOrClient.Location = new System.Drawing.Point(0, 0);
            this.ServerOrClient.Name = "ServerOrClient";
            this.ServerOrClient.Size = new System.Drawing.Size(874, 523);
            this.ServerOrClient.TabIndex = 0;
            // 
            // RunClient
            // 
            this.RunClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunClient.Image = ((System.Drawing.Image)(resources.GetObject("RunClient.Image")));
            this.RunClient.Location = new System.Drawing.Point(321, 255);
            this.RunClient.Name = "RunClient";
            this.RunClient.Size = new System.Drawing.Size(211, 62);
            this.RunClient.TabIndex = 1;
            this.RunClient.Text = "Run Client";
            this.RunClient.UseVisualStyleBackColor = true;
            this.RunClient.Click += new System.EventHandler(this.RunClient_Click);
            // 
            // RunServer
            // 
            this.RunServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunServer.Image = ((System.Drawing.Image)(resources.GetObject("RunServer.Image")));
            this.RunServer.Location = new System.Drawing.Point(321, 154);
            this.RunServer.Name = "RunServer";
            this.RunServer.Size = new System.Drawing.Size(211, 63);
            this.RunServer.TabIndex = 0;
            this.RunServer.Text = "Run Server";
            this.RunServer.UseVisualStyleBackColor = true;
            this.RunServer.Click += new System.EventHandler(this.RunServer_Click);
            // 
            // StartServerPanel
            // 
            this.StartServerPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StartServerPanel.BackgroundImage")));
            this.StartServerPanel.Controls.Add(this.StartServer);
            this.StartServerPanel.Controls.Add(this.label1);
            this.StartServerPanel.Controls.Add(this.ServerPort);
            this.StartServerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartServerPanel.Location = new System.Drawing.Point(0, 0);
            this.StartServerPanel.Name = "StartServerPanel";
            this.StartServerPanel.Size = new System.Drawing.Size(874, 523);
            this.StartServerPanel.TabIndex = 2;
            // 
            // StartServer
            // 
            this.StartServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartServer.Image = ((System.Drawing.Image)(resources.GetObject("StartServer.Image")));
            this.StartServer.Location = new System.Drawing.Point(276, 268);
            this.StartServer.Name = "StartServer";
            this.StartServer.Size = new System.Drawing.Size(276, 49);
            this.StartServer.TabIndex = 2;
            this.StartServer.Text = "Start Server";
            this.StartServer.UseVisualStyleBackColor = true;
            this.StartServer.Click += new System.EventHandler(this.StartServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(276, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // ServerPort
            // 
            this.ServerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerPort.Location = new System.Drawing.Point(407, 173);
            this.ServerPort.Name = "ServerPort";
            this.ServerPort.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.ServerPort.Size = new System.Drawing.Size(145, 42);
            this.ServerPort.TabIndex = 0;
            this.ServerPort.Text = "";
            this.ServerPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterPressedServerPort);
            // 
            // StartClientPanel
            // 
            this.StartClientPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StartClientPanel.BackgroundImage")));
            this.StartClientPanel.Controls.Add(this.label3);
            this.StartClientPanel.Controls.Add(this.ipbox);
            this.StartClientPanel.Controls.Add(this.StartClient);
            this.StartClientPanel.Controls.Add(this.label2);
            this.StartClientPanel.Controls.Add(this.clientport);
            this.StartClientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartClientPanel.Location = new System.Drawing.Point(0, 0);
            this.StartClientPanel.Name = "StartClientPanel";
            this.StartClientPanel.Size = new System.Drawing.Size(874, 523);
            this.StartClientPanel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(208, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "IP Address:";
            // 
            // ipbox
            // 
            this.ipbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipbox.Location = new System.Drawing.Point(413, 119);
            this.ipbox.Name = "ipbox";
            this.ipbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.ipbox.Size = new System.Drawing.Size(227, 29);
            this.ipbox.TabIndex = 2;
            this.ipbox.Text = "";
            // 
            // StartClient
            // 
            this.StartClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartClient.Image = ((System.Drawing.Image)(resources.GetObject("StartClient.Image")));
            this.StartClient.Location = new System.Drawing.Point(295, 281);
            this.StartClient.Name = "StartClient";
            this.StartClient.Size = new System.Drawing.Size(276, 49);
            this.StartClient.TabIndex = 4;
            this.StartClient.Text = "Connect to Server";
            this.StartClient.UseVisualStyleBackColor = true;
            this.StartClient.Click += new System.EventHandler(this.StartClient_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(208, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // clientport
            // 
            this.clientport.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientport.Location = new System.Drawing.Point(413, 186);
            this.clientport.Name = "clientport";
            this.clientport.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.clientport.Size = new System.Drawing.Size(227, 32);
            this.clientport.TabIndex = 3;
            this.clientport.Text = "";
            this.clientport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConnectToServer_Return);
            // 
            // ChatPanel
            // 
            this.ChatPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChatPanel.BackgroundImage")));
            this.ChatPanel.Controls.Add(this.ConnectionInfo);
            this.ChatPanel.Controls.Add(this.SendEncrypted);
            this.ChatPanel.Controls.Add(this.TypeBox);
            this.ChatPanel.Controls.Add(this.SendNormal);
            this.ChatPanel.Controls.Add(this.ChatHistory);
            this.ChatPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatPanel.Location = new System.Drawing.Point(0, 0);
            this.ChatPanel.Name = "ChatPanel";
            this.ChatPanel.Size = new System.Drawing.Size(874, 523);
            this.ChatPanel.TabIndex = 5;
            // 
            // ConnectionInfo
            // 
            this.ConnectionInfo.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ConnectionInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionInfo.Location = new System.Drawing.Point(3, 3);
            this.ConnectionInfo.Name = "ConnectionInfo";
            this.ConnectionInfo.ReadOnly = true;
            this.ConnectionInfo.Size = new System.Drawing.Size(698, 31);
            this.ConnectionInfo.TabIndex = 9;
            this.ConnectionInfo.Text = "";
            // 
            // SendEncrypted
            // 
            this.SendEncrypted.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendEncrypted.Image = ((System.Drawing.Image)(resources.GetObject("SendEncrypted.Image")));
            this.SendEncrypted.Location = new System.Drawing.Point(681, 404);
            this.SendEncrypted.Name = "SendEncrypted";
            this.SendEncrypted.Size = new System.Drawing.Size(190, 52);
            this.SendEncrypted.TabIndex = 8;
            this.SendEncrypted.Text = "Send Encrypted";
            this.SendEncrypted.UseVisualStyleBackColor = true;
            this.SendEncrypted.Click += new System.EventHandler(this.SendEncrypted_Click);
            // 
            // TypeBox
            // 
            this.TypeBox.AcceptsTab = true;
            this.TypeBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TypeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeBox.Location = new System.Drawing.Point(3, 395);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(672, 125);
            this.TypeBox.TabIndex = 6;
            this.TypeBox.Text = "";
            this.TypeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterPressedOnTypeBox);
            // 
            // SendNormal
            // 
            this.SendNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendNormal.Image = ((System.Drawing.Image)(resources.GetObject("SendNormal.Image")));
            this.SendNormal.Location = new System.Drawing.Point(681, 462);
            this.SendNormal.Name = "SendNormal";
            this.SendNormal.Size = new System.Drawing.Size(190, 49);
            this.SendNormal.TabIndex = 5;
            this.SendNormal.Text = "Send Normal";
            this.SendNormal.UseVisualStyleBackColor = true;
            this.SendNormal.Click += new System.EventHandler(this.SendNormal_Click);
            // 
            // ChatHistory
            // 
            this.ChatHistory.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ChatHistory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ChatHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatHistory.FormattingEnabled = true;
            this.ChatHistory.ItemHeight = 29;
            this.ChatHistory.Location = new System.Drawing.Point(3, 40);
            this.ChatHistory.Name = "ChatHistory";
            this.ChatHistory.Size = new System.Drawing.Size(868, 349);
            this.ChatHistory.TabIndex = 3;
            this.ChatHistory.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lst_DrawItem);
            this.ChatHistory.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lst_MeasureItem);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 523);
            this.Controls.Add(this.ServerOrClient);
            this.Controls.Add(this.ChatPanel);
            this.Controls.Add(this.StartClientPanel);
            this.Controls.Add(this.StartServerPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ServerOrClient.ResumeLayout(false);
            this.StartServerPanel.ResumeLayout(false);
            this.StartServerPanel.PerformLayout();
            this.StartClientPanel.ResumeLayout(false);
            this.StartClientPanel.PerformLayout();
            this.ChatPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ServerOrClient;
        private System.Windows.Forms.Button RunClient;
        private System.Windows.Forms.Button RunServer;
        private System.Windows.Forms.Panel StartServerPanel;
        private System.Windows.Forms.RichTextBox ServerPort;
        private System.Windows.Forms.Button StartServer;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel StartClientPanel;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox ipbox;
        private System.Windows.Forms.Button StartClient;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox clientport;
        private System.Windows.Forms.Panel ChatPanel;
        private System.Windows.Forms.Button SendEncrypted;
        private System.Windows.Forms.RichTextBox TypeBox;
        private System.Windows.Forms.Button SendNormal;
        private System.Windows.Forms.ListBox ChatHistory;
        private System.Windows.Forms.RichTextBox ConnectionInfo;
    }
}

