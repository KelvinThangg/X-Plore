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
    public partial class MainMenu : Form
    {
        private string username;
        private string displayname;

        public MainMenu(string DisplayName, string username)
        {
            InitializeComponent();
            this.username = username;
            this.displayname = DisplayName;
            MessageBox.Show("Welcome: " + DisplayName);
            DisplayLbl.Text = DisplayName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to proceed to the Login page?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var db = FirestoreHelper.Database;
                DocumentReference docRef = db.Collection("UserData").Document(username);
                docRef.UpdateAsync("isLoggedIn", false);
                MessageBox.Show("You are out! Back to Login");
                Hide();
                LoginForm form = new LoginForm(username);
                form.ShowDialog();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit the program?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var db = FirestoreHelper.Database;
                DocumentReference docRef = db.Collection("UserData").Document(username);
                docRef.UpdateAsync("isLoggedIn", false);
                MessageBox.Show("Exit successfully!");
                Environment.Exit(1);
            }
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            var db = FirestoreHelper.Database;
            DocumentReference docRef = db.Collection("UserData").Document(username);
            docRef.UpdateAsync("isLoggedIn", false); 
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            var db = FirestoreHelper.Database;
            DocumentReference docRef = db.Collection("UserData").Document(username);
            docRef.UpdateAsync("isLoggedIn", false);
        }
    }
}
