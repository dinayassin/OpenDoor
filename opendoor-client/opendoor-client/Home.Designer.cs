namespace ArduinoBoardTest
{
    partial class HomeForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CBPort = new System.Windows.Forms.ComboBox();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.GB_Control = new System.Windows.Forms.GroupBox();
            this.videoViewer = new Ozeki.Media.VideoViewerWF();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnImageCaptureAndSaveImage = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.Btn_AllLedOFF = new System.Windows.Forms.Button();
            this.BtnTone = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btn_RedLedON = new System.Windows.Forms.Button();
            this.BtnTimeWait = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.Btn_GreenLedON = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Btn_BlueLedON = new System.Windows.Forms.Button();
            this.TxtSendToPort = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnSend = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtLog = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCardID = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PortsRefresh = new System.Windows.Forms.PictureBox();
            this.BGW_CheckConnection = new System.ComponentModel.BackgroundWorker();
            this.lbl_ArduinoConnectedState = new System.Windows.Forms.Label();
            this.lbl_WebCamConnectedState = new System.Windows.Forms.Label();
            this.GB_Control.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortsRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, -62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(0, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(742, 49);
            this.label5.TabIndex = 15;
            this.label5.Text = "OpenDoor-Client";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CBPort
            // 
            this.CBPort.Font = new System.Drawing.Font("Arial", 15.75F);
            this.CBPort.FormattingEnabled = true;
            this.CBPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15"});
            this.CBPort.Location = new System.Drawing.Point(159, 109);
            this.CBPort.Name = "CBPort";
            this.CBPort.Size = new System.Drawing.Size(235, 32);
            this.CBPort.TabIndex = 0;
            this.CBPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CBPort_KeyDown);
            // 
            // BtnConnect
            // 
            this.BtnConnect.Font = new System.Drawing.Font("Arial", 15.75F);
            this.BtnConnect.ForeColor = System.Drawing.Color.Green;
            this.BtnConnect.Location = new System.Drawing.Point(455, 108);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(151, 32);
            this.BtnConnect.TabIndex = 1;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 15.75F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(83, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 24);
            this.label7.TabIndex = 19;
            this.label7.Text = "Port:";
            // 
            // GB_Control
            // 
            this.GB_Control.Controls.Add(this.videoViewer);
            this.GB_Control.Controls.Add(this.groupBox4);
            this.GB_Control.Controls.Add(this.button1);
            this.GB_Control.Controls.Add(this.label6);
            this.GB_Control.Controls.Add(this.TxtLog);
            this.GB_Control.Controls.Add(this.label3);
            this.GB_Control.Controls.Add(this.TxtCardID);
            this.GB_Control.Font = new System.Drawing.Font("Arial", 15.75F);
            this.GB_Control.ForeColor = System.Drawing.Color.White;
            this.GB_Control.Location = new System.Drawing.Point(6, 133);
            this.GB_Control.Name = "GB_Control";
            this.GB_Control.Size = new System.Drawing.Size(736, 533);
            this.GB_Control.TabIndex = 20;
            this.GB_Control.TabStop = false;
            // 
            // videoViewer
            // 
            this.videoViewer.BackColor = System.Drawing.Color.Black;
            this.videoViewer.ContextMenuEnabled = true;
            this.videoViewer.FlipMode = Ozeki.Media.FlipMode.None;
            this.videoViewer.FrameStretch = Ozeki.Media.FrameStretch.Uniform;
            this.videoViewer.FullScreenEnabled = true;
            this.videoViewer.Location = new System.Drawing.Point(6, 250);
            this.videoViewer.Name = "videoViewer";
            this.videoViewer.RotateAngle = 0;
            this.videoViewer.Size = new System.Drawing.Size(325, 259);
            this.videoViewer.TabIndex = 31;
            this.videoViewer.Text = "_videoViewer";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox4.Controls.Add(this.btnImageCaptureAndSaveImage);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.BtnTone);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.BtnTimeWait);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.TxtSendToPort);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.BtnSend);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 15.75F);
            this.groupBox4.ForeColor = System.Drawing.Color.Green;
            this.groupBox4.Location = new System.Drawing.Point(337, 184);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(391, 325);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Test";
            // 
            // btnImageCaptureAndSaveImage
            // 
            this.btnImageCaptureAndSaveImage.Font = new System.Drawing.Font("Arial", 15.75F);
            this.btnImageCaptureAndSaveImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnImageCaptureAndSaveImage.Location = new System.Drawing.Point(15, 277);
            this.btnImageCaptureAndSaveImage.Name = "btnImageCaptureAndSaveImage";
            this.btnImageCaptureAndSaveImage.Size = new System.Drawing.Size(362, 33);
            this.btnImageCaptureAndSaveImage.TabIndex = 30;
            this.btnImageCaptureAndSaveImage.Text = "image capture and save";
            this.btnImageCaptureAndSaveImage.UseVisualStyleBackColor = true;
            this.btnImageCaptureAndSaveImage.Click += new System.EventHandler(this.btnImageCaptureAndSaveImage_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.Btn_AllLedOFF);
            this.groupBox7.ForeColor = System.Drawing.Color.Wheat;
            this.groupBox7.Location = new System.Drawing.Point(291, 18);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(86, 81);
            this.groupBox7.TabIndex = 28;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "All";
            // 
            // Btn_AllLedOFF
            // 
            this.Btn_AllLedOFF.ForeColor = System.Drawing.Color.Green;
            this.Btn_AllLedOFF.Location = new System.Drawing.Point(7, 28);
            this.Btn_AllLedOFF.Name = "Btn_AllLedOFF";
            this.Btn_AllLedOFF.Size = new System.Drawing.Size(72, 40);
            this.Btn_AllLedOFF.TabIndex = 0;
            this.Btn_AllLedOFF.Text = "Off";
            this.Btn_AllLedOFF.UseVisualStyleBackColor = true;
            this.Btn_AllLedOFF.Click += new System.EventHandler(this.Btn_AllLedOFF_Click);
            // 
            // BtnTone
            // 
            this.BtnTone.Font = new System.Drawing.Font("Arial", 15.75F);
            this.BtnTone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnTone.Location = new System.Drawing.Point(204, 110);
            this.BtnTone.Name = "BtnTone";
            this.BtnTone.Size = new System.Drawing.Size(173, 35);
            this.BtnTone.TabIndex = 29;
            this.BtnTone.Text = "tone (50 msec)";
            this.BtnTone.UseVisualStyleBackColor = true;
            this.BtnTone.Click += new System.EventHandler(this.BtnTone_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Btn_RedLedON);
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(15, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(86, 81);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Red";
            // 
            // Btn_RedLedON
            // 
            this.Btn_RedLedON.ForeColor = System.Drawing.Color.Green;
            this.Btn_RedLedON.Location = new System.Drawing.Point(7, 28);
            this.Btn_RedLedON.Name = "Btn_RedLedON";
            this.Btn_RedLedON.Size = new System.Drawing.Size(72, 40);
            this.Btn_RedLedON.TabIndex = 0;
            this.Btn_RedLedON.Text = "On";
            this.Btn_RedLedON.UseVisualStyleBackColor = true;
            this.Btn_RedLedON.Click += new System.EventHandler(this.Btn_RedLedON_Click);
            // 
            // BtnTimeWait
            // 
            this.BtnTimeWait.Font = new System.Drawing.Font("Arial", 15.75F);
            this.BtnTimeWait.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnTimeWait.Location = new System.Drawing.Point(15, 111);
            this.BtnTimeWait.Name = "BtnTimeWait";
            this.BtnTimeWait.Size = new System.Drawing.Size(178, 35);
            this.BtnTimeWait.TabIndex = 28;
            this.BtnTimeWait.Text = "Time wait Function (3 sec)";
            this.BtnTimeWait.UseVisualStyleBackColor = true;
            this.BtnTimeWait.Click += new System.EventHandler(this.BtnTimeWait_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.Btn_GreenLedON);
            this.groupBox6.ForeColor = System.Drawing.Color.GreenYellow;
            this.groupBox6.Location = new System.Drawing.Point(199, 18);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(86, 81);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Green";
            // 
            // Btn_GreenLedON
            // 
            this.Btn_GreenLedON.ForeColor = System.Drawing.Color.Green;
            this.Btn_GreenLedON.Location = new System.Drawing.Point(7, 28);
            this.Btn_GreenLedON.Name = "Btn_GreenLedON";
            this.Btn_GreenLedON.Size = new System.Drawing.Size(72, 40);
            this.Btn_GreenLedON.TabIndex = 0;
            this.Btn_GreenLedON.Text = "On";
            this.Btn_GreenLedON.UseVisualStyleBackColor = true;
            this.Btn_GreenLedON.Click += new System.EventHandler(this.Btn_GreenLedON_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Btn_BlueLedON);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(107, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(86, 81);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Blue";
            // 
            // Btn_BlueLedON
            // 
            this.Btn_BlueLedON.ForeColor = System.Drawing.Color.Green;
            this.Btn_BlueLedON.Location = new System.Drawing.Point(7, 28);
            this.Btn_BlueLedON.Name = "Btn_BlueLedON";
            this.Btn_BlueLedON.Size = new System.Drawing.Size(72, 40);
            this.Btn_BlueLedON.TabIndex = 0;
            this.Btn_BlueLedON.Text = "On";
            this.Btn_BlueLedON.UseVisualStyleBackColor = true;
            this.Btn_BlueLedON.Click += new System.EventHandler(this.Btn_BlueLedON_Click);
            // 
            // TxtSendToPort
            // 
            this.TxtSendToPort.Font = new System.Drawing.Font("Arial", 15.75F);
            this.TxtSendToPort.Location = new System.Drawing.Point(15, 176);
            this.TxtSendToPort.Name = "TxtSendToPort";
            this.TxtSendToPort.Size = new System.Drawing.Size(283, 83);
            this.TxtSendToPort.TabIndex = 22;
            this.TxtSendToPort.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15.75F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(17, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 24);
            this.label4.TabIndex = 25;
            this.label4.Text = "Sent data to arduino:";
            // 
            // BtnSend
            // 
            this.BtnSend.Font = new System.Drawing.Font("Arial", 15.75F);
            this.BtnSend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnSend.Location = new System.Drawing.Point(305, 176);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(72, 83);
            this.BtnSend.TabIndex = 24;
            this.BtnSend.Text = "Send";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button1.Location = new System.Drawing.Point(656, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 28);
            this.button1.TabIndex = 27;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 15.75F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(16, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 24);
            this.label6.TabIndex = 26;
            this.label6.Text = "Arduino log:";
            // 
            // TxtLog
            // 
            this.TxtLog.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtLog.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.TxtLog.Location = new System.Drawing.Point(16, 47);
            this.TxtLog.Name = "TxtLog";
            this.TxtLog.ReadOnly = true;
            this.TxtLog.Size = new System.Drawing.Size(712, 130);
            this.TxtLog.TabIndex = 23;
            this.TxtLog.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(9, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 24);
            this.label3.TabIndex = 20;
            this.label3.Text = "Card ID:";
            // 
            // TxtCardID
            // 
            this.TxtCardID.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TxtCardID.Location = new System.Drawing.Point(6, 212);
            this.TxtCardID.Name = "TxtCardID";
            this.TxtCardID.ReadOnly = true;
            this.TxtCardID.Size = new System.Drawing.Size(325, 32);
            this.TxtCardID.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ArduinoBoardTest.Properties.Resources.test_3_;
            this.pictureBox1.Location = new System.Drawing.Point(635, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "רענון פורטים");
            // 
            // PortsRefresh
            // 
            this.PortsRefresh.Image = global::ArduinoBoardTest.Properties.Resources.blue_refresh_button_icon_65919;
            this.PortsRefresh.Location = new System.Drawing.Point(400, 102);
            this.PortsRefresh.Name = "PortsRefresh";
            this.PortsRefresh.Size = new System.Drawing.Size(49, 39);
            this.PortsRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PortsRefresh.TabIndex = 21;
            this.PortsRefresh.TabStop = false;
            this.toolTip1.SetToolTip(this.PortsRefresh, "רענון פורטים");
            this.PortsRefresh.Click += new System.EventHandler(this.PortsRefresh_Click);
            // 
            // BGW_CheckConnection
            // 
            this.BGW_CheckConnection.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_CheckConnection_DoWork);
            // 
            // lbl_ArduinoConnectedState
            // 
            this.lbl_ArduinoConnectedState.AutoSize = true;
            this.lbl_ArduinoConnectedState.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_ArduinoConnectedState.ForeColor = System.Drawing.Color.Red;
            this.lbl_ArduinoConnectedState.Location = new System.Drawing.Point(7, 47);
            this.lbl_ArduinoConnectedState.Name = "lbl_ArduinoConnectedState";
            this.lbl_ArduinoConnectedState.Size = new System.Drawing.Size(360, 27);
            this.lbl_ArduinoConnectedState.TabIndex = 23;
            this.lbl_ArduinoConnectedState.Text = "Arduino Board is: Not connected";
            this.lbl_ArduinoConnectedState.Visible = false;
            // 
            // lbl_WebCamConnectedState
            // 
            this.lbl_WebCamConnectedState.AutoSize = true;
            this.lbl_WebCamConnectedState.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_WebCamConnectedState.ForeColor = System.Drawing.Color.Red;
            this.lbl_WebCamConnectedState.Location = new System.Drawing.Point(7, 74);
            this.lbl_WebCamConnectedState.Name = "lbl_WebCamConnectedState";
            this.lbl_WebCamConnectedState.Size = new System.Drawing.Size(306, 27);
            this.lbl_WebCamConnectedState.TabIndex = 24;
            this.lbl_WebCamConnectedState.Text = "WebCam is: Not connected";
            this.lbl_WebCamConnectedState.Visible = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(746, 678);
            this.Controls.Add(this.lbl_WebCamConnectedState);
            this.Controls.Add(this.lbl_ArduinoConnectedState);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PortsRefresh);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.CBPort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GB_Control);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenDoor-Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HomeForm_FormClosed);
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.GB_Control.ResumeLayout(false);
            this.GB_Control.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortsRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBPort;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox GB_Control;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.RichTextBox TxtLog;
        private System.Windows.Forms.RichTextBox TxtSendToPort;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Btn_BlueLedON;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btn_RedLedON;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCardID;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button Btn_GreenLedON;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button Btn_AllLedOFF;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox PortsRefresh;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button BtnTone;
        private System.Windows.Forms.Button BtnTimeWait;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private Ozeki.Media.VideoViewerWF videoViewer;
        private System.ComponentModel.BackgroundWorker BGW_CheckConnection;
        private System.Windows.Forms.Label lbl_ArduinoConnectedState;
        private System.Windows.Forms.Label lbl_WebCamConnectedState;
        private System.Windows.Forms.Button btnImageCaptureAndSaveImage;
    }
}

