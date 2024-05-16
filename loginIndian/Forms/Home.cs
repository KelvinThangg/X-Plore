using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using loginIndian.Classes;
namespace loginIndian.Forms
{
    public partial class Home : Form
    {
        private string username;
        private string displayname;
        public Home(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // 1. Lấy tên từ textbox
            string newDisplayName = txtDisplayName.Text.Trim(); // Giả sử textbox tên là txtDisplayName

            // 2. Kiểm tra xem tên có hợp lệ hay không (ví dụ: không được để trống)
            if (string.IsNullOrEmpty(newDisplayName))
            {
                MessageBox.Show("Vui lòng nhập tên hiển thị.");
                return;
            }

            // 3. Lấy thông tin UserData hiện tại 
           UserData userData = await GetCurrentUserData();

            // 4. Cập nhật DisplayName
            userData.DisplayName = newDisplayName;

            // 5. Lưu UserData đã cập nhật vào database
            await UpdateUserData(userData);

            // 6. Thông báo thành công
            MessageBox.Show("Đã đổi tên hiển thị thành công!");
        }

        // Ví dụ về hàm GetCurrentUserData() - Bạn cần điều chỉnh logic dựa vào cách bạn xác định user hiện tại
        private async Task<UserData> GetCurrentUserData()
        {
            // Ví dụ: Lấy UserData dựa trên Username được lưu trữ ở đâu đó
            string currentUsername = username; // Thay thế bằng cách lấy username hiện tại
            FirestoreHelper.SetEnvironmentVariable();
            DocumentReference docRef = FirestoreHelper.Database.Collection("UserData").Document(currentUsername);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            return snapshot.ConvertTo<UserData>();
        }

        // Ví dụ về hàm UpdateUserData()
        private async Task UpdateUserData(UserData userData)
        {
            FirestoreHelper.SetEnvironmentVariable();
            DocumentReference docRef = FirestoreHelper.Database.Collection("UserData").Document(userData.Username);
            await docRef.SetAsync(userData);
        }

    }
    
}
