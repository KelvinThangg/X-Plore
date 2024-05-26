using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using Client.CS; // Ensure this namespace matches the location of your Security class

namespace Client
{
    public partial class MemberChat : Form
    {
        public string UserName { get; set; }
        private const string FirebaseURL = "https://checkdatabase-1fbc9-default-rtdb.firebaseio.com/";
        private FirebaseClient firebaseClient;
        private string roomName;
        private string memberName;
        private bool isSendingMessage = false;
        private bool isSavingMessage = false;
        private string encryptionKey = null;

        public MemberChat(string roomName, string memberName)
        {
            InitializeComponent();
            this.roomName = roomName;
            this.memberName = memberName;
            InitializeFirebase();
            CreateDataDirectories();
        }

        private void InitializeFirebase()
        {
            firebaseClient = new FirebaseClient(FirebaseURL);
        }

        private void CreateDataDirectories()
        {
            string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string imgDir = Path.Combine(projectDir, "Client", "Data", "IMG");
            string fileDir = Path.Combine(projectDir, "Client", "Data", "File");

            if (!Directory.Exists(imgDir))
            {
                Directory.CreateDirectory(imgDir);
            }
            if (!Directory.Exists(fileDir))
            {
                Directory.CreateDirectory(fileDir);
            }
        }

        private async Task LoadChatHistory()
        {
            try
            {
                var chatHistory = await firebaseClient.Child("RoomNames")
                                                      .Child(roomName)
                                                      .Child("messages")
                                                      .OnceAsync<MessageNode>();

                listBox1.Items.Clear(); // Clear existing messages

                foreach (var messageNode in chatHistory)
                {
                    DisplayMessage(messageNode.Object);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử trò chuyện: " + ex.Message);
            }
        }

        public class MessageNode
        {
            public string Message { get; set; }
            public string Sender { get; set; }
            public DateTime Timestamp { get; set; }
            public bool IsFile { get; set; } = false;
            public string FileName { get; set; }
            public bool IsDisplayed { get; set; }
        }

        private async Task SaveMessageToFirebase(string message)
        {
            if (!isSendingMessage)
            {
                isSendingMessage = true;
                try
                {
                    var messageNode = new MessageNode
                    {
                        Message = encryptionKey == null ? message : Security.Encrypt(message, encryptionKey),
                        Sender = memberName,
                        Timestamp = DateTime.Now
                    };

                    await firebaseClient.Child("RoomNames")
                                        .Child(roomName)
                                        .Child("messages")
                                        .PostAsync(messageNode);

                    DisplayMessage(messageNode);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lưu tin nhắn lên Firebase: " + ex.Message);
                }
                finally
                {
                    isSendingMessage = false;
                }
            }
        }

        private void DisplayMessage(MessageNode message)
        {
            string decryptedMessage = encryptionKey == null ? message.Message : Security.Decrypt(message.Message, encryptionKey);

            if (message.IsFile)
            {
                if (!message.IsDisplayed)
                {
                    string fileMessage = $"{message.Sender} đã gửi một tệp: {message.FileName}";
                    listBox1.Items.Add(fileMessage);

                    string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                    string fileExtension = Path.GetExtension(message.FileName).ToLower();
                    string targetDir = Path.Combine(projectDir, "Client", "Data", "File");

                    if (new[] { ".jpg", ".jpeg", ".png", ".gif" }.Contains(fileExtension))
                    {
                        targetDir = Path.Combine(projectDir, "Client", "Data", "IMG");
                    }
                    else if (new[] { ".mp3", ".wav" }.Contains(fileExtension))
                    {
                        targetDir = Path.Combine(projectDir, "Client", "Data", "Sound");
                    }
                    else if (new[] { ".mp4", ".avi", ".mov" }.Contains(fileExtension))
                    {
                        targetDir = Path.Combine(projectDir, "Client", "Data", "Video");
                    }

                    string filePath = Path.Combine(targetDir, message.FileName);
                    byte[] fileData = Convert.FromBase64String(decryptedMessage);
                    File.WriteAllBytes(filePath, fileData);

                    // Đánh dấu tin nhắn đã được hiển thị
                    message.IsDisplayed = true;
                }
            }
            else
            {
                string newMessage = $"{message.Sender}: {decryptedMessage}";
                listBox1.Items.Add(newMessage);
            }
        }

        private async void sendTextButton_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text.Trim();
            if (isSavingMessage)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(message))
            {
                Dictionary<string, string> emoticonToEmoji = new Dictionary<string, string>
                {
                    { ":)", "😊" },
                    { ":D", "😃" },
                    { ":(", "😢" },
                    { ";)", "😉" },
                    { ":P", "😛" },
                    { ":O", "😮" },
                    { "XD", "😂" },
                    { ":'(", "😭" },
                    { ":|", "😐" },
                    { ":*", "😘" },
                    { "<3", "❤️" },
                    { ":@", "😡" },
                    { "B)", "😎" },
                    { "O:)", "😇" },
                    { ":S", "😖" },
                    { "8)", "😬" },
                    { "D:", "😦" },
                    { ":$", "😳" },
                    { ":/", "😕" },
                    { ">:(", "😠" },
                    { "3:)", "😈" },
                    { "o.O", "😲" },
                    { ":-X", "😷" },
                    { ":-#", "🤐" },
                    { ">:O", "😱" },
                    { ":-)", "😊" },
                    { ":-D", "😃" },
                    { ":-(", "😢" },
                    { ";-)", "😉" },
                    { ":-P", "😛" },
                    { ":-o", "😮" },
                    { "X-D", "😂" },
                    { ":'-(", "😭" },
                    { ":-|", "😐" },
                    { ":-*", "😘" },
                    { ":-@", "😡" },
                    { "B-)", "😎" },
                    { "O:-)", "😇" },
                    { ":-S", "😖" },
                    { "8-)", "😬" },
                    { ":-$", "😳" },
                    { ":-/", "😕" },
                    { "3:-)", "😈" },
                    { "O.o", "😲" }
                };

                foreach (var pair in emoticonToEmoji)
                {
                    message = message.Replace(pair.Key, pair.Value);
                }

                try
                {
                    isSavingMessage = true;
                    await SaveMessageToFirebase(message);
                    DisplayMessage(new MessageNode { Message = encryptionKey == null ? message : Security.Encrypt(message, encryptionKey), Sender = memberName, Timestamp = DateTime.Now });
                    textBox1.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    isSavingMessage = false;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tin nhắn.");
            }
        }

