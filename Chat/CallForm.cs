using AForge.Video;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using System.Drawing.Imaging;
using AForge.Video;
using NAudio.Wave;
using WebSocketSharp;
using AForge.Video.DirectShow;


namespace X_Plore.Chat
{
    public partial class CallForm : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private WebSocket ws;
        private WaveInEvent waveIn;
        private BufferedWaveProvider waveProvider;
        private WaveOutEvent waveOut;
        public CallForm()
        {
            ws = new WebSocket("ws://localhost:8080/video");
            ws.OnMessage += Ws_OnMessage;
            ws.Connect();

            waveIn = new WaveInEvent();
            waveIn.DataAvailable += OnAudioDataAvailable;
            waveProvider = new BufferedWaveProvider(waveIn.WaveFormat);
            waveIn.StartRecording();

            waveOut = new WaveOutEvent();
            waveOut.Init(waveProvider);
            waveOut.Play();
            InitializeWebcam();
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (videoSource != null && !videoSource.IsRunning)
            {
                videoSource.Start();
            }
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }

        }
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                bitmap.Save(ms, ImageFormat.Jpeg);
                byte[] videoBuffer = ms.ToArray();
                ws.Send(videoBuffer);
            }

            // Hiển thị video của chính mình
           // pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void OnAudioDataAvailable(object sender, WaveInEventArgs e)
        {
            ws.Send(e.Buffer);
        }

        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.RawData.Length > 3000)
            {
                using (MemoryStream ms = new MemoryStream(e.RawData))
                {
                    Bitmap bitmap = new Bitmap(ms);
                    // Hiển thị video của người kia
                   // pictureBox2.Image = bitmap;
                }
            }
            else
            {
                waveProvider.AddSamples(e.RawData, 0, e.RawData.Length);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            ws.Close();
            waveIn.StopRecording();
            waveOut.Stop();
            base.OnFormClosing(e);
        }

        private void CallForm_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No video sources found");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.Start();
        }
        private void InitializeWebcam()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("Không tìm thấy webcam.");
                return;
            }

            // Lấy webcam đầu tiên trong danh sách
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);

            // Yêu cầu quyền truy cập camera
            if (!videoSource.IsRunning)
            {
                videoSource.Start();
            }
        }
    }
}
