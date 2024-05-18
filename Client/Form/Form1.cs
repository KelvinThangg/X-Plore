using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private const string FirebaseURL = "https://checkdatabase-1fbc9-default-rtdb.firebaseio.com/";
        private FirebaseClient firebaseClient;
        public Form1()
        {
            InitializeComponent();
            InitializeFirebase();
        }
        private void InitializeFirebase()
        {
            firebaseClient = new FirebaseClient(FirebaseURL);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Vui lòng nhập tên người dùng.");
                return;
            }

            if (await IsUserExists(userName))
            {
                MessageBox.Show("Người dùng đã tồn tại. Vui lòng chọn tên khác.");
            }
            else
            {
                Users newUser = new Users { UserName = userName };
                await Task.Run(async () =>
                {
                    await firebaseClient.Child("users").Child(userName).PutAsync(newUser);
                });
                MessageBox.Show("Đăng ký thành công.");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text.Trim();

            if (await IsUserExists(userName))
            {
                FormTaoPhong formTaoPhong = new FormTaoPhong(userName); // Truyền userName vào constructor
                formTaoPhong.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bạn cần đăng ký trước khi tạo phòng!");
            }
        }

        private async Task<bool> IsUserExists(string userName)
        {
            try
            {
                var user = await firebaseClient.Child("users").Child(userName).OnceSingleAsync<Users>();
                return user != null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra người dùng: " + ex.Message);
                return false;
            }
        }
    }
}