/*
using System;
using System.Linq;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using System.IO;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using System.IO;
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
        public MemberChat(string roomName, string memberName)
        {
            InitializeComponent();
            this.roomName = roomName;
            this.memberName = memberName;
            InitializeFirebase();
            LoadChatHistory();
        }

        private void InitializeFirebase()
        {
            firebaseClient = new FirebaseClient(FirebaseURL);
        }



        private async void LoadChatHistory()
        {
            try
            {
                var chatHistory = await firebaseClient.Child("RoomNames")
                                                      .Child(roomName)
                                                      .Child("messages")
                                                      .OnceAsync<MessageNode>();

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
                        Message = message,
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
           
            if (message.IsFile)
            {
                string fileMessage = $"{message.Sender} đã gửi một tệp: {message.FileName}";
                listBox1.Items.Add(fileMessage);

                // Gán sự kiện click vào tin nhắn tệp trong listbox để tải và mở tệp
                listBox1.SelectedIndexChanged += async (s, e) =>
                {
                    if (listBox1.SelectedItem != null && listBox1.SelectedItem.ToString() == fileMessage)
                    {
                        string tempFilePath = Path.Combine(Path.GetTempPath(), message.FileName);

                        // Tải file từ Firebase dưới dạng chuỗi base64 và chuyển nó lại thành mảng byte
                        byte[] fileData = Convert.FromBase64String(message.Message);
                        File.WriteAllBytes(tempFilePath, fileData);

                        // Mở file
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = tempFilePath,
                            UseShellExecute = true
                        });
                    }
                };
            }
            
            else if (!listBox1.Items.Cast<string>().Any(item => item.Contains(message.Message)))
            {
                string newMessage = $"{message.Sender}: {message.Message}";
                listBox1.Items.Add(newMessage);
            }

        }

       
        private async void sendTextButton_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text.Trim();
            if (isSavingMessage)
            {
                // Đang xử lý tin nhắn trước đó, không cho phép gửi tin nhắn mới
                return;
            }

            if (!string.IsNullOrWhiteSpace(message))
            {
                // Định nghĩa từ điển để ánh xạ biểu tượng cảm xúc thành emoji
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

                // Thay thế các ký tự biểu tượng cảm xúc bằng emoji
                foreach (var pair in emoticonToEmoji)
                {
                    message = message.Replace(pair.Key, pair.Value);
                }

                try
                {
                    isSavingMessage = true; // Bắt đầu quá trình lưu tin nhắn

                    await SaveMessageToFirebase(message);
                    DisplayMessage(new MessageNode { Message = message, Sender = memberName, Timestamp = DateTime.Now });
                    textBox1.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    isSavingMessage = false; // Kết thúc quá trình lưu tin nhắn
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

        private void MemberChat_Load(object sender, EventArgs e)
        {
            ListenForMessages();
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
                        // Đọc tệp vào một mảng byte
                        byte[] fileBytes = File.ReadAllBytes(filePath);

                        // Chuyển đổi mảng byte thành chuỗi base64
                        string base64File = Convert.ToBase64String(fileBytes);

                        // Tạo một đối tượng tin nhắn với loại tệp
                        var messageNode = new MessageNode
                        {
                            Message = base64File,
                            FileName = fileName,
                            IsFile = true,
                            Sender = memberName,
                            Timestamp = DateTime.Now
                        };

                        // Chú ý: sử dụng await ở đây
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        // Yêu cầu còn lại sử lý file



    }
    
}
*/

using System;
using System.Linq;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        public MemberChat(string roomName, string memberName)
        {
            InitializeComponent();
            this.roomName = roomName;
            this.memberName = memberName;
            InitializeFirebase();
            LoadChatHistory();
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

        private async void LoadChatHistory()
        {
            try
            {
                var chatHistory = await firebaseClient.Child("RoomNames")
                                                      .Child(roomName)
                                                      .Child("messages")
                                                      .OnceAsync<MessageNode>();

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
                        Message = message,
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
            if (message.IsFile)
            {
                string fileMessage = $"{message.Sender} đã gửi một tệp: {message.FileName}";
                listBox1.Items.Add(fileMessage);

                // Gán sự kiện click vào tin nhắn tệp trong listbox để tải và mở tệp
                listBox1.SelectedIndexChanged += async (s, e) =>
                {
                    if (listBox1.SelectedItem != null && listBox1.SelectedItem.ToString() == fileMessage)
                    {
                        string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                        string fileExtension = Path.GetExtension(message.FileName).ToLower();
                        string targetDir = (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif") ?
                            Path.Combine(projectDir, "Client", "Data", "IMG") :
                            Path.Combine(projectDir, "Client", "Data", "File");

                        string filePath = Path.Combine(targetDir, message.FileName);

                        // Tải file từ Firebase dưới dạng chuỗi base64 và chuyển nó lại thành mảng byte
                        byte[] fileData = Convert.FromBase64String(message.Message);
                        File.WriteAllBytes(filePath, fileData);

                        // Mở file
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = filePath,
                            UseShellExecute = true
                        });
                    }
                };
            }
            else if (!listBox1.Items.Cast<string>().Any(item => item.Contains(message.Message)))
            {
                string newMessage = $"{message.Sender}: {message.Message}";
                listBox1.Items.Add(newMessage);
            }
        }

        private async void sendTextButton_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text.Trim();
            if (isSavingMessage)
            {
                // Đang xử lý tin nhắn trước đó, không cho phép gửi tin nhắn mới
                return;
            }

            if (!string.IsNullOrWhiteSpace(message))
            {
                // Định nghĩa từ điển để ánh xạ biểu tượng cảm xúc thành emoji
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

                // Thay thế các ký tự biểu tượng cảm xúc bằng emoji
                foreach (var pair in emoticonToEmoji)
                {
                    message = message.Replace(pair.Key, pair.Value);
                }

                try
                {
                    isSavingMessage = true; // Bắt đầu quá trình lưu tin nhắn

                    await SaveMessageToFirebase(message);
                    DisplayMessage(new MessageNode { Message = message, Sender = memberName, Timestamp = DateTime.Now });
                    textBox1.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    isSavingMessage = false; // Kết thúc quá trình lưu tin nhắn
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

        private void MemberChat_Load(object sender, EventArgs e)
        {
            ListenForMessages();
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
                        // Đọc tệp vào một mảng byte
                        byte[] fileBytes = File.ReadAllBytes(filePath);

                        // Chuyển đổi mảng byte thành chuỗi base64
                        string base64File = Convert.ToBase64String(fileBytes);

                        // Tạo một đối tượng tin nhắn với loại tệp
                        var messageNode = new MessageNode
                        {
                            Message = base64File,
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
    }
}
