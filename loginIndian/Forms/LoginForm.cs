using Google.Cloud.Firestore;
using loginIndian.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Newtonsoft.Json; // Add this for JSON serialization
using Google.Apis.Auth.OAuth2;
using Google.Apis.PeopleService.v1;
using Google.Apis.Services;
using Google.Api.Gax;
using Google.Apis.Util;
using Google.Apis.Gmail.v1;
using Google.Apis.PeopleService.v1.Data;
using Google.Apis.Util.Store;
using System.Diagnostics;

namespace loginIndian.Forms
{
    public partial class LoginForm : Form
    {
       
        //private string userName;
        private System.Windows.Forms.Timer codeExpiryTimer;
        private const int CODE_EXPIRY_SECONDS = 60;
        int enterout = 0;
        bool checkTimeout()
        {
            if (enterout == 3)
            {
                return true;
            }
            return false;
        }

        private Captcha captcha;
        private PictureBox captchaPictureBox; // Add PictureBox for displaying captcha

        public LoginForm(string username)
        {
            InitializeComponent();
            InitializeCodeExpiryTimer();
            codeExpiryTimer.Start();
            // Subscribe to the event from EmailVerify
            this.UserBox.Text = username;
            if (username != null)
            {
                UserBox.Text = username;
                LoadSettings(); // Load settings if username is provided
            }
            // Initialize Captcha
            //pictureBox1 = new PictureBox();
            pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y); // Adjust location as needed
            //pictureBox1.Size = new Size(200, 50);   // Adjust size as needed
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pictureBox1);          // Add to form
            GenerateCaptcha();
            this.Click += ResetTimer;
            this.KeyPress += ResetTimer;
        }
        private void InitializeCodeExpiryTimer()
        {
            codeExpiryTimer = new System.Windows.Forms.Timer();
            codeExpiryTimer.Interval = CODE_EXPIRY_SECONDS * 1000;  // 60 seconds
            codeExpiryTimer.Tick += CodeExpiryTimer_Tick;
        }

        private async void CodeExpiryTimer_Tick(object sender, EventArgs e)
        {

            codeExpiryTimer.Stop(); // Stop the timer
            MessageBox.Show("Verification login expired! Exit");
            Environment.Exit(1); // Forcefully exit the program
        }

        private void ResetTimer(object sender, EventArgs e)
        {
            // Restart the timer to reset the countdown
            codeExpiryTimer.Stop();
            codeExpiryTimer.Start();
        }

        private void BackToRegisterBtn_Click(object sender, EventArgs e)
        {
            codeExpiryTimer.Stop();
            Hide();
            RegisterForm form = new RegisterForm();
            form.ShowDialog();
            Close();
        }

        private const string settingsFilePath = @"C:\Users\dadad\OneDrive\Documents\UserData\user_settings.json"; // File to store settings
        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            LoginBtn.Enabled = false;
            BackToRegisterBtn.Enabled = false;
            forgotPassBtn.Enabled = false;
            string username = UserBox.Text.Trim();
            string password = PassBox.Text;
            string captchaInput = captchaTextBox.Text; // Get captcha input

            var db = FirestoreHelper.Database;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("User/Password missing!");
                enterout += 1;
                LoginBtn.Enabled = true;
                BackToRegisterBtn.Enabled = true;
                forgotPassBtn.Enabled = true;
            }
            else
            {
                DocumentReference docRef = db.Collection("UserData").Document(username);
                UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();

                if (data != null)
                {
                    if (password == Security.Decrypt(data.Password) && captchaInput == captcha.Text)
                        if (data.IsLoggedIn == true)
                        {
                            MessageBox.Show("Account already logged in elsewhere.");
                            LoginBtn.Enabled = true;
                            BackToRegisterBtn.Enabled = true;
                            forgotPassBtn.Enabled = true;
                            return; // Prevent login
                        }
                        else
                        {
                            MessageBox.Show("Success");
                            if (checkBox1.Checked)
                            {
                                SaveSettings(username, password); // Save credentials to JSON file
                            }
                            else
                            {
                                ClearSettings(); // Clear saved credentials
                            }
                            codeExpiryTimer.Stop();
                            await docRef.UpdateAsync("isLoggedIn", true);
                            Hide();
                            MainMenu form = new MainMenu(username);
                            form.ShowDialog();
                            Close();
                        }
                    else
                    {
                        //MessageBox.Show("Failed");
                        MessageBox.Show("Invalid captcha or password!");
                        LoginBtn.Enabled = true;
                        BackToRegisterBtn.Enabled = true;
                        forgotPassBtn.Enabled = true;
                        GenerateCaptcha(); // Generate a new captcha on failure
                        enterout += 1;
                    }
                }

                else
                {
                    MessageBox.Show("Failed");
                    LoginBtn.Enabled = true;
                    BackToRegisterBtn.Enabled = true;
                    forgotPassBtn.Enabled = true;
                    enterout += 1;
                }
            }


            if (checkTimeout())  // Check for termination condition
            {
                codeExpiryTimer.Stop();
                MessageBox.Show("You reach out the maximum attemps! Program Exit!");
                LoginBtn.Enabled = true;
                BackToRegisterBtn.Enabled = true;
                forgotPassBtn.Enabled = true;
                Environment.Exit(1); // Forcefully exit the program
            }
        }

        private void GenerateCaptcha()
        {
            captcha = new Captcha(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = captcha.Image;
            pictureBox1.Refresh();
            captchaTextBox.Text = ""; // Clear the input box
        }

        private void showPassBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassBox.Checked == true)
            {
                PassBox.UseSystemPasswordChar = false;
            }
            else
            {
                PassBox.UseSystemPasswordChar = true;
            }
        }

        private void forgotPassBtn_Click(object sender, EventArgs e)
        {
            codeExpiryTimer.Stop();
            Hide();
            ForgottenPassword form = new ForgottenPassword();
            form.ShowDialog();
            Close();
        }

        private void SaveSettings(string username, string password)
        {
            var settings = new { RememberMe = true, Username = username, Password = password };
            File.WriteAllText(settingsFilePath, JsonConvert.SerializeObject(settings));
        }

        private void LoadSettings()
        {
            if (File.Exists(settingsFilePath))
            {
                var settings = JsonConvert.DeserializeAnonymousType(
                    File.ReadAllText(settingsFilePath),
                    new { RememberMe = false, Username = "", Password = "" }
                );

                // Check if RememberMe is true AND the saved username matches the current input
                if (settings.RememberMe && settings.Username == UserBox.Text)
                {
                    PassBox.Text = settings.Password;
                    //checkBox1.Checked = true;
                }
            }
        }

        private void ClearSettings()
        {
            if (File.Exists(settingsFilePath))
            {
                File.Delete(settingsFilePath);
            }
        }

        private void User(object sender, EventArgs e)
        {
            if (File.Exists(settingsFilePath))
            {
                var settings = JsonConvert.DeserializeAnonymousType(
                    File.ReadAllText(settingsFilePath),
                    new { RememberMe = false, Username = "", Password = "" }
                );
                if (settings.RememberMe && settings.Username == UserBox.Text)
                {
                    PassBox.Text = settings.Password;
                    //checkBox1.Checked = true;
                }
                else { ClearSettings(); }
            }
        }

        private void UserBox_Leave(object sender, EventArgs e)
        {
            if (File.Exists(settingsFilePath))
            {
                var settings = JsonConvert.DeserializeAnonymousType(
                    File.ReadAllText(settingsFilePath),
                    new { RememberMe = false, Username = "", Password = "" }
                );

                if (settings.RememberMe && settings.Username == UserBox.Text)
                {
                    PassBox.Text = settings.Password;
                    // checkBox1.Checked = true;
                }
                else
                {
                    //ClearSettings();
                }
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                lblCapsLockStatus.Text = "Caps Lock đang bật";
                lblCapsLockStatus.Visible = true;
            }
            else
            {
                lblCapsLockStatus.Visible = false; // Ẩn khi Caps Lock tắt
            }
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

            // Kiểm tra số điện thoại
            var phoneQuery = db.Collection("UserData").WhereEqualTo("Phone", phone);
            var phoneSnapshot = await phoneQuery.GetSnapshotAsync();
            if (phoneSnapshot.Count > 0)
            {
                return true; // Số điện thoại đã tồn tại
            }

            return false; // Không tìm thấy bản ghi nào
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


        private async void signInGGbtn_Click(object sender, EventArgs e)
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
                                MessageBox.Show("Người dùng không tồn tại!");
                                return;
                               
                            }
                            else
                            {
                                var db = FirestoreHelper.Database;
                                DocumentReference docRef = db.Collection("UserData").Document(name);
                                await docRef.UpdateAsync("isLoggedIn", true);
                                MessageBox.Show("Đăng nhập thành công!");
                                codeExpiryTimer.Stop(); // Stop the timer
                                Hide();
                                MainMenu form = new MainMenu(name);
                                form.ShowDialog();
                                Close();
                            }

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
