using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using Ozeki.Media;
using Ozeki.Camera;
using System.Media;
using System.Management;
using System.Net.Http;
using System.Net.Http.Headers;
using OpenDoorAPI.Contracts;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using System.Configuration;

namespace ArduinoBoardTest
{

    public partial class HomeForm : Form
    {
        //API
        string API_BASE_URL = Properties.Settings.Default.API_BASE_URL; //"http://localhost:54999/";

        //camera
        private IWebCamera globalWebCamera;
        private DrawingImageProvider globalImageProvider;
        private MediaConnector globalMediaConnector;
        private SnapshotHandler globalSnapshotHandler;

        bool timeWaitIsDone = true;
        public enum ledState
        {
            IdentificationFail,
            IdentificationSuccess,
            ServerFailConnection,
            Ready
        }
        //arduino
        const int FormHeightWithGBControl = 721;
        const int FormHeightWithoutGBControl = 187;
        const string CardIDStringBegin = "UID tag: ";
        public HomeForm()
        {
            InitializeComponent();

            //camera
            globalImageProvider = new DrawingImageProvider();
            globalMediaConnector = new MediaConnector();
            globalSnapshotHandler = new SnapshotHandler();
            connectUsbCamera();
        }

        private void connectUsbCamera()
        {
            globalWebCamera = new WebCamera();

            if (globalWebCamera != null)
            {
                globalMediaConnector.Connect(globalWebCamera.VideoChannel, globalImageProvider);
                globalMediaConnector.Connect(globalWebCamera.VideoChannel, globalSnapshotHandler);
                videoViewer.SetImageProvider(globalImageProvider);
                globalWebCamera.Start();
                videoViewer.Start();


            }
        }


        public void LedSet(ledState state)
        {
            try
            {
                switch (state)
                {
                    case ledState.IdentificationFail:
                        Btn_RedLedON_Click(new object(), new EventArgs());
                        break;
                    case ledState.IdentificationSuccess:
                        Btn_GreenLedON_Click(new object(), new EventArgs());
                        break;
                    case ledState.ServerFailConnection:
                        for (int i = 0; i < 3; i++)
                        {
                            Btn_RedLedON_Click(new object(), new EventArgs());
                            Thread.Sleep(500);
                            Btn_AllLedOFF_Click(new object(), new EventArgs());
                            Thread.Sleep(500);
                        }
                        break;
                }
                if (state != ledState.Ready)
                    Thread.Sleep(5000);
                Btn_BlueLedON_Click(new object(), new EventArgs());
            }
            catch (Exception)
            { }

        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

            this.Height = FormHeightWithoutGBControl;
            RePosition();

            PortsRefresh_Click(sender, e);


        }




        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Btn_AllLedOFF_Click(new object(), new EventArgs());
            serialPort1.Close();
        }



