using Google.Cloud.Firestore;
using Guna.UI2.WinForms;
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
using X_Plore.Chat;

namespace X_Plore.Main
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

            // Listen for changes in Firestore
            ListenForDisplayNameChanges();

            // Handle form resize event to resize the panel and contained controls
            this.Resize += new EventHandler(MainMenu_Resize);
        }

        private async void ListenForDisplayNameChanges()
        {
            var db = FirestoreHelper.Database;
            DocumentReference docRef = db.Collection("UserData").Document(username);
            docRef.Listen(snapshot =>
            {
                if (snapshot.Exists)
                {
                    Dictionary<string, object> user = snapshot.ToDictionary();
                    if (user.ContainsKey("DisplayName"))
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            // Update DisplayLbl with the new displayName
                            DisplayLbl.Text = user["DisplayName"].ToString();
                        });
                    }
                }
            });
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
                FormDangNhap form = new FormDangNhap(username);
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
            // Hide unnecessary controls
            guna2PictureBox2.Hide();

            // Create instance of HomeScreen
            HomeScreen home = new HomeScreen(username);
            home.TopLevel = false;
            home.FormBorderStyle = FormBorderStyle.None;
            home.Dock = DockStyle.Fill;

            // Clear previous controls in panel1
            panel1.Controls.Clear();

            // Add HomeScreen to panel1
            panel1.Controls.Add(home);
            home.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainMenu_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate(); // Forces the panel to redraw itself
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            /* InviteUser inviteUserForm = new InviteUser(username,displayname);

             // Mở form InviteUser
             inviteUserForm.ShowDialog();*/
            guna2PictureBox2.Hide();

            General general = new General(username, displayname);
            general.TopLevel = false;
            general.FormBorderStyle = FormBorderStyle.None;
            general.AutoScaleMode = AutoScaleMode.Font; // Ensure consistent scaling
            general.Margin = new Padding(0);          // Remove default margins

            panel1.Controls.Clear();
            panel1.Controls.Add(general);

            general.ClientSize = panel1.ClientSize;   // Set size before docking
            general.Dock = DockStyle.Fill;

            general.Show();
        }

        private void guna2TileButton5_Click(object sender, EventArgs e)
        {
            // Hide unnecessary controls
            guna2PictureBox2.Hide();

            // Create instance of HomeScreen
            FeedBack feedback = new FeedBack(displayname, username);
            feedback.TopLevel = false;
            feedback.FormBorderStyle = FormBorderStyle.None;
            feedback.Dock = DockStyle.Fill;

            // Clear previous controls in panel1
            panel1.Controls.Clear();

            // Add HomeScreen to panel1
            panel1.Controls.Add(feedback);
            feedback.Show();
        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            guna2PictureBox2.Hide();
            MaHoaFile mahoa = new MaHoaFile();
            mahoa.TopLevel = false;
            mahoa.FormBorderStyle = FormBorderStyle.None;
            mahoa.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(mahoa);
            mahoa.Show();

        }
    }
}
