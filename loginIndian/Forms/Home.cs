﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            panelDoipass.Hide();
            NhapPassPn.Hide();


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

        // Doipass
        private bool ValidateFields()
        {
            if (ReEnterPasswordBox.Text != PassBox.Text)
            {
                MessageBox.Show("The passwords you entered do not match. Please try again.");
                return false;
            }

            Regex passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
            if (!passwordRegex.IsMatch(PassBox.Text) || !passwordRegex.IsMatch(OldpassBox.Text))
            {
                MessageBox.Show("Password must contain at least 8 characters, one uppercase letter, one lowercase letter, one number, and one special character.");
                return false;
            }

            return true;
        }

        private async void button3_Click(object sender, EventArgs e)
        { 
            
            panelDoipass.Show();
        
        
            if (!ValidateFields())
            {
                return; // Dừng nếu mật khẩu không hợp lệ
            }

            string oldPassword = OldpassBox.Text;
            string newPassword = PassBox.Text;
            string reEnteredPassword = ReEnterPasswordBox.Text;

            UserData userData = await GetCurrentUserData();

            // Kiểm tra xem mật khẩu cũ có khớp với mật khẩu đã lưu hay không
            if (Security.Encrypt(oldPassword) != userData.Password)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác.");
                return;
            }

            // Cập nhật mật khẩu mới
            userData.Password = Security.Encrypt(newPassword);

            await UpdateUserData(userData);

            MessageBox.Show("Đổi mật khẩu thành công!");

            // Xóa nội dung của các textbox mật khẩu
            OldpassBox.Clear();
            PassBox.Clear();
            ReEnterPasswordBox.Clear();
        }
    }
    

}
