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

namespace loginIndian.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void BackToLoginBtn_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm form = new LoginForm();
            form.ShowDialog();
            Close();
        }

        private void RegBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return; // Early exit if validation fails

            var db = FirestoreHelper.Database;

            if (CheckIfUserAlreadyExist())
            {
                MessageBox.Show("User Already Exist");
                return;
            }

            var data = GetWriteData();
            DocumentReference docRef = db.Collection("UserData").Document(data.Username);
            docRef.SetAsync(data);
            MessageBox.Show("success");
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
            Regex phoneRegex = new Regex(@"^\d{10}$");
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

        private bool CheckIfUserAlreadyExist()
        {
            string username = UserBox.Text.Trim();

            var db = FirestoreHelper.Database;
            DocumentReference docRef = db.Collection("UserData").Document(username);
            UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();
            if (data != null)
            {
                return true;
            }
            return false;
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