        private async void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string RfcNumber = string.Empty;
            if (CheckConnect())
            {

                try
                {
                    string line = serialPort1.ReadLine();
                    TxtLog.Invoke(new MethodInvoker(delegate
                    {
                        TxtLog.Text += DateTime.Now + ": " + line + "\n";
                        TxtLog.SelectionStart = TxtLog.Text.Length;
                        TxtLog.ScrollToCaret();
                    }));

                    if (line == "timeWait is Done\r")
                    {
                        timeWaitIsDone = true;
                    }
                    else
                    if (line.Substring(0, CardIDStringBegin.Length) == CardIDStringBegin)
                    {
                        RfcNumber = line.Substring(CardIDStringBegin.Length, line.Length - CardIDStringBegin.Length);
                        TxtCardID.Invoke(new MethodInvoker(delegate
                        {
                            TxtCardID.Text = RfcNumber;
                        }));


                        await PostNfcCard(RfcNumber);
                    }
                }
                catch (Exception ex)
                { }

            }
        }


        private async Task PostNfcCard(string RFCNumber, string img = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(API_BASE_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                VisitorIdentificationRequestDTO Req;
                if (img == null)
                    Req = new VisitorIdentificationRequestDTO() { RFCData = RFCNumber.Replace("\r", "") };
                else
                    Req = new VisitorIdentificationRequestDTO() { RFCData = RFCNumber.Replace("\r", ""), Picture = img };

                HttpResponseMessage response = await client.PostAsJsonAsync("api/VisitorIdentification/", Req);
                if (response.IsSuccessStatusCode)
                {
                    VisitorIdentificationResultDTO res = await response.Content.ReadAsAsync<VisitorIdentificationResultDTO>();
                    switch (res.Result)
                    {
                        case VisitorIdentificationResults.OpenDoor:
                            LedSet(ledState.IdentificationSuccess);
                            break;
                        case VisitorIdentificationResults.FaildIdentification:
                            LedSet(ledState.IdentificationFail);
                            break;
                        case VisitorIdentificationResults.RetakeImage:
                            timeWaitIsDone = false;
                            BtnTimeWait_Click(new object(), new EventArgs());
                            while (!timeWaitIsDone) ;
                            await PostNfcCard(RFCNumber, GetImg());
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show(response.ToString());
                    LedSet(ledState.ServerFailConnection);
                }
            }
        }


        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (BtnConnect.Text == "Connect")
            {
                try
                {
                    serialPort1.PortName = CBPort.Text;
                    serialPort1.Open();
                    BtnConnect.Text = "Disconnect";
                    BtnConnect.ForeColor = Color.Red;
                    CBPort.Enabled = false;
                    PortsRefresh.Enabled = false;
                    TxtLog.Text = "";
                    TxtSendToPort.Text = "";
                    this.Height = FormHeightWithGBControl;
                    RePosition();
                    BGW_CheckConnection.RunWorkerAsync();
                    LedSet(ledState.Ready);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    serialPort1.Close();
                    BtnConnect.Text = "Connect";
                    BtnConnect.ForeColor = Color.Green;
                    CBPort.Enabled = true;
                    PortsRefresh.Enabled = true;
                    this.Height = FormHeightWithoutGBControl;
                    RePosition();
                    CBPort.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        void RePosition()
        {
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {


            BtnSend.Enabled = false;
            string[] Lines = TxtSendToPort.Text.Split('\n');
            foreach (string line in Lines)
            {
                serialWrite(line);

                Thread.Sleep(500);
            }
            BtnSend.Enabled = true;

        }

        private void Btn_RedLedON_Click(object sender, EventArgs e)
        {
            serialWrite("RedLed_ON");
        }


        private void Btn_BlueLedON_Click(object sender, EventArgs e)
        {
            serialWrite("BlueLed_ON");
        }


        private void Btn_GreenLedON_Click(object sender, EventArgs e)
        {
            serialWrite("GreenLed_ON");
        }


        private void CBPort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().ToLower() == "return")
            {
                BtnConnect_Click(sender, new EventArgs());
            }
        }

        private void Btn_AllLedOFF_Click(object sender, EventArgs e)
        {
            serialWrite("AllLed_OFF");
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            TxtLog.Text = "";
        }

        private void PortsRefresh_Click(object sender, EventArgs e)
        {
            PortsRefresh.Enabled = false;
            CBPort.Enabled = false;
            //get ports
            List<String> tList = new List<String>();

            CBPort.Items.Clear();

            foreach (string s in SerialPort.GetPortNames())
            {
                tList.Add(s);
            }

            tList.Sort();
            CBPort.Items.AddRange(tList.ToArray());
            CBPort.Enabled = true;
            PortsRefresh.Enabled = true;
        }
        void serialWrite(string str)
        {
            if (CheckConnect())
            {
                serialPort1.Write(str);
            }
        }
        private bool CheckConnect()
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.PortName = CBPort.Text;
                    serialPort1.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            return true;
        }

        private void BtnTimeWait_Click(object sender, EventArgs e)
        {
            serialWrite("TimeWait_3");
        }

        private void BtnTone_Click(object sender, EventArgs e)
        {
            serialWrite("Speaker_50");
        }

        private string GetImg()
        {
            Image snapShotImage = CameraShot();
            //return ImageConvert.imageToByteArray(snapShotImage);
            return ImageConvert.ImageToBase64(snapShotImage, System.Drawing.Imaging.ImageFormat.Jpeg);
        }



        delegate void setLbl_CallBack(Label _lbl, string _text, Color _ForeColor);
        public void setLbl(Label _lbl, string _text, Color _ForeColor)
        {
            /* value return
            * return = 1   >>  Yes Or OK
            * return = 0   >>  No
            * return = -1  >>  Exit Form (Cancel)
            * return = -2  >>  Close process Without Result
            */
            if (this.InvokeRequired)
            {
                try
                {
                    setLbl_CallBack temp = new setLbl_CallBack(setLbl);
                    this.Invoke(temp, new object[] { _lbl, _text, _ForeColor });
                }
                catch (Exception)
                { }
            }
            else
            {
                try
                {
                    _lbl.Visible = true;
                    _lbl.ForeColor = _ForeColor;
                    _lbl.Text = _text;
                }
                catch (Exception)
                { }
            }
        }

        private void BGW_CheckConnection_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                lbl_WebCamConnectedState.Visible = true;
                lbl_ArduinoConnectedState.Visible = true;
            });
            while (true)
            {
                try
                {
                    if (!serialPort1.IsOpen)
                    {
                        serialPort1.Open();
                    }
                    setLbl(lbl_ArduinoConnectedState, "Arduino Board is: connected.", Color.Green);
                }
                catch (Exception)
                {
                    setLbl(lbl_ArduinoConnectedState, "Arduino Board is: Not connected.", Color.Red);
                }
                try
                {
                    if (globalWebCamera.State != Ozeki.Camera.CameraState.Streaming)
                    {
                        globalWebCamera.Stop();
                        videoViewer.Stop();
                        globalMediaConnector.Connect(globalWebCamera.VideoChannel, globalImageProvider);
                        globalMediaConnector.Connect(globalWebCamera.VideoChannel, globalSnapshotHandler);
                        videoViewer.SetImageProvider(globalImageProvider);
                        globalWebCamera.Start();
                        videoViewer.Start();
                    }
                    setLbl(lbl_WebCamConnectedState, "WebCam is: connected.", Color.Green);
                }
                catch (Exception)
                {
                    setLbl(lbl_WebCamConnectedState, "WebCam is: Not connected.", Color.Red);
                }
            }


        }


        private Image CameraShot()
        {
            SoundPlay(Environment.CurrentDirectory + "\\Media\\CAMERA.WAV");
            return globalSnapshotHandler.TakeSnapshot().ToImage();
        }

        private static void SoundPlay(string File)
        {
            try
            {
                System.Media.SoundPlayer Sound = new SoundPlayer(File);
                Sound.Play();
            }
            catch (Exception)
            { }

        }

        private void btnImageCaptureAndSaveImage_Click(object sender, EventArgs e)
        {
            Image snapShotImage = CameraShot();
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "img.jpg";
            savefile.Filter = "jpeg files (*.jpg)|*.jpg";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                snapShotImage.Save(savefile.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                Process.Start(savefile.FileName);
            }

        }
    }
}
