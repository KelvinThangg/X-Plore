using System.Windows.Forms;

namespace login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            panel1.SendToBack();
            panel2.BringToFront();       
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            panel2.SendToBack();
            panel1.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ButtonLogin.PerformClick();
        }
    }
}
