using Google.Cloud.Firestore;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace loginIndian.Forms
{
    public partial class ForgottenPassword : Form
    {
        private System.Windows.Forms.Timer codeExpiryTimer;
        private const int CODE_EXPIRY_SECONDS = 60;
        public ForgottenPassword()
        {
            InitializeComponent();
            InitializeCodeExpiryTimer();
        }
 
        int enterout = 0;
        string verificationCode = GenerateCode.CreateVerificationCode(4, GenerateCode.VerificationType.Alphanumeric);
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

        private async void button1_Click_1(object sender, EventArgs e)
        {

            var db = FirestoreHelper.Database;

            if (string.IsNullOrEmpty(registerMailBox.Text))
            {
                MessageBox.Show("Enter Recovery Mail!");
                enterout += 1;

            }
            else
            {
                if (await CheckIfUserAlreadyExist())
                {
                    string from, pass, mail;
                    string to = registerMailBox.Text;
                    from = "khabanhpro135@gmail.com";
                    mail = verificationCode;
                    //pass = "xhkq hhfn tkkh lpuu";//Your app pass;
                    pass = "aavy rpyg xlhx atdo";
                    MailMessage message = new MailMessage();
                    message.To.Add(to);
                    message.From = new MailAddress(from);
                    message.Body = "Your Recovery code: " + mail;
                    message.Subject = "Xplore - Recovery Code";
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    try
                    {
                        smtp.Send(message);
                        MessageBox.Show("Code send successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sendBtn.Enabled = false;
                        recoveryCodeBox.Enabled = true;
                        confirmBtn.Enabled = true;
                        codeExpiryTimer.Start(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    if (!emailRegex.IsMatch(registerMailBox.Text.Trim()))
                    {
                        MessageBox.Show("Invalid email format.");
                    }
                    else
                    {
                        MessageBox.Show("User Non-Exist");
                        return;
                    }
                }

            }
        }


        private async Task<bool> CheckIfUserAlreadyExist()
        {
            string mail = registerMailBox.Text;

            var db = FirestoreHelper.Database;

            // Truy vấn để lấy tài liệu có trường 'Email' khớp với email người dùng
            Query query = db.Collection("UserData").WhereEqualTo("Email", mail);
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            // Kiểm tra xem có tài liệu nào được trả về hay không
            return querySnapshot.Documents.Count > 0;
        }

        private void CodeExpiryTimer_Tick(object sender, EventArgs e)
        {

            codeExpiryTimer.Stop(); 
            verificationCode = GenerateCode.CreateVerificationCode(4, GenerateCode.VerificationType.Alphanumeric); // New code
            MessageBox.Show("Verification code expired! Exit");
            Environment.Exit(1); 
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(recoveryCodeBox.Text))
            {
                MessageBox.Show("Enter code!");
                enterout += 1;
            }
            if (recoveryCodeBox.Text == verificationCode)
            {
                MessageBox.Show("Success");
                codeExpiryTimer.Stop();
                Hide();
                UpdatePassword form = new UpdatePassword(registerMailBox.Text);
                form.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Wrong code!");
                enterout += 1;
            }
            if (checkTimeout())  
            {
                MessageBox.Show("You reach out the maximum attemps! Program Exit!");
                Environment.Exit(1);
            }
        }

        private void BacktologinBtn_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm form = new LoginForm("");
            form.ShowDialog();
            Close();
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            Hide();
            Help form = new Help();
            form.ShowDialog();
            Close();
        }
    }
}
