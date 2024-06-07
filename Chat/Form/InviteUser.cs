using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using Google.Cloud.Firestore;
using loginIndian.Classes;
using X_Plore.Chat.CS;

namespace X_Plore.Chat
{
    public partial class InviteUser : Form
    {
        private string Displayname;
        private string username;
        private const string FirebaseURL = "https://checkdatabase-1fbc9-default-rtdb.firebaseio.com/";
        private FirebaseClient firebaseClient;
        public InviteUser(string username, string Displayname)
        {
            this.username = username;
            this.Displayname = Displayname;
            InitializeComponent();
            InitializeFirebase();

            textBox1.Text = username;
        }


        private void InitializeFirebase()
        {
            firebaseClient = new FirebaseClient(FirebaseURL);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text.Trim();
            string displayname = Displayname;

            if (await IsUserExists(userName))
            {
                // User exists, open the General form
                General formTaoPhong = new General(userName, displayname);
                formTaoPhong.Show();
                MessageBox.Show("DN thành công!");
                this.Close();
            }
            else
            {
                // Create a new user and wait for completion
                Users newUser = new Users { UserName = userName, DisplayName = displayname };
                await firebaseClient.Child("users").Child(userName).PutAsync(newUser);

                // Now, the user exists, open the General form
                General formTaoPhong = new General(userName, displayname);
                formTaoPhong.Show();
                MessageBox.Show("Tạo tk thành công!");
                this.Close();
            }
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();

            /* if (await IsUserExists(userName))
             {
                 General formTaoPhong = new General(userName); // Truyền userName vào constructor
                 formTaoPhong.Show();
                 this.Hide();
             }
             else
             {
                 MessageBox.Show("Bạn cần đăng ký trước khi tạo phòng!");
             }*/
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