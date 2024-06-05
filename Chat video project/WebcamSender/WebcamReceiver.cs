using NAudio.Wave;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WebSocketSharp;
using NAudio.Wave;

namespace WebcamSender
{
    public partial class WebcamReceiver : Form
    {
        private WebSocket ws;
        private BufferedWaveProvider waveProvider;
        private WaveOutEvent waveOut;

        public WebcamReceiver()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            ws = new WebSocket("ws://localhost:8080/video");
            //ws = new WebSocket("ws://192.168.1.100:8080/video");
            ws.OnMessage += Ws_OnMessage;
            ws.Connect();

            waveProvider = new BufferedWaveProvider(new WaveFormat(8000, 1));
            waveOut = new WaveOutEvent();
            waveOut.Init(waveProvider);
            waveOut.Play();

        }

        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.RawData.Length > 3000)
            {
                // Giả sử rằng các khung hình video có kích thước lớn hơn 1000 byte
                using (MemoryStream ms = new MemoryStream(e.RawData))
                {

                    Bitmap bitmap = new Bitmap(ms);
                    pictureBox1.Image = bitmap;
                }
            }
            else
            {
                // Giả sử rằng các khung hình âm thanh có kích thước nhỏ hơn 1000 byte
                waveProvider.AddSamples(e.RawData, 0, e.RawData.Length);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            ws.Close();
            waveOut.Stop();
            base.OnFormClosing(e);
        }

        private void WebcamReceiver_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
