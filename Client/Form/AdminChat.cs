﻿
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
    public partial class AdminChat : Form
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

        public AdminChat(string roomName, string roomCreator, string adminName)
        {
            InitializeComponent();
            this.roomName = roomName;
            this.roomCreator = roomCreator;
            this.adminName = adminName;
            InitializeFirebase();
            LoadChatHistory();
            ListenForMessages();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }
       
        private void InitializeFirebase()
        {
            firebaseClient = new FirebaseClient(FirebaseURL);
        }

        public void UpdateSenderNames(string senderName)
        {
            // Kiểm tra xem cột "Sender" đã tồn tại trong DataGridView chưa, nếu chưa thì thêm
            if (dataGridView1.Columns["Sender"] == null)
            {
                dataGridView1.Columns.Add("Sender", "Sender");
            }

            // Thêm cột "Kick" nếu chưa tồn tại
            if (dataGridView1.Columns["Kick"] == null)
            {
                DataGridViewButtonColumn kickButtonColumn = new DataGridViewButtonColumn();
                kickButtonColumn.Name = "Kick";
                kickButtonColumn.HeaderText = "Kick";
                kickButtonColumn.Text = "Kick";
                kickButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(kickButtonColumn);
            }

            // Kiểm tra xem tên người gửi đã được thêm vào DataGridView chưa
            bool senderNameExists = dataGridView1.Rows.Cast<DataGridViewRow>()
                                                      .Any(row => row.Cells["Sender"].Value?.ToString() == senderName);

            // Nếu tên người gửi chưa tồn tại trong DataGridView, thêm nó vào
            if (!senderNameExists)
            {
                int rowIndex = dataGridView1.Rows.Add(senderName);
                dataGridView1.Rows[rowIndex].Cells["Kick"].Value = "Kick";
            }
        }

        private async void LoadChatHistory()
        {
            try
            {
                listBox1.Items.Clear();
                displayedMessages.Clear();

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
                string encryptedMessage = encryptionKey == null ? message : Security.Encrypt(message, encryptionKey);

                var messageNode = new MessageNode
                {
                    Message = encryptedMessage,
                    Sender = adminName,
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
            // Use encryptionKey if available and if the message is not a file
            string decryptedMessage = message.IsFile ? message.Message : (encryptionKey == null ? message.Message : Security.Decrypt(message.Message, encryptionKey));

            // Unique identifier for the message
            string uniqueMessageIdentifier = message.IsFile ? $"{message.Sender}-{message.FileName}-{message.Timestamp}" : $"{message.Sender}-{decryptedMessage}-{message.Timestamp}";

            // Check if the message has been displayed already
            if (!displayedMessages.Contains(uniqueMessageIdentifier))
            {
                if (message.IsFile)
                {
                    string fileMessage = $"{message.Sender} đã gửi một tệp: {message.FileName}";
                    listBox1.Items.Add(fileMessage);
                    displayedMessages.Add(uniqueMessageIdentifier);

                    // Save the file to a temporary directory when the message is displayed for the first time
                    string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                    string fileExtension = Path.GetExtension(message.FileName).ToLower();
                    string targetDir = (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif") ?
                        Path.Combine(projectDir, "Client", "Data", "IMG") :
                        Path.Combine(projectDir, "Client", "Data", "File");

                    string filePath = Path.Combine(targetDir, message.FileName);

                    // Decrypt the file content if necessary
                    byte[] fileBytes;
                    if (encryptionKey != null)
                    {
                        // Decrypt the file content if encryptionKey is available
                        string decryptedBase64File = Security.Decrypt(message.Message, encryptionKey);
                        fileBytes = Convert.FromBase64String(decryptedBase64File);
                    }
                    else
                    {
                        // No decryption needed, just convert from base64 to byte
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
                    DisplayMessage(new MessageNode { Message = message, Sender = adminName, Timestamp = DateTime.Now });
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

        private void AdminChat_Load_1(object sender, EventArgs e)
        {
            ListenForMessages();
        }

        private void RemoveForm(Form form)
        {
            openForms.Remove(form);
        }

        private void CloseFormByName(string senderName)
        {
            var formsToClose = openForms.OfType<MemberChat>()
                                        .Where(f => f.UserName == senderName)
                                        .ToList();

            foreach (var form in formsToClose)
            {
                form.Close();
                RemoveForm(form); // Sau khi đóng, loại bỏ form khỏi danh sách
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Kick"].Index)
            {
                // Lấy tên người gửi từ ô được chọn
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells["Sender"];
                if (cell.Value != null)
                {
                    string senderName = cell.Value.ToString();

                    // Xóa hàng tương ứng khỏi DataGridView
                    dataGridView1.Rows.RemoveAt(e.RowIndex);

                    // Thực hiện hành động kick, ví dụ như đóng form tương ứng
                    CloseFormByName(senderName);

                    // Hiển thị thông báo
                    MessageBox.Show($"{senderName} đã bị kick.");
                }
                else
                {
                    MessageBox.Show("Không thể xác định tên người gửi.");
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                        string encryptedFile = encryptionKey == null ? base64File : Security.Encrypt(base64File, encryptionKey);

                        // Tạo một đối tượng tin nhắn với loại tệp
                        var messageNode = new MessageNode
                        {
                            Message = encryptedFile,
                            Sender = adminName,
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

        private async void delChat_Click(object sender, EventArgs e)
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

        // Add this method to handle key input button click
       

        private void keyInput_Click(object sender, EventArgs e)
        {
            encryptionKey = keytextBox.Text.Trim();
            if (string.IsNullOrEmpty(encryptionKey))
            {
                MessageBox.Show("Vui lòng nhập khóa.");
            }
            else
            {
                MessageBox.Show("Khóa đã được cập nhật.");
                LoadChatHistory(); // Call the method synchronously
            }
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
        private void iconButton_Click(object sender, EventArgs e)
        {
            ShowIconSuggestionPopup();
        }
    }
}