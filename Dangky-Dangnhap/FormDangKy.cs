using Google.Cloud.Firestore;
using loginIndian.Classes;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Google.Apis.Auth.OAuth2;
using Google.Apis.PeopleService.v1;
using Google.Apis.Services;
using Google.Api.Gax;
using Google.Apis.Util;
using Google.Apis.Gmail.v1;
using Google.Apis.PeopleService.v1.Data;
using Google.Apis.Util.Store;
using System.IO;
using System.Diagnostics;
using X_Plore.Dangky_Dangnhap;

namespace X_Plore
{
    public partial class FormDangKy : Form
    {
        private bool isLoggedIn = false;

        public FormDangKy()
        {
            InitializeComponent();
        }

        int Uuser = 0;
        int Uphone = 0;
        int Umail = 0;
        private void BackToLoginBtn_Click(object sender, EventArgs e)
        {
            Hide();
            FormDangNhap form = new FormDangNhap("");
            form.ShowDialog();
            Close();
        }

        private async void RegBtn_Click(object sender, EventArgs e)
        {
            Uuser = 0;
            Uphone = 0;
            Umail = 0;

            if (string.IsNullOrEmpty(displayNameBox.Text) || string.IsNullOrEmpty(UserBox.Text) || string.IsNullOrEmpty(PassBox.Text) || string.IsNullOrEmpty(EmailBox.Text) || string.IsNullOrEmpty(TelBox.Text) || GenBox.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                if (!ValidateFields()) return;

                var db = FirestoreHelper.Database;

                if (await CheckIfUserAlreadyExist())
                {
                    if (Uuser != 0)
                    {
                        MessageBox.Show("User already Exist");
                    }
                    if (Umail != 0)
                    {
                        MessageBox.Show("Mail already used");
                    }
                    if (Uphone != 0)
                    {
                        MessageBox.Show("Phone numbers already used");
                    }
                    return;
                }

                var data = GetWriteData();
                DocumentReference docRef = db.Collection("UserData").Document(data.Username);
                docRef.SetAsync(data);
                MessageBox.Show("success");
                Hide();
               Xac_thuc_dky form = new Xac_thuc_dky(data.Email, UserBox.Text.Trim());
               FormDangNhap form1 = new(data.Username);
                form.ShowDialog();
                Close();

            }
        }

        private bool ValidateFields()
        {
            // Email validation
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!emailRegex.IsMatch(EmailBox.Text.Trim()))
            {
                MessageBox.Show("Invalid email format.");
                return false; ;
            }

            // Phone number validation (Modify the regex as needed for your format)
            Regex phoneRegex = new Regex(@"^\d{9,11}$");
            if (!phoneRegex.IsMatch(TelBox.Text.Trim()))
            {
                MessageBox.Show("Invalid phone number format.");
                return false;
            }

            // Password validation
            if (ReEnterPasswordBox.Text != PassBox.Text)
            {
                MessageBox.Show("The passwords you entered do not match. Please try again.");
                return false;
            }

            Regex passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
            if (!passwordRegex.IsMatch(PassBox.Text))
            {
                MessageBox.Show("Password must contain at least 8 characters, one uppercase letter, one lowercase letter, one number, and one special character.");
                return false;
            }

            return true;
        }
        private UserData GetWriteData()
        {
            string displayname = displayNameBox.Text.Trim();
            string username = UserBox.Text.Trim();
            string password = Security.Encrypt(PassBox.Text);
            string repassword = Security.Encrypt(ReEnterPasswordBox.Text);
            string gender = GenBox.Text.Trim();
            string email = EmailBox.Text.Trim();
            string phone = TelBox.Text.Trim();
            return new UserData()
            {
                DisplayName = displayname,
                Username = username,
                Password = password,
                Gender = gender,
                Email = email,
                Phone = phone,
            };
        }

        private async Task<bool> CheckIfUserAlreadyExist()
        {
            string username = UserBox.Text.Trim();
            string email = EmailBox.Text.Trim();
            string phone = TelBox.Text.Trim();
            var db = FirestoreHelper.Database;

            // Check for existing User
            DocumentReference docRef = db.Collection("UserData").Document(username);
            UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();
            if (data != null)
            {
                Uuser += 1;
                return true; // User exists
            }

            // Check for existing email
            var emailQuery = db.Collection("UserData").WhereEqualTo("Email", email);
            var emailSnapshot = await emailQuery.GetSnapshotAsync();
            if (emailSnapshot.Count > 0)
            {
                Umail += 1;
                return true; // Email exists
            }

            // Check for existing phone
            var phoneQuery = db.Collection("UserData").WhereEqualTo("Phone", phone);
            var phoneSnapshot = await phoneQuery.GetSnapshotAsync();
            if (phoneSnapshot.Count > 0)
            {
                Uphone += 1;
                return true; // Phone exists
            }

            return false;
        }

