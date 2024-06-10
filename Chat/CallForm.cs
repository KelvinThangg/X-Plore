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
using WebSocketSharp;
using AForge.Video.DirectShow;
using Lidgren.Network;
using System.Net;
using CrapChat;
using NAudio.Wave.SampleProviders;
using System.Threading;
using WebSocketSharp.Server;

namespace X_Plore.Chat
{
   
    public partial class CallForm : Form
    {
        public CallForm()
        {
            InitializeComponent();
            Initialize();    
        }
   
        private Button buttonStart;
        private Button buttonStop;
        private WebSocketServer wssv;
        private WaveInEvent waveIn;
        private WaveOutEvent waveOut;
        private WebSocket ws;
        private bool serverStarted = false; // Flag to track server status
        private void Initialize()
        {
            
            StartButton.Click += new EventHandler(StartConnection);

         
            LeaveButton.Click += new EventHandler(StopConnection);
            LeaveButton.Enabled = false;

            // Add the controls to the form
            Controls.Add(StartButton);
            Controls.Add(LeaveButton);

            // Set the size and title of the form
            ClientSize = new Size(400, 200);
            Text = "WebSocket Voice Chat";
        }

        private void StartConnection(object sender, EventArgs e)
        {
            if (!serverStarted) // Only start the server if it's not already running
            {
                try
                {
                    wssv = new WebSocketServer("ws://localhost:14235");
                    wssv.AddWebSocketService<VideoBehavior>("/video");
                    wssv.Start();
                    Console.WriteLine("WebSocket server started at ws://localhost:14235");
                    serverStarted = true;
                }
                catch (Exception ex)
                {
                    // Handle exceptions gracefully, e.g., show an error message to the user
                    MessageBox.Show("Error starting server: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the method if the server couldn't start
                }
            }

            // Start recording and connect client even if server was already running
            StartRecordingAndConnectClient();
        }

        private void StartRecordingAndConnectClient()
        {
            // Start recording audio
            waveIn = new WaveInEvent();
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new WaveFormat(44100, 16, 1);
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(WaveInDataAvailable);
            waveIn.StartRecording();

            // Connect to the server
            ws = new WebSocket("ws://localhost:14235/video");
            ws.OnMessage += new EventHandler<MessageEventArgs>(WsOnMessage);
            ws.Connect();

            StartButton.Enabled = false;
            LeaveButton.Enabled = true;
        }


        private void StopConnection(object sender, EventArgs e)
        {
            // Stop recording audio
            if (waveIn != null)
            {
                waveIn.StopRecording();
                waveIn.Dispose();
                waveIn = null;
            }

            // Disconnect from the server
            if (ws != null)
            {
                ws.Close();
                ws = null;
            }

            // Only stop the server if it was started by this instance
            if (serverStarted && wssv != null)
            {
                wssv.Stop();
                wssv = null;
                serverStarted = false;
            }

            StartButton.Enabled = true;
            LeaveButton.Enabled = false;
        }

        private void WaveInDataAvailable(object sender, WaveInEventArgs e)
        {
            if (ws != null && ws.IsAlive)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(e.Buffer, 0, e.BytesRecorded);
                    byte[] audioData = ms.ToArray();
                    ws.Send(audioData);
                }
            }
        }

        private void WsOnMessage(object sender, MessageEventArgs e)
        {
            if (waveOut == null)
            {
                waveOut = new WaveOutEvent();
                waveOut.Init(new RawSourceWaveStream(e.RawData, 0, e.RawData.Length, waveIn.WaveFormat));
            }
            waveOut.Play();
        }
    }

    public class VideoBehavior : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Sessions.Broadcast(e.RawData);
        }
    }
}