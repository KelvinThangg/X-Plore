﻿using Google.Cloud.Firestore;
using loginIndian.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginIndian.Forms
{
    public partial class _2FAMailVerify : Form
    {
        public _2FAMailVerify()
        {
            InitializeComponent();
        }

        private System.Windows.Forms.Timer codeExpiryTimer;
        private const int CODE_EXPIRY_SECONDS = 60;
        private string userEmail;
        private string userName;
        string verificationCode = GenerateCode.CreateVerificationCode(4, GenerateCode.VerificationType.Alphanumeric);

        private void GoBackToLoginForm()
        {
            codeExpiryTimer.Stop();
            Hide();
            LoginForm loginForm = new LoginForm(userName);
            loginForm.ShowDialog();
            Close();
        }

        public _2FAMailVerify(string userEmail, string userName)
        {
            InitializeComponent();
            this.userEmail = userEmail;
            this.userName = userName;
            NotifcationTxT.Text = "Sending mail to: " + userEmail;
            InitializeCodeExpiryTimer();
        }

        int flag = 0;
        int enterout = 0;

        bool checkTimeout()
        {
            if (enterout == 3)
            {
                return true;
            }
            return false;
        }

        private void InitializeCodeExpiryTimer()
        {
            codeExpiryTimer = new System.Windows.Forms.Timer();
            codeExpiryTimer.Interval = CODE_EXPIRY_SECONDS * 1000;  // 60 seconds
            codeExpiryTimer.Tick += CodeExpiryTimer_Tick;
        }

        // private const string FIREBASE_DATABASE_URL = "your_firebase_database_url"; // Replace with your URL

        private async void confirmBtn_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(codeBox.Text))
            {
                MessageBox.Show("Enter Code!");
                enterout += 1;
            }
            else
            if (codeBox.Text == verificationCode)
            {
                MessageBox.Show("Success");
                codeExpiryTimer.Stop();
                flag += 1;
                DialogResult result = MessageBox.Show("Verification successful! Do you want to proceed to the Main Menu?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                FirestoreDb db = FirestoreHelper.Database;
                var userDataCollection = db.Collection("UserData");
                if (result == DialogResult.Yes)
                {

                    QuerySnapshot snapshot = await userDataCollection.WhereEqualTo("Email", userEmail).GetSnapshotAsync();
                    DocumentSnapshot document = snapshot.Documents[0];
                    string DisplayName = document.GetValue<string>("DisplayName");

                    codeExpiryTimer.Stop();
                    DocumentReference docRef = db.Collection("UserData").Document(userName);
                    UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();
                    await docRef.UpdateAsync("isLoggedIn", true);
                    Hide();
                    MainMenu form = new MainMenu(DisplayName, userName);
                    form.ShowDialog();
                    Close();
                }
                else
                {
                    GoBackToLoginForm();
                }
            }
            else
            {
                MessageBox.Show("Wrong Code!");
                enterout += 1;
            }
            if (checkTimeout())
            {
                MessageBox.Show("You reach out the maximum attemps! Program Exit!");

                Environment.Exit(1);
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            string from, pass, mail;
            string to = userEmail;
            from = "khabanhpro135@gmail.com";
            mail = verificationCode;
            //pass = "xhkq hhfn tkkh lpuu";//Your app pass;
            pass = "aavy rpyg xlhx atdo";
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = "Your verify code: " + mail;
            message.Subject = "Xplore - Vertification Code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("Code send successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                codeBox.Enabled = true;
                sendBtn.Enabled = false;
                confirmBtn.Enabled = true;
                codeExpiryTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private async void CodeExpiryTimer_Tick(object sender, EventArgs e)
        {

            codeExpiryTimer.Stop();
            verificationCode = GenerateCode.CreateVerificationCode(4, GenerateCode.VerificationType.Alphanumeric); // New code
            MessageBox.Show("Verification code expired! Exit");

            Environment.Exit(1);
        }

        private async void EmailVerify_FormClosed(object sender, FormClosedEventArgs e)
        {
            codeExpiryTimer.Stop();
            if (flag != 1)
            {
                MessageBox.Show("Exit");
                Environment.Exit(1);
            }
        }

       
    }
}


