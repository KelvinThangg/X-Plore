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

        private void DisplayLbl_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Hide();
            Home home = new Home(username); // Tạo instance Home Form
            home.TopLevel = false; // Thiết lập Home Form không phải top-level form
            home.FormBorderStyle = FormBorderStyle.None; // Loại bỏ border của Home Form
            home.Dock = DockStyle.Fill; // Cho Home Form lấp đầy Panel chứa nó
            panel1.Controls.Add(home); // Thêm Home Form vào Panel
            home.Show(); // Hiển thị Home Form
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
