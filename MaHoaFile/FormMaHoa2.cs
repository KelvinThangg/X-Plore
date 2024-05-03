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
   
    public partial class FormMaHoa2 : Form
    {
        public static class FileEncryptor
        {
            public static void EncryptFile(string inputFile, string outputFile, string key)
            {
                byte[] keyBytes = GetSHA256Hash(key);
                byte[] ivBytes = new byte[16];

                using (var aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.IV = ivBytes;

                    using (var inputFileStream = new FileStream(inputFile, FileMode.Open))
                    using (var outputFileStream = new FileStream(outputFile, FileMode.Create))
                    {
                        using (var cryptoStream = new CryptoStream(outputFileStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            inputFileStream.CopyTo(cryptoStream);
                        }
                    }
                }
            }

            private static byte[] GetSHA256Hash(string input)
            {
                using (var sha256 = SHA256.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(input);
                    return sha256.ComputeHash(bytes);
                }
            }

            public static void DecryptFile(string inputFile, string outputFile, string key)
            {
                byte[] keyBytes = GetSHA256Hash(key);
                byte[] ivBytes = new byte[16];

                using (var aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.IV = ivBytes;

                    using (var inputFileStream = new FileStream(inputFile, FileMode.Open))
                    using (var outputFileStream = new FileStream(outputFile, FileMode.Create))
                    {
                        using (var cryptoStream = new CryptoStream(inputFileStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            cryptoStream.CopyTo(outputFileStream);
                        }
                    }
                }
            }
        }
        public FormMaHoa2()
        {
            InitializeComponent();
        }

        private void FormMaHoa2_Load(object sender, EventArgs e)
        {

        }
        

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            string key = textBoxKey.Text;
            string inputFile = textBoxFilePath.Text;
            string encryptedFileName = "Enc_" + Path.GetFileName(inputFile);
            string outputFile = Path.Combine(Path.GetDirectoryName(inputFile), encryptedFileName);

            if (!string.IsNullOrEmpty(inputFile) && File.Exists(inputFile) && !string.IsNullOrEmpty(key))
            {
                FileEncryptor.EncryptFile(inputFile, outputFile, key);
                MessageBox.Show("Thành công. File saved ở: " + outputFile);
            }
            else
            {
                MessageBox.Show("Hãy nhập lại path file hoặc key");
            }
        }

       

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = openFileDialog.FileName;
            }
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            string key = textBoxKey.Text;
            string inputFile = textBoxFilePath.Text;
            string decryptedFileName = "Dec_" + Path.GetFileName(inputFile);
            string outputFile = Path.Combine(Path.GetDirectoryName(inputFile), decryptedFileName);

            if (!string.IsNullOrEmpty(inputFile) && File.Exists(inputFile) && !string.IsNullOrEmpty(key))
            {
                FileEncryptor.DecryptFile(inputFile, outputFile, key);
                MessageBox.Show("Decryption done. File saved at: " + outputFile);
            }
            else
            {
                MessageBox.Show("Please enter a key and select a valid file.");
            }
        }
    }
}
