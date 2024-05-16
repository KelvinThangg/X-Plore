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
using Newtonsoft.Json;
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
        private PictureBox captchaPictureBox;

        public LoginForm(string username)
        {
            InitializeComponent();
            InitializeCodeExpiryTimer();
            codeExpiryTimer.Start();
            this.UserBox.Text = username;
            if (username != null)
            {
                UserBox.Text = username;
                LoadSettings();
            }
            pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);
            this.Controls.Add(pictureBox1);   
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

            codeExpiryTimer.Stop(); 
            MessageBox.Show("Verification login expired! Exit");
            Environment.Exit(1); 
        }

        private void ResetTimer(object sender, EventArgs e)
        {
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
            string captchaInput = captchaTextBox.Text; 
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
                var userDataCollection = db.Collection("UserData");
                QuerySnapshot snapshot = await userDataCollection.WhereEqualTo("Username", username).GetSnapshotAsync();
                DocumentSnapshot document = snapshot.Documents[0];
                string DisplayName = document.GetValue<string>("DisplayName");

                    if (data != null)
                {
                    if (password == Security.Decrypt(data.Password) && captchaInput == captcha.Text)
                        if (data.IsLoggedIn == true)
                        {
                            MessageBox.Show("Account already logged in elsewhere.");
                            LoginBtn.Enabled = true;
                            BackToRegisterBtn.Enabled = true;
                            forgotPassBtn.Enabled = true;
                            return;
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
                                ClearSettings(); 
                            }
                            codeExpiryTimer.Stop();
                            await docRef.UpdateAsync("isLoggedIn", true);
                            Hide();
                            MainMenu form = new MainMenu(DisplayName, username);
                            form.ShowDialog();
                            Close();
                        }
                    else
                    {
                        MessageBox.Show("Invalid captcha or password!");
                        LoginBtn.Enabled = true;
                        BackToRegisterBtn.Enabled = true;
                        forgotPassBtn.Enabled = true;
                        GenerateCaptcha(); 
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


            if (checkTimeout()) 
            {
                codeExpiryTimer.Stop();
                MessageBox.Show("You reach out the maximum attemps! Program Exit!");
                LoginBtn.Enabled = true;
                BackToRegisterBtn.Enabled = true;
                forgotPassBtn.Enabled = true;
                Environment.Exit(1);
            }
        }

        private void GenerateCaptcha()
        {
            captcha = new Captcha(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = captcha.Image;
            pictureBox1.Refresh();
            captchaTextBox.Text = ""; 
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

                if (settings.RememberMe && settings.Username == UserBox.Text)
                {
                    PassBox.Text = settings.Password;
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
                lblCapsLockStatus.Visible = false;
            }
        }


        private async Task<bool> CheckIfUserExists(string email)
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
                            if (!await CheckIfUserExists(email))
                            {
                                MessageBox.Show("Người dùng không tồn tại!");
                                return;
                               
                            }
                            else
                            {
                                var db = FirestoreHelper.Database;
                                var userDataCollection = db.Collection("UserData");
                         
                                try
                                {
                                    QuerySnapshot snapshot = await userDataCollection.WhereEqualTo("Email", email).GetSnapshotAsync();
                                    DocumentSnapshot document = snapshot.Documents[0];
                                    string Displayname = document.GetValue<string>("DisplayName");
                                    string Username = document.GetValue<string>("Username");
                                    if (snapshot.Documents.Count > 0)
                                    {
                                        DocumentReference docRef = snapshot.Documents[0].Reference;
                                    
                                        await docRef.UpdateAsync("isLoggedIn", true);

                                        MessageBox.Show("Đăng nhập thành công!"); // Success message

                                        codeExpiryTimer.Stop();
                                        Hide();

                                        MainMenu form = new MainMenu(Displayname, Username);
                                        form.ShowDialog();
                                        Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("User not found."); // Handle case where user doesn't exist
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"An error occurred: {ex.Message}"); // Catch other general exceptions
                                }
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
