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
using System.IO;
using System.Diagnostics;
using Google.Cloud.Firestore;
using loginIndian.Classes;

using NLipsum.Core;

namespace X_Plore.Main
{
    public partial class FeedBack : Form
    {
        private string username;
        private string displayname;
        public FeedBack(string DisplayName, string username)
        {
            InitializeComponent();
            this.username = username;
            this.displayname = DisplayName;
            // Initialize ListView columns
            listView1.Columns.Add("File Name", 150);
            listView1.Columns.Add("Type", 80);
            openFileDialog = new OpenFileDialog();
            openPicDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            openFileDialog.Filter = "All Files (*.*)|*.*"; // Filter for all files
            videoFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mkv;*.mov|All Files (*.*)|*.*";
        }
        bool testFileupdate = false;

        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private OpenFileDialog openPicDialog = new OpenFileDialog();
        private OpenFileDialog videoFileDialog = new OpenFileDialog();
        private void button2_Click(object sender, EventArgs e) => AttachFile(openPicDialog); // Reuse for images
        private void button3_Click(object sender, EventArgs e) => AttachFile(videoFileDialog);
        private void button4_Click(object sender, EventArgs e) => AttachFile(openFileDialog);

        private MailMessage emailMessage = null;
      
        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin email 
            string from, pass, mail;
            string to = "khabanhpro135@gmail.com";
            from = "khabanhpro135@gmail.com";//Your gmail;
            pass = "aavy rpyg xlhx atdo";
            string subject = textBox4.Text;
            string body = richTextBox1.Text;

            if (string.IsNullOrEmpty(body) && string.IsNullOrEmpty(subject) && testFileupdate == false)
            {
                MessageBox.Show("Vui lòng soạn email hoặc đính kèm tệp trước khi gửi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else

                if (testFileupdate == false)
            {
                try
                {
                    // Validate email addresses
                    if (!IsValidEmail(from) || !IsValidEmail(to))
                    {
                        MessageBox.Show("Please enter valid email addresses.");
                        return;
                    }

                    // Create the email message
                    subject = username + " feedback about: " + textBox4.Text;
                    MailMessage message = new MailMessage(from, to, subject, body);

                    // Configure the SMTP client for Gmail
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                    {
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(from, pass),
                        //Timeout = 10000
                    };
                    smtp.Send(message);

                    MessageBox.Show("We have received your letter! Thank for writing to us <3", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Xóa tiêu đề và nội dung email
                    textBox4.Text = ""; // Xóa tiêu đề
                    richTextBox1.Text = ""; // Xóa nội dung
                    message = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to send email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                try
                {
                    // Validate email addresses
                    if (!IsValidEmail(from) || !IsValidEmail(to))
                    {
                        MessageBox.Show("Please enter valid email addresses.");
                        return;
                    }

                    // Create the email message
                    MailMessage message = new MailMessage(from, to, subject, body);

                    // Configure the SMTP client for Gmail
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                    {
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(from, pass),
                        //Timeout = 10000
                    };


                    smtp.Send(emailMessage);

                    MessageBox.Show("We have received your letter! Thank for writing to us <3", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Xóa các tệp đính kèm sau khi gửi thành công
                    foreach (Attachment attachment in emailMessage.Attachments)
                    {
                        attachment.Dispose(); // Giải phóng tài nguyên của attachment
                    }
                    emailMessage.Attachments.Clear();
                    listView1.Items.Clear();
                    // Xóa tiêu đề và nội dung email
                    textBox4.Text = ""; // Xóa tiêu đề
                    richTextBox1.Text = ""; // Xóa nội dung
                    UpdateAttachmentList();
                    emailMessage = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to send email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        //Helper Method
        private bool IsValidEmail(string email)
        {
            // Use the Regex class for email validation
            return new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(email);
        }


        private void AttachFile(OpenFileDialog fileDialog)
        {
            fileDialog.Multiselect = true; // Enable multiple file selection
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            // Create a new MailMessage if it doesn't exist yet
            if (emailMessage == null)
            {
                string to = "khabanhpro135@gmail.com";
                string from = "khabanhpro135@gmail.com";//Your gmail;
                string subject = textBox4.Text;

                // Email validation (same as before)
                if (!IsValidEmail(from) || !IsValidEmail(to))
                {
                    MessageBox.Show("Please enter valid email addresses.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                subject = username + " feedback about: " + textBox4.Text;
                emailMessage = new MailMessage(from, to, subject, richTextBox1.Text);
            }

            foreach (string fileName in fileDialog.FileNames) // Attach each selected file
            {
                if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
                {
                    Attachment attachment = new Attachment(fileName);
                    emailMessage.Attachments.Add(attachment);
                    UpdateAttachmentList();
                }
            }
        }
        private void UpdateAttachmentList()
        {
            listView1.Items.Clear();
            Dictionary<string, int> fileTypeCounts = new Dictionary<string, int>
                {
                    { "Image", 0 },
                    { "Video", 0 },
                    { "File", 0 }
                };


            foreach (Attachment attachment in emailMessage.Attachments)
            {
                string fileName = Path.GetFileName(attachment.Name);
                string fileType = GetFileType(fileName);
                fileTypeCounts[fileType]++;
                ListViewItem item = new ListViewItem(fileName);
                item.SubItems.Add(fileType);
                listView1.Items.Add(item);
            }

            // Display the counts
            label6.Text = $"Images: {fileTypeCounts["Image"]}";
            if (fileTypeCounts["Image"] != 0 || fileTypeCounts["Video"] != 0 || fileTypeCounts["File"] != 0)
            {
                testFileupdate = true;
            }
            else
            {
                testFileupdate = false;
            }
        }
        private string GetFileType(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();
            if (openPicDialog.Filter.Contains(extension)) return "Image";
            if (videoFileDialog.Filter.Contains(extension)) return "Video";
            return "File";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in listView1.SelectedItems)
                {
                    string fileNameToRemove = selectedItem.Text;

                    // Remove from emailMessage
                    for (int i = emailMessage.Attachments.Count - 1; i >= 0; i--)
                    {
                        if (Path.GetFileName(emailMessage.Attachments[i].Name) == fileNameToRemove)
                        {
                            emailMessage.Attachments[i].Dispose(); // Release resources
                            emailMessage.Attachments.RemoveAt(i);
                            break; // Exit loop after removing the attachment
                        }
                    }

                    // Remove from ListView
                    listView1.Items.Remove(selectedItem);
                }

                UpdateAttachmentList(); // Update counts and display
            }
            else
            {
                MessageBox.Show("Please select attachments to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
   }

