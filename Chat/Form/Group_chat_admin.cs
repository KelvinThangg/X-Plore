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
    public partial class Group_chat_admin : Form
    {
        private const string FirebaseURL = "https://checkdatabase-1fbc9-default-rtdb.firebaseio.com/";
        private FirebaseClient firebaseClient;
        private string roomName;
        private string roomCreator;
        private string adminName;
        private HashSet<string> displayedMessages = new HashSet<string>(); // HashSet để lưu trữ các tin nhắn đã hiển thị
        private List<Form> openForms = new List<Form>();
        private bool isSavingMessage = false;
        private bool isSendingFile = false;
        private string encryptionKey = null; // Add this line to store the encryption key
        public Group_chat_admin(string roomName, string roomCreator, string adminName)
        {
            InitializeComponent();
            this.roomName = roomName;
            this.roomCreator = roomCreator;
            this.adminName = adminName;
            InitializeFirebase();
            LoadChatHistory();
            ListenForMessages();
            CreateDataDirectories();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void InitializeFirebase()
        {
            firebaseClient = new FirebaseClient(FirebaseURL);
        }
        private void CreateDataDirectories()
        {
            string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string imgDir = Path.Combine(projectDir, "X-Plore", "Chat", "Data", "IMG");
            string fileDir = Path.Combine(projectDir, "X-Plore", "Chat", "Data", "File");

            if (!Directory.Exists(imgDir))
            {
                Directory.CreateDirectory(imgDir);
            }
            if (!Directory.Exists(fileDir))
            {
                Directory.CreateDirectory(fileDir);
            }
        }
        public void UpdateSenderNames(string senderName)
        {
            // Kiểm tra xem cột "Sender" đã tồn tại trong DataGridView chưa, nếu chưa thì thêm
            if (dataGridView1.Columns["Sender"] == null)
            {
                dataGridView1.Columns.Add("Sender", "Sender");
            }
            // Kiểm tra xem tên người gửi đã được thêm vào DataGridView chưa
            bool senderNameExists = dataGridView1.Rows.Cast<DataGridViewRow>()
                                                      .Any(row => row.Cells["Sender"].Value?.ToString() == senderName);
            // Nếu tên người gửi chưa tồn tại trong DataGridView, thêm nó vào
            if (!senderNameExists)
            {
                int rowIndex = dataGridView1.Rows.Add(senderName);
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

                foreach (var messageNode in chatHistory)
                {
                    DisplayMessage(messageNode.Object);
                    UpdateSenderNames(messageNode.Object.Sender);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử trò chuyện: " + ex.Message);
            }
        }

        private async Task SaveMessageToFirebase(string message, bool isFile = false, string fileName = "")
        {
            try
            {
                // Mã hóa tin nhắn trước khi lưu
                string encryptedMessage = encryptionKey == null ? message : SecurityChat.EncryptChat(message, encryptionKey);

                var messageNode = new MessageNode
                {
                    Message = encryptedMessage,
                    Sender = roomCreator, // Lưu tin nhắn dưới tên roomCreator
                    Timestamp = DateTime.Now,
                    IsFile = isFile,
                    FileName = fileName
                };

                await firebaseClient.Child("RoomNames")
                                    .Child(roomName)
                                    .Child("messages")
                                    .PostAsync(messageNode);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu tin nhắn lên Firebase: " + ex.Message);
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
                    string fileMessage = $"{adminName} đã gửi một tệp: {message.FileName}"; // Hiển thị adminName thay vì roomCreator
                    listBox1.Items.Add(fileMessage);
                    displayedMessages.Add(uniqueMessageIdentifier);

                    // Lưu tệp vào thư mục tạm thời khi tin nhắn được hiển thị lần đầu
                    string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                    string fileExtension = Path.GetExtension(message.FileName).ToLower();
                    string targetDir = (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif") ?
                        Path.Combine(projectDir, "X-Plore", "Chat", "Data", "IMG") :
                        Path.Combine(projectDir, "X-Plore", "Chat", "Data", "File");

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
                    string newMessage = $"{adminName}: {decryptedMessage}"; // Hiển thị adminName thay vì roomCreator
                    listBox1.Items.Add(newMessage);
                    displayedMessages.Add(uniqueMessageIdentifier);
                }
            }
        }


        private void ListenForMessages()
        {
            firebaseClient
             .Child("RoomNames")
             .Child(roomName)
             .Child("messages")
             .AsObservable<MessageNode>()
             .Subscribe(d =>
             {
                 if (d.Object != null)
                 {
                     if (this.IsHandleCreated) // Kiểm tra xem handle của control đã được tạo chưa
                     {
                         this.Invoke((MethodInvoker)delegate
                         {
                             string uniqueMessageIdentifier = d.Object.IsFile ? $"{d.Object.Sender}-{d.Object.FileName}-{d.Object.Timestamp}" : $"{d.Object.Sender}-{d.Object.Message}-{d.Object.Timestamp}";

                             if (!displayedMessages.Contains(uniqueMessageIdentifier))
                             {
                                 DisplayMessage(d.Object);
                             }
                         });
                     }
                 }
             });
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Add this method to handle key input button click
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


        private async void delChat_Click_1(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sạch đoạn chat này không?",
                                                 "Xác nhận xóa",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    // Xóa node chứa tin nhắn trong phòng chat trên Firebase
                    await firebaseClient.Child("RoomNames")
                                        .Child(roomName)
                                        .Child("messages")
                                        .DeleteAsync();

                    // Xóa tin nhắn hiển thị trong ListBox (hoặc bất cứ UI component nào khác bạn dùng để hiển thị tin nhắn)
                    listBox1.Items.Clear();

                    MessageBox.Show("Đã xóa sạch đoạn chat.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa đoạn chat: " + ex.Message);
                }
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
                await LoadChatHistory(); // Call the method synchronously
            }
        }

        private void iconButton_Click_1(object sender, EventArgs e)
        {
            ShowIconSuggestionPopup();
        }

        private async void file_Click(object sender, EventArgs e)
        {
            if (isSendingFile)
            {
                // Nếu đang trong quá trình gửi file, không cho phép gửi tiếp
                return;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(filePath);

                    try
                    {
                        isSendingFile = true;

                        // Đọc tệp vào một mảng byte
                        byte[] fileBytes = File.ReadAllBytes(filePath);

                        // Chuyển đổi mảng byte thành chuỗi base64
                        string base64File = Convert.ToBase64String(fileBytes);

                        // Mã hóa nội dung tệp
                        string encryptedFile = encryptionKey == null ? base64File : SecurityChat.EncryptChat(base64File, encryptionKey);

                        // Tạo một đối tượng tin nhắn với loại tệp
                        var messageNode = new MessageNode
                        {
                            Message = encryptedFile,
                            Sender = roomCreator, // Lưu tin nhắn dưới tên roomCreator
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
                    finally
                    {
                        isSendingFile = false;
                    }
                }
            }
        }

        private void Group_chat_admin_Load(object sender, EventArgs e)
        {
            ListenForMessages();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}