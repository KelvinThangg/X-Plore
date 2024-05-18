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
        public class MessageNode
        {
            public string Message { get; set; }
            public string Sender { get; set; }
            public DateTime Timestamp { get; set; }
            public bool IsFile { get; set; } = false;
            public string FileName { get; set; }
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

        private async Task SaveMessageToFirebase(string message)
        {
            try
            {
                var messageNode = new MessageNode
                {
                    Message = message,
                    Sender = roomCreator,
                    Timestamp = DateTime.Now
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
            string displayText;

            if (message.IsFile)
            {
                displayText = $"{message.Sender} đã gửi tệp: {message.FileName}";
            }
            else
            {
                displayText = $"{message.Sender}: {message.Message}";
            }

            if (!listBox1.Items.Cast<string>().Any(item => item.Equals(displayText)))
            {
                listBox1.Items.Add(displayText);
            }

            if (message.IsFile)
            {
                string fileMessage = $"{message.Sender} đã gửi một tệp: {message.FileName}";
                listBox1.Items.Add(fileMessage);

                // Lưu tệp vào thư mục tạm thời và mở nó khi người dùng nhấp vào tin nhắn
                string tempFilePath = Path.Combine(Path.GetTempPath(), message.FileName);
                File.WriteAllBytes(tempFilePath, Convert.FromBase64String(message.Message));

                // Thêm hành động nhấp chuột để mở tệp
                listBox1.SelectedIndexChanged += (s, e) =>
                {
                    if (listBox1.SelectedItem != null && listBox1.SelectedItem.ToString() == fileMessage)
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = tempFilePath,
                            UseShellExecute = true
                        });
                    }
                };
            }
            else
            {
                string newMessage = $"{message.Sender}: {message.Message}";
                listBox1.Items.Add(newMessage);
            }

            // Thêm tin nhắn vào HashSet
            displayedMessages.Add(message.Message);
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
                                DisplayMessage(d.Object);
                                UpdateSenderNames(d.Object.Sender);
                            });
                        }
                    }
                });
        }

        private void AdminChat_Load_1(object sender, EventArgs e)
        {
            ListenForMessages();
        }
        private void AddForm(Form form)
        {
            openForms.Add(form);
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
                            Sender = adminName,
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
    }

}
