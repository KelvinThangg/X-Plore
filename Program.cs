using loginIndian.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using X_Plore.Main;
using X_Plore.Dangky_Dangnhap;
using System.Configuration;

namespace X_Plore
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Set environment variable for Firestore
            FirestoreHelper.SetEnvironmentVariable();

            // Enable visual styles and set compatible text rendering default
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Run the application with the login form
            Application.Run(new FormDangNhap(""));
        }
    }
}
