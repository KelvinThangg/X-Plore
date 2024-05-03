using Google.Cloud.Firestore;
using loginIndian.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace loginIndian.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }
        int Uuser = 0;
        int Uphone = 0;
        int Umail = 0;
        private void BackToLoginBtn_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm form = new LoginForm();
            form.ShowDialog();
            Close();
        }

        private async void RegBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserBox.Text) || string.IsNullOrEmpty(PassBox.Text) || string.IsNullOrEmpty(EmailBox.Text) || string.IsNullOrEmpty(TelBox.Text) || GenBox.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                if (!ValidateFields()) return; // Early exit if validation fails

                var db = FirestoreHelper.Database;

                if (await CheckIfUserAlreadyExist())
                {
                    if (Uuser!=0) 
                    {
                        MessageBox.Show("User already Exist");
                    }
                    if (Umail!=0)
                    {
                        MessageBox.Show("Mail already used");
                    }
                    if (Uphone!=0)
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
                //EmailVerify form = new EmailVerify(data.Email);
                EmailVerify form = new EmailVerify(data.Email, data.Username);
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
            Regex passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
            if (!passwordRegex.IsMatch(PassBox.Text))
            {
                MessageBox.Show("Password must contain at least 8 characters, one uppercase letter, one lowercase letter, one number, and one special character.");
                return false;
            }

            if (ReEnterPasswordBox.Text != PassBox.Text)
            {
                MessageBox.Show("The passwords you entered do not match. Please try again.");
                return false;
            }

            return true; // All validations passed
        }
        private UserData GetWriteData()
        {
            string username = UserBox.Text.Trim();
            string password = Security.Encrypt(PassBox.Text);
            string repassword = Security.Encrypt(ReEnterPasswordBox.Text);
            string gender = GenBox.Text.Trim();
            string email = EmailBox.Text.Trim();
            string phone = TelBox.Text.Trim();
            return new UserData()
            {
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

            return false; // No duplicates found
        }
        
        private void showPassBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassBox.Checked==true)
            {
                PassBox.UseSystemPasswordChar = false;
            }
            else
            {
                PassBox.UseSystemPasswordChar = true;
            }
        }
        
    }
}
