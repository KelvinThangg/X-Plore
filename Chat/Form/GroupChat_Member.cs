using loginIndian.Classes;
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
using X_Plore.Chat.CS;
using Firebase.Database;
using Firebase.Database.Query;

namespace X_Plore.Chat
{
    public partial class GroupChat_Member : Form
    {
        public string UserName { get; set; }
        private const string FirebaseURL = "https://checkdatabase-1fbc9-default-rtdb.firebaseio.com/";
        private FirebaseClient firebaseClient;
        private string roomName;
        private string memberName;
        private bool isSendingMessage = false;
        private bool isSavingMessage = false;
        private string encryptionKey = null;
        private HashSet<string> displayedMessages = new HashSet<string>();
        public GroupChat_Member(string roomName, string memberName)
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
            string imgDir = Path.Combine(projectDir, "X-Plore", "Chat", "Data", "IMG");
            string fileDir = Path.Combine(projectDir,"X-Plore", "Chat", "Data", "File");

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
                displayedMessages.Clear(); // Clear the set of displayed messages

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



        private async Task SaveMessageToFirebase(string message)
        {
            if (!isSendingMessage)
            {
                isSendingMessage = true;
                try
                {
                    var messageNode = new MessageNode
                    {
                        Message = encryptionKey == null ? message : SecurityChat.EncryptChat(message, encryptionKey),
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
            // Sử dụng encryptionKey nếu có và nếu tin nhắn không phải là file
            string decryptedMessage = message.IsFile ? message.Message : (encryptionKey == null ? message.Message : SecurityChat.DecryptChat(message.Message, encryptionKey));

            // Tạo mã nhận diện duy nhất cho tin nhắn
            string uniqueMessageIdentifier = message.IsFile ? $"{message.Sender}-{message.FileName}-{message.Timestamp}" : $"{message.Sender}-{decryptedMessage}-{message.Timestamp}";

            // Kiểm tra xem tin nhắn đã được hiển thị hay chưa
            if (!displayedMessages.Contains(uniqueMessageIdentifier))
            {
                if (message.IsFile)
                {
                    string fileMessage = $"{message.Sender} đã gửi một tệp: {message.FileName}";
                    listBox1.Items.Add(fileMessage);
                    displayedMessages.Add(uniqueMessageIdentifier);

                    // Lưu tệp vào thư mục tạm thời khi tin nhắn được hiển thị lần đầu
                    string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                    string fileExtension = Path.GetExtension(message.FileName).ToLower();
                    string targetDir = (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif") ?
                        Path.Combine(projectDir,"X-Plore", "Chat", "Data", "IMG") :
                        Path.Combine(projectDir,"X-Plore", "Chat", "Data", "File");

                    string filePath = Path.Combine(targetDir, message.FileName);

                    // Giải mã nội dung tệp nếu cần
                    byte[] fileBytes;
                    if (encryptionKey != null)
                    {
                        // Giải mã nội dung tệp nếu có encryptionKey
                        string decryptedBase64File = SecurityChat.DecryptChat(message.Message, encryptionKey);
                        fileBytes = Convert.FromBase64String(decryptedBase64File);
                    }
                    else
                    {
                        // Không cần giải mã, chỉ cần chuyển đổi từ base64 sang byte
                        fileBytes = Convert.FromBase64String(message.Message);
                    }
                    File.WriteAllBytes(filePath, fileBytes);

                    listBox1.MouseClick += (s, e) =>
                    {
                        if (listBox1.SelectedItem != null && listBox1.SelectedItem.ToString() == fileMessage)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });
                        }
                    };
                }
                else
                {
                    string newMessage = $"{message.Sender}: {decryptedMessage}";
                    listBox1.Items.Add(newMessage);
                    displayedMessages.Add(uniqueMessageIdentifier);
                }
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

        private void ShowIconSuggestionPopup()
        {
            Form iconSuggestionForm = new Form();
            iconSuggestionForm.FormBorderStyle = FormBorderStyle.None; // Remove border
            iconSuggestionForm.StartPosition = FormStartPosition.Manual;
            iconSuggestionForm.BackColor = Color.LightGreen; // Set background color
            iconSuggestionForm.TransparencyKey = Color.LightGreen; // Make the background color transparent
            iconSuggestionForm.Location = new Point(this.Location.X + iconButton.Location.X,
                                                    this.Location.Y + iconButton.Location.Y + iconButton.Height + 40);
            iconSuggestionForm.Width = 550; // Increase width to fit 5 icons per row
            iconSuggestionForm.Height = 300;

            List<string> iconSuggestions = new List<string> { "❤️", "😎", "👍", "😁", "😢", "😊", "😀", "👌", "😍", "😌",
                                                       "🥰", "😇", "😅", "😂", "🤩", "📚", "🎓", "🖊️", "📝", "🧠" };

            int xPos = 10;
            int yPos = 10;
            int iconsPerRow = 10;
            int iconSpacing = 5;
            int iconSize = 40; // Adjust icon size as needed

            foreach (string icon in iconSuggestions)
            {
                Button iconButton = new Button();
                iconButton.Text = icon;
                iconButton.Font = new Font("Segoe UI Emoji", 12);
                iconButton.AutoSize = true;
                iconButton.FlatStyle = FlatStyle.Flat; // Remove button border
                iconButton.FlatAppearance.BorderSize = 0; // Remove button border
                iconButton.BackColor = Color.LightGray; // Set button background color to match form's background
                iconButton.Size = new Size(iconSize, iconSize); // Set icon size
                iconButton.Location = new Point(xPos, yPos);
                iconButton.Click += (sender, e) =>
                {
                    textBox1.Text += icon;
                    iconSuggestionForm.Close();
                };
                iconSuggestionForm.Controls.Add(iconButton);

                // Move to the next row if the maximum number of icons per row is reached
                if ((iconSuggestions.IndexOf(icon) + 1) % iconsPerRow == 0)
                {
                    xPos = 10;
                    yPos += iconSize + iconSpacing;
                }
                else
                {
                    xPos += iconSize + iconSpacing;
                }
            }

            iconSuggestionForm.ShowInTaskbar = false; // Don't show in taskbar
            iconSuggestionForm.ShowIcon = false; // Hide icon
            iconSuggestionForm.TopMost = true; // Ensure it stays on top
            iconSuggestionForm.Show(); // Show the form
        }
       
        private async void sendTextButton_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text.Trim();
            if (isSavingMessage)
            {
                // Đang xử lý tin nhắn trước đó, không cho phép gửi tin nhắn mới
                sendTextButton.Enabled = true;
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

                    // Không cần hiển thị tin nhắn ở đây nữa vì `DisplayMessage` sẽ được gọi từ Firebase lắng nghe

                    textBox1.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    isSavingMessage = false; // Kết thúc quá trình lưu tin nhắn
                    sendTextButton.Enabled = true; // Kích hoạt lại nút
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tin nhắn.");
                sendTextButton.Enabled = true; // Kích hoạt lại nút
            }
        }

        private async void keyInput_Click_1(object sender, EventArgs e)
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

        private async void GroupChat_Member_Load(object sender, EventArgs e)
        {
            ListenForMessages(); // Sau đó lắng nghe các tin nhắn mới
            await LoadChatHistory(); // Tải lịch sử trò chuyện trước
        }

        private void iconButton_Click_1(object sender, EventArgs e)
        {
            ShowIconSuggestionPopup();
        }

        private void exitBtn_CheckedChanged(object sender, EventArgs e)
        {
            this.Close();
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
                            Message = encryptionKey == null ? base64File : SecurityChat.EncryptChat(base64File, encryptionKey),
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

        private void keytextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

