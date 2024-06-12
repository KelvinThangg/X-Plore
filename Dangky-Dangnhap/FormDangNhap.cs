using Google.Apis.Auth.OAuth2;
using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Cloud.Firestore;
using loginIndian.Classes;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using X_Plore.Dangky_Dangnhap;
using System.Drawing;
using X_Plore.Main;

namespace X_Plore
{
    public partial class FormDangNhap : Form
    {
        private System.Windows.Forms.Timer codeExpiryTimer;
        private const int CODE_EXPIRY_SECONDS = 60;
        int enterout = 0;

        bool checkTimeout()
        {
            return enterout == 3;
        }

        private Captcha captcha;
        private PictureBox captchaPictureBox;
        private string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private const string googleCredsFolder = "X_Plore\\GoogleCredentials";
        private string googleCredsPath;
        private string clientSecretPath;

        public FormDangNhap(string username)
        {
            InitializeComponent();
            googleCredsPath = Path.Combine(appDataPath, googleCredsFolder);
            clientSecretPath = Path.Combine(Application.StartupPath, "client_secret.json");
            InitializeCodeExpiryTimer();
            PassBox.UseSystemPasswordChar = true;
            codeExpiryTimer.Start();
            this.UserBox.Text = username;
            if (username != null)
            {
                UserBox.Text = username;
                LoadSettings();
            }
            captchaPictureBox = new PictureBox
            {
                Location = new Point(100, 100),
                Size = new Size(200, 50)
            };
            this.Controls.Add(captchaPictureBox);
            GenerateCaptcha();
            this.Click += ResetTimer;
            this.KeyPress += ResetTimer;
        }

        private void InitializeCodeExpiryTimer()
        {
            codeExpiryTimer = new System.Windows.Forms.Timer();
            codeExpiryTimer.Interval = CODE_EXPIRY_SECONDS * 1000;
            codeExpiryTimer.Tick += CodeExpiryTimer_Tick;
        }

        private async void CodeExpiryTimer_Tick(object sender, EventArgs e)
        {
            codeExpiryTimer.Stop();
           // MessageBox.Show("Verification login expired! Exit");
           // Environment.Exit(1);
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
            FormDangKy form = new FormDangKy();
            form.ShowDialog();
            Close();
        }

        private const string settingsFilePath = "user_settings.json";

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
                    {
                        if (data.IsLoggedIn == true)
                        {
                            MessageBox.Show("Account already logged in elsewhere.");
                            LoginBtn.Enabled = true;
                            BackToRegisterBtn.Enabled = true;
                            forgotPassBtn.Enabled = true;
                            return;
                        }
                        else if (data.Is2FAEnabled)
                        {
                            _2FAMailVerify form2 = new _2FAMailVerify(data.Email, username);
                            form2.ShowDialog();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Success");
                            if (checkBox1.Checked)
                            {
                                SaveSettings(username, password);
                            }
                            else
                            {
                                ClearSettings();
                            }
                            codeExpiryTimer.Stop();
                            await docRef.UpdateAsync("isLoggedIn", true);
                            Hide();
                            X_Plore.Main.MainMenu form = new X_Plore.Main.MainMenu(DisplayName, username);
                            form.ShowDialog();
                            Close();
                        }
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
                MessageBox.Show("You reach out the maximum attempts! Program Exit!");
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
            Form_QuenMK form = new Form_QuenMK();
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

        private async Task<bool> CheckIfUserExists(string email)
        {
            var db = FirestoreHelper.Database;
            var emailQuery = db.Collection("UserData").WhereEqualTo("Email", email);
            var emailSnapshot = await emailQuery.GetSnapshotAsync();
            if (emailSnapshot.Count > 0)
            {
                return true;
            }
            return false;
        }

        private async Task ClearStoredCredentialsAsync()
        {
            if (Directory.Exists(googleCredsPath))
            {
                Directory.Delete(googleCredsPath, true);
            }
            await Task.Yield();
        }

        private async void guna2TileButton1_Click(object sender, EventArgs e)
        {
            try
            {
                await ClearStoredCredentialsAsync();
                UserCredential credential;
                using (var stream = new FileStream(clientSecretPath, FileMode.Open, FileAccess.Read))
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
                        new FileDataStore(googleCredsPath, true));
                }
                if (credential != null)
                {
                    using (var peopleService = new PeopleServiceService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "GoogleLoginWinforms",
                    }))
                    {
                        PeopleResource.GetRequest peopleRequest = peopleService.People.Get("people/me");
                        peopleRequest.RequestMaskIncludeField = "person.names,person.emailAddresses,person.genders,person.phoneNumbers";
                        Person profile = await peopleRequest.ExecuteAsync();
                        if (profile != null)
                        {
                            string name = profile.Names?.FirstOrDefault()?.DisplayName ?? "Unknown";
                            string email = profile.EmailAddresses?.FirstOrDefault()?.Value ?? "Unknown";
                            string gender = profile.Genders?.FirstOrDefault()?.Value ?? "Unknown";
                            string phoneNumber = profile.PhoneNumbers?.FirstOrDefault()?.Value ?? "Unknown";
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
                                    bool Is2FAEnabled = document.GetValue<bool>("2FAEnable");
                                    string Email = document.GetValue<string>("Email");
                                    if (snapshot.Documents.Count > 0)
                                    {
                                        DocumentReference docRef = snapshot.Documents[0].Reference;
                                        await docRef.UpdateAsync("isLoggedIn", true);
                                        MessageBox.Show("Đăng nhập thành công!");
                                        codeExpiryTimer.Stop();
                                        Hide();
                                        X_Plore.Main.MainMenu form = new X_Plore.Main.MainMenu(Displayname, Username);
                                        form.ShowDialog();
                                        Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("User not found.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"An error occurred: {ex.Message}");
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void signInGGbtn_Click_1(object sender, EventArgs e)
        {

        }
    }
}