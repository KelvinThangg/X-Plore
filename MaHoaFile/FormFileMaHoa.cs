using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace X_Plore.MaHoaFile
{
    public partial class FormFileMaHoa : Form
    {
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
            byte[] keyBytes = GetSHA256Hash(key);
            byte[] ivBytes = new byte[16]; // Initialization vector

            using (var aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] dataBytes = Encoding.UTF8.GetBytes(input);
                        cryptoStream.Write(dataBytes, 0, dataBytes.Length);
                        cryptoStream.FlushFinalBlock();
                    }

                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        // Decryption logic here
        private string Decrypt(string cipherText, string key)
        {
            byte[] keyBytes = GetSHA256Hash(key);
            byte[] ivBytes = new byte[16]; // Initialization vector

            try
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                using (var aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.IV = ivBytes;

                    using (var memoryStream = new MemoryStream(cipherBytes))
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            using (var streamReader = new StreamReader(cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid cipher text.");
                return "";
            }
        }

        // SHA256 hash for key
        private byte[] GetSHA256Hash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                return sha256.ComputeHash(bytes);
            }
        }

        public FormFileMaHoa()
        {
            InitializeComponent();
        }
    }
}