        private void showPassBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassBox.Checked == true)
            {
                PassBox.UseSystemPasswordChar = false;
                ReEnterPasswordBox.UseSystemPasswordChar = false;
            }
            else
            {
                PassBox.UseSystemPasswordChar = true;
                ReEnterPasswordBox.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            displayNameBox.Text = "Đại";
            UserBox.Text = "dai";
            PassBox.Text = "123abcA!";
            ReEnterPasswordBox.Text = "123abcA!";
            GenBox.Text = "Male";
            EmailBox.Text = "foundai1314@gmail.com";
            TelBox.Text = "999999999";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            displayNameBox.Text = "ADMINISTRATOR";
            UserBox.Text = "admin";
            PassBox.Text = "123abcA!";
            ReEnterPasswordBox.Text = "123abcA!";
            GenBox.Text = "Male";
            EmailBox.Text = "fuondai1314@gmail.com";
            TelBox.Text = "9999999999";
        }

        private async Task ClearStoredCredentialsAsync()
        {
            string credPath = @"C:\Users\dadad\source\repos\loginIndian - Final\bin\Debug\net8.0-windows\SigninwithGG";
            if (Directory.Exists(credPath))
            {
                Directory.Delete(credPath, true);
            }

            await Task.Yield(); // Đảm bảo thư mục được xóa bất đồng bộ
        }

        private async Task<bool> CheckIfUserExists(string email, string phone)
        {
            var db = FirestoreHelper.Database;

            // Kiểm tra email
            var emailQuery = db.Collection("UserData").WhereEqualTo("Email", email);
            var emailSnapshot = await emailQuery.GetSnapshotAsync();
            if (emailSnapshot.Count > 0)
            {
                return true; // Email đã tồn tại
            }

            return false; // Không tìm thấy bản ghi nào
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa thông tin đăng nhập trước đó
                await ClearStoredCredentialsAsync();

                // Thực hiện quá trình đăng nhập mới
                UserCredential credential;
                using (var stream = new FileStream(@"C:\Users\dadad\Downloads\client_secret_716693675227-0huu2ruuqr969vbmujlmed2ulju8qle8.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read))
                {
                    string[] scopes = {
                PeopleServiceService.Scope.UserinfoProfile,
                PeopleServiceService.Scope.UserinfoEmail,
                "https://www.googleapis.com/auth/user.phonenumbers.read"
            };

                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore("SigninwithGG", true));
                }

                if (credential != null)
                {
                    using (var peopleService = new PeopleServiceService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "GoogleLoginWinforms",
                    }))
                    {
                        // Request thông tin người dùng
                        PeopleResource.GetRequest peopleRequest = peopleService.People.Get("people/me");
                        peopleRequest.RequestMaskIncludeField = "person.names,person.emailAddresses,person.genders,person.phoneNumbers";
                        Person profile = await peopleRequest.ExecuteAsync();

                        if (profile != null)
                        {
                            string name = profile.Names?.FirstOrDefault()?.DisplayName ?? "Unknown";
                            string email = profile.EmailAddresses?.FirstOrDefault()?.Value ?? "Unknown";
                            string gender = profile.Genders?.FirstOrDefault()?.Value ?? "Unknown";
                            string phoneNumber = profile.PhoneNumbers?.FirstOrDefault()?.Value ?? "Unknown";

                            // Kiểm tra người dùng đã tồn tại chưa
                            if (!await CheckIfUserExists(email, phoneNumber))
                            {
                                // Nếu chưa tồn tại thì ghi thông tin mới vào database
                                var newUser = new UserData()
                                {
                                    DisplayName = name,
                                    Username = name,
                                    Email = email,
                                    Gender = gender,
                                    Phone = phoneNumber
                                };

                                var db = FirestoreHelper.Database;
                                DocumentReference docRef = db.Collection("UserData").Document(name);
                                await docRef.SetAsync(newUser);

                                MessageBox.Show($"Đăng ký thành công! Name: {name}, Email: {email}, Gender: {gender}, Phone Number: {phoneNumber}");
                                MessageBox.Show($"Vui lòng tạo mật khẩu mới!");
                                Hide();
                                UpdatePassword form = new UpdatePassword(email);
                                form.ShowDialog();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Người dùng đã tồn tại.");
                            }

                            // Đặt trạng thái đăng nhập thành true
                            isLoggedIn = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không thể lấy thông tin đăng nhập. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đăng nhập: {ex.Message}");
            }
        }
    }


}