        private void ListenForMessages()
        {
            var observable = firebaseClient
                .Child("RoomNames")
                .Child(roomName)
                .Child("messages")
                .AsObservable<MessageNode>()
                .Subscribe(d =>
                {
                    if (d.Object != null)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            DisplayMessage(d.Object);
                        });
                    }
                });
        }

        private async void MemberChat_Load(object sender, EventArgs e)
        {
            ListenForMessages();
            await LoadChatHistory();
        }

        private async void file_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(filePath);

                    try
                    {
                        byte[] fileBytes = File.ReadAllBytes(filePath);
                        string base64File = Convert.ToBase64String(fileBytes);

                        var messageNode = new MessageNode
                        {
                            Message = encryptionKey == null ? base64File : Security.Encrypt(base64File, encryptionKey),
                            Sender = memberName,
                            Timestamp = DateTime.Now,
                            IsFile = true,
                            FileName = fileName
                        };

                        await firebaseClient.Child("RoomNames")
                                            .Child(roomName)
                                            .Child("messages")
                                            .PostAsync(messageNode);

                        DisplayMessage(messageNode);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi gửi tệp: " + ex.Message);
                    }
                }
            }
        }

        private async void keyInput_Click(object sender, EventArgs e)
        {
            encryptionKey = keytextBox.Text.Trim();
            if (string.IsNullOrEmpty(encryptionKey))
            {
                MessageBox.Show("Vui lòng nhập khóa.");
            }
            else
            {
                MessageBox.Show("Khóa đã được cập nhật.");
                await LoadChatHistory();
            }
        }
    }
}
