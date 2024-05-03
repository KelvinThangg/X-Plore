using Google.Cloud.Firestore;
using loginIndian.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginIndian.Forms
{
    public partial class EmailVerify : Form
    {
        private System.Windows.Forms.Timer codeExpiryTimer;
        private const int CODE_EXPIRY_SECONDS = 60;
        private string userEmail;
        private string userName;
        string verificationCode = GenerateCode.CreateVerificationCode(4, GenerateCode.VerificationType.Alphanumeric);

        public EmailVerify(string userEmail, string userName)
        {
            InitializeComponent();
            this.userEmail = userEmail;
            this.userName = userName;
            NotifcationTxT.Text = " Sending mail to: " + userEmail;
            InitializeCodeExpiryTimer(); // Initialize the timer
        }
        int flag = 0;
        int codeSended = 0;
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

        private const string FIREBASE_DATABASE_URL = "your_firebase_database_url"; // Replace with your URL

        private async void confirmBtn_Click(object sender, EventArgs e)
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
                flag += 1;
            }
            else
            {
                MessageBox.Show("Wrong Code!");
                enterout += 1;
            }
            if (checkTimeout())  // Check for termination condition
            {
                MessageBox.Show("You reach out the maximum attemps! Program Exit!");
                await DeleteUserData();
                Environment.Exit(1); // Forcefully exit the program
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            string from, pass, mail;
            string to = userEmail;
            from = "khabanhpro135@gmail.com";//Your gmail;
            mail = verificationCode;
            pass = "xhkq hhfn tkkh lpuu";//Your app pass;
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = "Your verify code: " + mail;
            message.Subject = "Xplore - Vertification Code";//Mail subject
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
                codeExpiryTimer.Start(); // Start the timer
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task DeleteUserData()
        {
            FirestoreDb db = FirestoreHelper.Database;

            try
            {
                DocumentReference docRef = db.Collection("UserData").Document(userName);
                await docRef.DeleteAsync();
                MessageBox.Show("Registration failed!"); // Optional success message
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private async void CodeExpiryTimer_Tick(object sender, EventArgs e)
        {

            codeExpiryTimer.Stop(); // Stop the timer
            verificationCode = GenerateCode.CreateVerificationCode(4, GenerateCode.VerificationType.Alphanumeric); // New code
            MessageBox.Show("Verification code expired! Exit");
            await DeleteUserData();
            Environment.Exit(1); // Forcefully exit the program
        }

        private async void EmailVerify_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (flag != 1)
            {
                await DeleteUserData();
            }
        }
    }
}
