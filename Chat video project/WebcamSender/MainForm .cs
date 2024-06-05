using AForge.Video;
using AForge.Video.DirectShow;
using NAudio.Wave;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using WebSocketSharp;
using NAudio.Wave;

namespace WebcamSender
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private WebSocket ws;
        private WaveInEvent waveIn;
        private BufferedWaveProvider waveProvider;
        private WaveOutEvent waveOut;

        public Form1()
        {
            InitializeComponent();
            ws = new WebSocket("ws://localhost:8080/video");
            ws.Connect();

            waveIn = new WaveInEvent();
            waveIn.DataAvailable += OnAudioDataAvailable;
            waveProvider = new BufferedWaveProvider(waveIn.WaveFormat);
            waveIn.StartRecording();

            waveOut = new WaveOutEvent();
            waveOut.Init(waveProvider);
            waveOut.Play();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (videoSource != null && !videoSource.IsRunning)
            {
                videoSource.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
                byte[] buffer = ms.ToArray();
                ws.Send(buffer);
            }

            // Hiển thị video của chính mình
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No video sources found");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            ws.Close();
            base.OnFormClosing(e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
        
            WebcamReceiver webcamReceiver = new WebcamReceiver();
            webcamReceiver.ShowDialog();
           
        }

        private void OnAudioDataAvailable(object sender, WaveInEventArgs e)
        {
            ws.Send(e.Buffer);
        }
    }
}
