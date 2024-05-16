using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace loginIndian.Forms
{
    public partial class Help : Form
    {
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        public Help()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
        }

        private bool ValidateFields()
        {
            // Email validation
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!emailRegex.IsMatch(EmailBox.Text.Trim()))
            {
                MessageBox.Show("Invalid email format.");
                return false; ;
            }

            // Phone number validation (Modify the regex as needed for your format)
            Regex phoneRegex = new Regex(@"^\d{9,11}$");
            if (!phoneRegex.IsMatch(TelBox.Text.Trim()))
            {
                MessageBox.Show("Invalid phone number format.");
                return false;
            }

            return true; // All validations passed
        }

        private void Sendbtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(UserBox.Text) || String.IsNullOrEmpty(GenBox.Text) || String.IsNullOrEmpty(EmailBox.Text)
                || String.IsNullOrEmpty(TelBox.Text) || String.IsNullOrEmpty(shortexplainBox.Text) || picCCCD.Image == null)

            {
                MessageBox.Show("Please fill out all informations before sending request!");
            }
            else
            if (!ValidateFields()) return; // Early exit if validation fails
            else 
            {

                string from, pass, mail;
                string to = "khabanhpro135@gmail.com"; 
                from = "khabanhpro135@gmail.com";//Your gmail;
                mail = UserBox.Text + "\n" + "Phone: " + TelBox.Text + "\n" + "Gender: " + GenBox.Text + "\n"
                    + "Mail: " + EmailBox.Text + "\n" + "Problem: " + shortexplainBox.Text;
                //pass = "xhkq hhfn tkkh lpuu";//Your app pass;
                pass = "aavy rpyg xlhx atdo";
                MailMessage message = new MailMessage();
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = "Request from: " + mail;
                message.Subject = "Xplore - Help Service";//Mail subject
                Attachment attachment = new Attachment(openFileDialog.FileName);
                message.Attachments.Add(attachment);
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                try
                {
                    smtp.Send(message);
                    MessageBox.Show("Your request has been seen! Please wait, We will reply as soon as possible <3", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //MessageBox.Show("Your request has been seen! Please wait, We will reply as soon as possible <3");
                MessageBox.Show("Back to Login!");
                Hide();
                LoginForm form = new LoginForm("");
                form.ShowDialog();
                Close();
            }
        }

        private void PictureBtn_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn file ảnh
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Kiểm tra định dạng file
                    string extension = System.IO.Path.GetExtension(openFileDialog.FileName);
                    if (!openFileDialog.Filter.Contains(extension))
                        {
                        MessageBox.Show("Vui lòng chọn file ảnh có định dạng *.jpg, *.jpeg, *.png hoặc *.gif.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Không thực hiện các bước tiếp theo nếu định dạng không đúng
                    }

                    // Tải và resize ảnh
                    using (var image = Image.FromFile(openFileDialog.FileName))
                    {
                        // Kích thước mới (ví dụ: 200x200)
                        int newWidth = 200;
                        int newHeight = 200;

                        // Tạo ảnh mới với kích thước đã thay đổi
                        Bitmap resizedImage = new Bitmap(image, new Size(newWidth, newHeight));

                        // Gán ảnh đã resize cho PictureBox
                        picCCCD.Image = resizedImage;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to return Login page?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Go to Main Menu
                Hide();
                LoginForm form = new LoginForm("");
                form.ShowDialog();
                Close();
            }
        }
    }
}
