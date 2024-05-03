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
        int enterout = 0;
        bool checkTimeout()
        {
            if (enterout == 3)
            {
                return true;
            }
            return false;
        }

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
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("User/Password missing!");
                enterout += 1;

            }
            else 
            {
                DocumentReference docRef = db.Collection("UserData").Document(username);
                UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();
                if (data != null)
                {
                    if (password == Security.Decrypt(data.Password))
                    {
                        MessageBox.Show("Success");
                    }
                    else
                    {
                        MessageBox.Show("Failed");
                        enterout += 1;
                    }
                }

                else
                {
                    MessageBox.Show("Failed");
                    enterout += 1;
                }
            }

            if (checkTimeout())  // Check for termination condition
            {
                MessageBox.Show("You reach out the maximum attemps! Program Exit!");
                Environment.Exit(1); // Forcefully exit the program
            }
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
            Hide();
            ForgottenPassword form = new ForgottenPassword();
            form.ShowDialog();
            Close();
        }
    }
}
