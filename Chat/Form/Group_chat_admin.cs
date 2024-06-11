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
using Amazon.S3.Model;
using Amazon.S3;
using System.Net;
using X_Plore.Class;
using AWSSDK;
using Amazon;
using AForge.Video;

using NAudio.Wave;
using WebSocketSharp;
using CrapChat;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace X_Plore.Chat
{
    public partial class Group_chat_admin : Form
    {
        private const string FirebaseURL = "https://testfinal-90ec8-default-rtdb.asia-southeast1.firebasedatabase.app/";
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
            keytextBox.UseSystemPasswordChar = true;
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
                    FileName = fileName,
                    DisplayName = adminName
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
                    string fileMessage = $"{message.DisplayName} đã gửi một tệp: {message.FileName}"; // Hiển thị adminName thay vì roomCreator
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
                    string displayNameWithYou = message.Sender == adminName ? $"{message.DisplayName} (you)" : message.DisplayName;

                    string newMessage = $"{displayNameWithYou}: {decryptedMessage}";

                    listBox1.Items.Add(newMessage);
                    listBox1.TopIndex = listBox1.Items.Count - 1; // Cuộn xuống dòng cuối cùng
                
                    displayedMessages.Add(uniqueMessageIdentifier);

                }
            }
        }
       
        public async Task UpdateAllDisplayNamesForSender(string sender, string newDisplayName)
        {
            try
            {
                // Lấy tất cả tin nhắn trong phòng chat
                var messages = await firebaseClient.Child("RoomNames")
                                                  .Child(roomName)
                                                  .Child("messages")
                                                  .OnceAsync<MessageNode>();

                // Duyệt qua các tin nhắn và cập nhật DisplayName nếu Sender khớp
                foreach (var message in messages)
                {
                    if (message.Object.Sender == roomCreator)
                    {
                        // Đảm bảo newDisplayName được gửi dưới dạng chuỗi JSON hợp lệ
                        await firebaseClient.Child("RoomNames")
                                            .Child(roomName)
                                            .Child("messages")
                                            .Child(message.Key)
                                            .Child("DisplayName")
                                            .PutAsync($"\"{newDisplayName}\""); // Thêm dấu ngoặc kép
                    }
                }

                // Tải lại lịch sử trò chuyện để hiển thị thay đổi
                await LoadChatHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật DisplayName: " + ex.Message);
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
        public class LowLevelMouseHook
        {
            private const int WH_MOUSE_LL = 14;
            private const int WM_LBUTTONDOWN = 0x0201;
            private static LowLevelMouseProc _proc = HookCallback;
            private static IntPtr _hookID = IntPtr.Zero;

            public static event EventHandler MouseClick;

            public static void SetHook()
            {
                _hookID = SetHook(_proc);
            }

            public static void Unhook()
            {
                UnhookWindowsHookEx(_hookID);
            }

            private static IntPtr SetHook(LowLevelMouseProc proc)
            {
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
                }
            }

            private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

            private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0 && wParam == (IntPtr)WM_LBUTTONDOWN)
                {
                    MouseClick?.Invoke(null, EventArgs.Empty);
                }
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);
        }

        // Class-level variables
        // Class-level variables
        // Class-level variables
        private Form iconSuggestionForm;

        private void ShowIconSuggestionPopup()
        {
            // If the suggestion form is already open, close it and return
            if (iconSuggestionForm != null && !iconSuggestionForm.IsDisposed)
            {
                iconSuggestionForm.Close();
                return;
            }

            // Define the properties for icons and layout
            int iconSize = 40;
            int iconsPerRow = 5;
            int iconSpacing = 5;
            int totalIcons = 20;
            int totalIconsPlusCloseButton = totalIcons + 1;

            // Calculate the number of rows needed
            int rows = (int)Math.Ceiling(totalIconsPlusCloseButton / (double)iconsPerRow);

            // Calculate the form size based on the number of icons and spacing
            int formWidth = (iconsPerRow * iconSize) + ((iconsPerRow - 1) * iconSpacing) + 20;
            int formHeight = (rows * iconSize) + ((rows - 1) * iconSpacing) + 40;

            // Create a new form instance
            iconSuggestionForm = new Form
            {
                FormBorderStyle = FormBorderStyle.None, // Remove border
                StartPosition = FormStartPosition.Manual,
                BackColor = Color.LightGreen, // Set background color
                TransparencyKey = Color.LightGreen, // Make the background color transparent
                Width = formWidth, // Set form width based on the calculated value
                Height = formHeight // Set form height based on the calculated value
            };

            iconSuggestionForm.Location = new Point(this.Location.X + iconButton.Location.X,
                                                    this.Location.Y + iconButton.Location.Y + iconButton.Height + 40);

            List<string> iconSuggestions = new List<string> { "❤️", "😎", "👍", "😁", "😢", "😊", "😀", "👌", "😍", "😌",
                                "🥰", "😇", "😅", "😂", "🤩", "📚", "🎓", "🖊️", "📝" };

            int xPos = 10;
            int yPos = 10;

            // Add the close button first
            Button closeButton = new Button
            {
                Text = "X",
                Font = new Font("Segoe UI", 12),
                BackColor = Color.Red,
                ForeColor = Color.White,
                Size = new Size(iconSize, iconSize),
                Location = new Point(xPos, yPos)
            };

            closeButton.Click += (sender, e) =>
            {
                iconSuggestionForm.Close();
                LowLevelMouseHook.Unhook();
            };

            iconSuggestionForm.Controls.Add(closeButton);

            // Adjust the position for the next icon
            xPos += iconSize + iconSpacing;

            for (int i = 0; i < iconSuggestions.Count; i++)
            {
                string icon = iconSuggestions[i];
                Button iconButton = new Button
                {
                    Text = icon,
                    Font = new Font("Segoe UI Emoji", 12),
                    AutoSize = true,
                    FlatStyle = FlatStyle.Flat, // Remove button border
                    BackColor = Color.LightGray, // Set button background color to match form's background
                    Size = new Size(iconSize, iconSize), // Set icon size
                    Location = new Point(xPos, yPos)
                };
                iconButton.FlatAppearance.BorderSize = 0; // Remove button border

                iconButton.Click += (sender, e) =>
                {
                    textBox1.Text += icon;
                    iconSuggestionForm.Close();
                    LowLevelMouseHook.Unhook();
                };

                iconSuggestionForm.Controls.Add(iconButton);

                // Move to the next icon position
                if ((i + 2) % iconsPerRow == 0) // Account for the close button in the first row
                {
                    xPos = 10;
                    yPos += iconSize + iconSpacing;
                }
                else
                {
                    xPos += iconSize + iconSpacing;
                }
            }

            iconSuggestionForm.FormClosed += (sender, e) =>
            {
                LowLevelMouseHook.Unhook();
            };

            iconSuggestionForm.ShowInTaskbar = false; // Don't show in taskbar
            iconSuggestionForm.ShowIcon = false; // Hide icon
            iconSuggestionForm.TopMost = true; // Ensure it stays on top
            iconSuggestionForm.Show(); // Show the form

            // Register the low-level mouse hook to close the form when clicking outside
            LowLevelMouseHook.SetHook();
            LowLevelMouseHook.MouseClick += (sender, e) =>
            {
                Point cursorPosition = Cursor.Position;
                if (iconSuggestionForm != null && !iconSuggestionForm.Bounds.Contains(cursorPosition))
                {
                    iconSuggestionForm.Close();
                    LowLevelMouseHook.Unhook();
                }
            };
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

        private async void Group_chat_admin_Load(object sender, EventArgs e)
        {
            label1.Text = roomName;
            await LoadAvatarFromS3();
            ListenForMessages();
            await UpdateAllDisplayNamesForSender(roomCreator, adminName);
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private async Task LoadAvatarFromS3()
        {
            AWSS3 awsS3 = new AWSS3();
            string username = roomCreator;
            string AccessKey = awsS3.GetAccessKey();
            string SecretKey = awsS3.GetSecretKey();
            string SessionToken = awsS3.GetSessionToken();
            string BucketName = awsS3.GetBucketName();

            try
            {
                // Tạo tên tệp tin avatar dựa trên username
                string avatarFileName = $"{username}_avatar.png";

                // Tạo request để lấy ảnh từ S3
                var request = new GetObjectRequest
                {
                    BucketName = BucketName,
                    Key = avatarFileName
                };

                // Lấy thông tin đăng nhập AWS
                var credentials = new Amazon.Runtime.SessionAWSCredentials(AccessKey, SecretKey, SessionToken);

                // Tạo AmazonS3Client
                using (var client = new AmazonS3Client(credentials, RegionEndpoint.USEast1))
                {
                    // Thực hiện request để lấy ảnh
                    using (var response = await client.GetObjectAsync(request))
                    {
                        // Kiểm tra xem ảnh có tồn tại hay không
                        if (response.HttpStatusCode == HttpStatusCode.OK)
                        {
                            // Tải ảnh và hiển thị trong PictureBox
                            using (var stream = new MemoryStream())
                            {
                                await response.ResponseStream.CopyToAsync(stream);
                                guna2CirclePictureBox1.Image = Image.FromStream(stream);
                            }
                        }
                        else
                        {
                            // Xử lý trường hợp không tìm thấy ảnh (ví dụ: hiển thị ảnh mặc định)
                            guna2CirclePictureBox1.Image = Properties.Resources.avatardefault_92824;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải ảnh đại diện: {ex.Message}");
                // Xử lý lỗi, ví dụ: ghi log hoặc hiển thị thông báo cho người dùng
            }
        }
        public string GetRoomCreator()
        {
            return roomCreator;
        }
       

            private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            //CALL

            CallForm call = new CallForm();
            call.Show();
        }

        private void HideorShowpassCb_CheckedChanged(object sender, EventArgs e)
        {
            if (HideorShowpassCb.Checked)
            {
                keytextBox.UseSystemPasswordChar = false;
            }
            else
            {
                keytextBox.UseSystemPasswordChar = true;
            }
        }
    }
}