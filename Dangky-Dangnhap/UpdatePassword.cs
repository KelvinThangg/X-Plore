using Google.Cloud.Firestore;
using loginIndian.Classes;
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

namespace X_Plore.Dangky_Dangnhap
{
    public partial class UpdatePassword : Form
    {

        private string userEmail;

        public UpdatePassword(string userEmail)
        {
            InitializeComponent();
            this.userEmail = userEmail;
            UserBox.Text = userEmail;
        }

        private bool ValidateFields()
        {
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

        private async void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            var db = FirestoreHelper.Database;
            try
            {
                var query = db.Collection("UserData").WhereEqualTo("Email", userEmail);

                var querySnapshot = await query.GetSnapshotAsync();

                // Update the password if the user exists
                if (querySnapshot.Count > 0)
                {
                    DocumentReference docRef = querySnapshot.Documents[0].Reference;
                    await docRef.UpdateAsync("Password", Security.Encrypt(PassBox.Text));
                    MessageBox.Show("Password updated successfully!");
                    Hide();
                   FormDangNhap form = new FormDangNhap("");
                    form.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("User not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating password: {ex.Message}");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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

    }
}
