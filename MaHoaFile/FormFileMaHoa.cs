using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_Plore.MaHoaFile
{
    public partial class FormFileMaHoa : Form
    {
        public FormFileMaHoa()
        {
            InitializeComponent();
        }


        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            string key = textBoxKey.Text;
            if (!string.IsNullOrEmpty(key))
            {
                richTextBoxOutput.Text = Encrypt(richTextBoxInput.Text, key);
            }
            else
            {
                MessageBox.Show("Please enter a key.");
            }
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            string key = textBoxKey.Text;
            if (!string.IsNullOrEmpty(key))
            {
                richTextBoxInput.Text = Decrypt(richTextBoxOutput.Text, key);
            }
            else
            {
                MessageBox.Show("Please enter a key.");
            }
        }

        // Encryption logic here
        private string Encrypt(string input, string key)
        {
            // Place your actual encryption algorithm here
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        }

        // Decryption logic here
        private string Decrypt(string cipherText, string key)
        {
            // Place your actual decryption algorithm here
            try
            {
                byte[] bytes = Convert.FromBase64String(cipherText);
                return Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                MessageBox.Show("Invalid cipher text.");
                return "";
            }
        }

        private void FormFileMaHoa_Load(object sender, EventArgs e)
        {

        }

        
        
    }
}
