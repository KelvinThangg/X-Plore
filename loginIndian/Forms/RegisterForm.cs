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

        private UserData GetWriteData()
        {          
            string username = UserBox.Text.Trim();
            string password  = Security.Encrypt(PassBox.Text);
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
    }
}
