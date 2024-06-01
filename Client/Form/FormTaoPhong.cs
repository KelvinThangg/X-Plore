using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;

namespace Client
{
    public partial class FormTaoPhong : Form
    {
        private const string FirebaseURL = "https://checkdatabase-1fbc9-default-rtdb.firebaseio.com/";
        private FirebaseClient firebaseClient;
        private static string appId = Guid.NewGuid().ToString();
        private string currentUserName;
        private List<string> adminRooms;
        public FormTaoPhong(string userName)
        {
            InitializeComponent();
            InitializeFirebase();
            currentUserName = userName;
            adminRooms = new List<string>();
            LoadAdminRooms(); // Tải danh sách phòng của admin khi khởi tạo
            LoadRooms();
            // Gắn sự kiện cho các nút
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
        }

        private void InitializeFirebase()
        {
            firebaseClient = new FirebaseClient(FirebaseURL);
        }

        private async void LoadAdminRooms()
        {
            try
            {
                var user = await firebaseClient.Child("users").Child(currentUserName).OnceSingleAsync<Users>();
                if (user != null)
                {
                    adminRooms = user.RoomNames ?? new List<string>(); // Đảm bảo adminRooms không null
                }
                else
                {
                    adminRooms = new List<string>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phòng của admin: " + ex.Message);
            }
        }

        private async void LoadRooms()
        {
            try
            {
                // Tải danh sách phòng mà người dùng đã tạo và tìm thấy
                var user = await firebaseClient.Child("users").Child(currentUserName).OnceSingleAsync<Users>();
                var roomNames = new List<string>();

                if (user?.RoomNames != null)
                {
                    roomNames.AddRange(user.RoomNames);
                }

                if (user?.FoundRooms != null)
                {
                    roomNames.AddRange(user.FoundRooms.Where(roomName => !roomNames.Contains(roomName)));
                }

                var rooms = new List<Room>();
                foreach (var roomName in roomNames)
                {
                    var room = await firebaseClient.Child("rooms").Child(roomName).OnceSingleAsync<Room>();
                    if (room != null)
                    {
                        rooms.Add(room);
                    }
                }

                // Lấy vị trí cuối cùng của các điều khiển hiện có trong panel1 để thêm các phòng mới mà không bị chồng chéo
                int xOffset = 0;
                int yOffset = 0;
                int buttonWidth = 200;
                int buttonHeight = 50;
                int spacing = 10;

                if (panel1.Controls.Count > 0)
                {
                    var lastButton = panel1.Controls[panel1.Controls.Count - 1] as Button;
                    if (lastButton != null)
                    {
                        xOffset = lastButton.Left;
                        yOffset = lastButton.Top + lastButton.Height + spacing;
                    }
                }

                foreach (var room in rooms)
                {
                    string roomName = room.Name;

                    // Kiểm tra xem phòng này đã tồn tại trong panel1 chưa
                    bool roomAlreadyDisplayed = false;
                    foreach (Control control in panel1.Controls)
                    {
                        if (control is Button button && button.Tag.ToString() == roomName)
                        {
                            roomAlreadyDisplayed = true;
                            break;
                        }
                    }
                    if (!roomAlreadyDisplayed)
                    {
                        if (xOffset + buttonWidth > panel1.Width)
                        {
                            // Nếu vượt quá chiều ngang của panel1, đặt xuống dòng
                            xOffset = 0;
                            yOffset += buttonHeight + spacing;
                        }

                        Button roomButton = new Button
                        {
                            Text = roomName + (adminRooms.Contains(roomName) ? " (admin)" : ""),
                            Width = buttonWidth,
                            Height = buttonHeight,
                            Tag = roomName,
                            Left = xOffset,
                            Top = yOffset
                        };
                        roomButton.Click += (s, args) => OpenRoomForm(roomName, adminRooms.Contains(roomName));
                        panel1.Controls.Add(roomButton);

                        xOffset += buttonWidth + spacing;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phòng: " + ex.Message);
            }
        }

        private void DisplayRooms(List<Room> rooms)
        {
            panel1.Controls.Clear();
            int xOffset = 0; // Offset theo chiều ngang
            int yOffset = 0; // Offset theo chiều dọc
            int buttonWidth = 200; // Chiều rộng của button
            int buttonHeight = 50; // Chiều cao của button
            int spacing = 10; // Khoảng cách giữa các button

            foreach (var room in rooms)
            {
                if (xOffset + buttonWidth > panel1.Width)
                {
                    // Nếu vượt quá chiều ngang của panel1, đặt xuống dòng
                    xOffset = 0;
                    yOffset += buttonHeight + spacing;
                }

                string roomName = room.Name;

                Button roomButton = new Button
                {
                    Text = roomName + (adminRooms.Contains(roomName) ? " (admin)" : ""),
                    Width = buttonWidth,
                    Height = buttonHeight,
                    Tag = roomName,
                    Left = xOffset,
                    Top = yOffset
                };
                roomButton.Click += (s, args) => OpenRoomForm(roomName, adminRooms.Contains(roomName));
                panel1.Controls.Add(roomButton);
                xOffset += buttonWidth + spacing;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string tenPhong = textBox2.Text;
            string matKhau = textBox1.Text;
            try
            {
                var room = await firebaseClient.Child("rooms").Child(tenPhong).OnceSingleAsync<Room>();
                if (room != null)
                {
                    bool isAdminRoom = adminRooms.Contains(room.Name);
                    // Kiểm tra xem mật khẩu nhập vào có khớp với mật khẩu của phòng không
                    if (room.Password == matKhau)
                    {
                        // Thêm phòng vào danh sách phòng đã tìm thấy của người dùng
                        var user = await firebaseClient.Child("users").Child(currentUserName).OnceSingleAsync<Users>();
                        if (user != null)
                        {
                            if (user.FoundRooms == null)
                            {
                                user.FoundRooms = new List<string>();
                            }
                            if (!user.FoundRooms.Contains(tenPhong))
                            {
                                user.FoundRooms.Add(tenPhong);
                                await firebaseClient.Child("users").Child(currentUserName).PutAsync(user);
                            }
                        }
                        else
                        {
                            user = new Users { UserName = currentUserName, FoundRooms = new List<string> { tenPhong } };
                            await firebaseClient.Child("users").Child(currentUserName).PutAsync(user);
                        }
                        // Hiển thị phòng tìm thấy
                        DisplayRooms(new List<Room> { room });
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không đúng.");
                    }
                }
                else
                {
                    MessageBox.Show("Phòng không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm phòng: " + ex.Message);
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            string tenPhong = textBox2.Text;
            string matKhau = textBox1.Text;
            try
            {
                var room = new Room { Name = tenPhong, Password = matKhau, IsAdmin = true, AppId = appId };
                await firebaseClient.Child("rooms").Child(tenPhong).PutAsync(room);
                // Liên kết phòng với người dùng
                var user = await firebaseClient.Child("users").Child(currentUserName).OnceSingleAsync<Users>();
                if (user != null)
                {
                    if (user.RoomNames == null)
                    {
                        user.RoomNames = new List<string>();
                    }
                    if (!user.RoomNames.Contains(tenPhong))
                    {
                        user.RoomNames.Add(tenPhong);
                        await firebaseClient.Child("users").Child(currentUserName).PutAsync(user);
                    }
                }
                else
                {
                    user = new Users { UserName = currentUserName, RoomNames = new List<string> { tenPhong } };
                    await firebaseClient.Child("users").Child(currentUserName).PutAsync(user);
                }
                // Cập nhật danh sách adminRooms
                adminRooms.Add(tenPhong);
                // Load lại danh sách phòng admin
                LoadRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo phòng: " + ex.Message);
            }
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            string tenPhong = textBox2.Text;
            string matKhauNhap = textBox1.Text;
            try
            {
                var room = await firebaseClient.Child("rooms").Child(tenPhong).OnceSingleAsync<Room>();
                if (room != null)
                {
                    if (room.Password == matKhauNhap && adminRooms.Contains(tenPhong)) // Kiểm tra quyền admin
                    {
                        // Xóa tất cả các tin nhắn trong phòng
                        await firebaseClient.Child("RoomNames").Child(tenPhong).Child("messages").DeleteAsync();///
                        // Xóa phòng
                        await firebaseClient.Child("rooms").Child(tenPhong).DeleteAsync();
                        // Xóa phòng khỏi danh sách của người dùng
                        var user = await firebaseClient.Child("users").Child(currentUserName).OnceSingleAsync<Users>();
                        if (user != null)
                        {
                            if (user.RoomNames != null)
                            {
                                user.RoomNames.Remove(tenPhong);
                            }
                            if (user.FoundRooms != null)
                            {
                                user.FoundRooms.Remove(tenPhong);
                            }
                            await firebaseClient.Child("users").Child(currentUserName).PutAsync(user);
                        }
                        // Xóa phòng khỏi danh sách adminRooms
                        adminRooms.Remove(tenPhong);
                        LoadRooms();  // Tải lại danh sách phòng sau khi xóa
                        MessageBox.Show("Phòng đã xóa: " + tenPhong);
                    }
                    else
                    {
                        MessageBox.Show("Không có quyền xóa phòng.");
                    }
                }
                else
                {
                    MessageBox.Show("Phòng không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phòng: " + ex.Message);
            }
        }

        private void OpenRoomForm(string roomName, bool isAdmin)
        {
            if (isAdmin)
            {
                AdminChat formAdminChat = new AdminChat(roomName, currentUserName, currentUserName);
                formAdminChat.Show();
            }
            else
            {
                MemberChat formMemberChat = new MemberChat(roomName, currentUserName); // Truyền currentUserName vào MemberChat
                formMemberChat.Show();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
