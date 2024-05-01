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

namespace loginIndian.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BackToRegisterBtn_Click(object sender, EventArgs e)
        {
            Hide();
            RegisterForm form = new RegisterForm();
            form.ShowDialog();
            Close();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UserBox.Text.Trim();
            string password = PassBox.Text;

            var db = FirestoreHelper.Database;
            DocumentReference docRef = db.Collection("UserData").Document(username);
            UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();
            if (data != null ) 
            {
                if (password == Security.Decrypt(data.Password))
                {
                    MessageBox.Show("Success");
                }
                else 
                {
                    MessageBox.Show("Failed");
                }
            }

            else
            {
                MessageBox.Show("Failed");
            }
        }
    }
}
