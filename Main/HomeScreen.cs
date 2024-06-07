using Google.Cloud.Firestore;
using loginIndian.Classes;
using Microsoft.CodeAnalysis.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System.IO;
using Amazon.SecurityToken;
using System.Net;
using X_Plore.Chat;

namespace X_Plore.Main
{
    public partial class HomeScreen : Form
    {
        private string username;
        private string displayname;

        private bool isButtonEnabled = true;
        public HomeScreen(string username)
        {
            this.username = username;
         
            InitializeComponent();
            panelDoipass.Hide();
            NhapPassPn.Hide();
            LoadAvatarFromS3();


            // Check and update 2FA status when the form loads
            CheckAndUpdate2FAStatus();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

     private async void CheckAndUpdate2FAStatus()
        {
            UserData userData = await GetCurrentUserData();
            UpdateTrangthaiLabel(userData.Is2FAEnabled);
        }




        private void UpdateTrangthaiLabel(bool is2FAEnabled)
        {
            Trangthai.ForeColor = is2FAEnabled ? Color.Green : Color.Red;
            Trangthai.Text = is2FAEnabled ? "Đang bật" : "Đang tắt";
        }
        private GroupChat_Member FindOpenGroupChatMemberForm()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is GroupChat_Member memberForm)
                {
                    return memberForm;
                }
            }
            return null; // Or handle the case where the form isn't found
        }
        private async void ChangeDisplaynameBtn_Click(object sender, EventArgs e)
        {
             string oldName = displayname;
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
            GroupChat_Member groupChatMemberForm = FindOpenGroupChatMemberForm();

            // If the form is found, update the messages
            if (groupChatMemberForm != null)
            {
                groupChatMemberForm.UpdateDisplayedMessagesForNameChange(oldName, newDisplayName);
            }
            else
            {
                // Handle the case where the form is not found
                MessageBox.Show("Group chat form not found!");
            }

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

        private async void confirmBtn1_Click(object sender, EventArgs e)
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

        private async void twofaBtn_Click(object sender, EventArgs e)
        {
            panelDoipass.Hide();
            UserData userData = await GetCurrentUserData();
            bool is2FAEnabled = userData.Is2FAEnabled;
            if (is2FAEnabled)
            {
                // Tắt 2FA
                NhapPassPn.Show();
                EnterPasstb.Focus();
            }
            else
            {
                // Hiển thị panel nhập mật khẩu
                NhapPassPn.Show();
                EnterPasstb.Focus(); // Đặt focus vào textbox mật khẩu
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NhapPassPn.Hide();
            panelDoipass.Show();
        }
        
        private async void confirmBtn2_Click(object sender, EventArgs e)
        {
            string enteredPassword = EnterPasstb.Text;
            UserData userData = await GetCurrentUserData();
            if (Security.Encrypt(enteredPassword) == userData.Password)
            {
                // Đảo ngược trạng thái 2FA
                userData.Is2FAEnabled = !userData.Is2FAEnabled;

                // Cập nhật text button và ẩn panel
                twofaBtn.Text = userData.Is2FAEnabled ? "Tắt" : "Bật";
                Trangthai.Text = userData.Is2FAEnabled ? "Đang bật" : "Đang tắt";
                Trangthai.ForeColor = userData.Is2FAEnabled ? Color.Green : Color.Red;
                NhapPassPn.Hide();

                await UpdateUserData(userData); // Lưu thay đổi về Firestore
            }
            else
            {
                MessageBox.Show("Mật khẩu không chính xác.");
            }

            EnterPasstb.Clear(); // Xóa mật khẩu đã nhập

        }

        private const string AccessKey = "ASIAZD7PBJSZSNFV2KOG";
        private const string SecretKey = "KZ1eOPdNoq1Fe9+7bcOMfl3sJlI/IDu4secCRAKK";
        private const string SessionToken = "IQoJb3JpZ2luX2VjEPH//////////wEaCXVzLXdlc3QtMiJHMEUCIQDxxBswHFKlZdAxGE0inu6B4Dlre7eGpl9oEPK7MiKe1wIgYkfcy1n5D3sxrHIyUhWRiUBJ1XWNYkzruEhOGz/cWRYqsAIIeRAAGgw2MjcwMjk2NTg4MDMiDNqiw9PpBGswA7gaAiqNAifK+oXYiOwc9LmTKC12v/hVcBjWWQh1xDlkn+I44EMTrmx2EhfFrYSXUQ865Ij6YbU88sOirc3Jzr6wTTfYlBLRp7RmiGZM4eg7NER+Ov1tEY3GKrwdQqOPTs12DjzjufOtX7k66yI8w4jt9/B2Wvt4v9Qr3JdY+C6e6fE7UoD9JslhCLWK+jDElcyjjCKzdZRWuv17RIrQMdKpFBm5IxMfRM0EvhIxrktiX7GsFwMK/bV7EEOmuDuTx2cwo5qkA2EKNu+YVvbeES7nRZ1XZjyKM3SIFqS5s6OPdb0zv+oDolYmYV1C8qjyjs5APr+Vb8j3oHmbMVtp+j+2UcuCS+Qlk23FPhUE5a4gJ52RMK638rIGOp0BinRF+a/mgd2obK18Qn6CaCMOgiV3xAMqBfz+zELY3jSaMPW7QDEfrDFikv/DLAAnslk3nbN0esURT2L08WH2l8SOUkqWma1I6rPgppn+AaltZM4O/idEHaYH7ECkX2PkjDaGDqTZ79AaSJwK1GjwdnFuH50iPaRhAZIi/etNTNB2qX7rxcQDRPmBl0UxAYRVWX4r+4u37wkijwYDCQ==";
        private const string BucketName = "xplorer-bucket"; // Thay thế bằng tên bucket của bạn

        private async void ChangeAvatarBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                Image avatarImage = Image.FromFile(filePath);

                // Cập nhật ảnh trong PictureBox
                guna2CirclePictureBox1.Image = avatarImage;

                // Tải ảnh lên AWS S3
                string avatarUrl = await UploadAvatarToS3(filePath);

                // Lưu URL ảnh vào Firestore
                await UpdateAvatarUrl(avatarUrl);
            }
        }
        private async Task UpdateAvatarUrl(string avatarUrl)
        {
            try
            {
                // Lấy UserData hiện tại dựa trên username
                UserData userData = await GetCurrentUserData();

                // Cập nhật AvatarUrl
                userData.AvatarUrl = avatarUrl;

                // Lưu userData đã cập nhật vào Firestore
                FirestoreHelper.SetEnvironmentVariable(); 
                DocumentReference docRef = FirestoreHelper.Database.Collection("UserData").Document(userData.Username);
                await docRef.SetAsync(userData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật Avatar URL: {ex.Message}");
                // Xử lý lỗi, ví dụ: ghi log hoặc thông báo cho người dùng
            }
        }
        // Hàm tải ảnh lên AWS S3
        private async Task<string> UploadAvatarToS3(string filePath)
        {
            try
            {
                var credentials = new Amazon.Runtime.SessionAWSCredentials(AccessKey, SecretKey, SessionToken);
                var config = new AmazonS3Config
                {
                    RegionEndpoint = RegionEndpoint.USEast1 // Chọn Region của bạn
                };

                using (var client = new AmazonS3Client(credentials, config))
                {
                    var putRequest = new PutObjectRequest
                    {
                        BucketName = BucketName,
                        Key = $"{username}_avatar.png", // Tên tệp tin
                        FilePath = filePath,
                        ContentType = "image/png" // Kiểu dữ liệu ảnh
                    };

                    // Tải ảnh lên S3
                    await client.PutObjectAsync(putRequest);

                    // Trả về URL của ảnh
                    return $"https://{BucketName}.s3.{RegionEndpoint.USEast1}.amazonaws.com/{username}_avatar.png";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải ảnh lên S3: {ex.Message}");
                return null;
            }
        }
        private async Task LoadAvatarFromS3()
        {
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

    }
}
