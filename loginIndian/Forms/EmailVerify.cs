using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginIndian.Forms
{
    public partial class EmailVerify : Form
    {
        private string userEmail;
        
        public EmailVerify(string userEmail)
        {
            InitializeComponent();
            this.userEmail = userEmail;
        }
        int vCode = 1000;
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (codeBox.Text == vCode.ToString())
            {
                MessageBox.Show("Success");
            }
        }

        private void timvcode_Tick(object sender, EventArgs e)
        {
            vCode += 10;
            if (vCode == 9999)
            {
                vCode = 1000;
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            timvcode.Stop();
            string from, pass, mail;
            string to = mailBox.Text;
            from = "khabanhpro135@gmail.com";//Your gmail;
            mail = vCode.ToString();
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
                confirmBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
