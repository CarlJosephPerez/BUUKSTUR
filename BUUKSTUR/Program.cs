using System;
using System.Windows.Forms;

namespace BUUKSTUR
{
    internal static class Program
    {
        public static BUUKSTUR LoginForm { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            LoginForm = new BUUKSTUR(); 
            Application.Run(LoginForm);
        }
    }
}