using System;
using System.Windows.Forms;
using UI;

namespace Chess
{
    static class Program
    {
        public static MainMenu mainMenu = new();
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainMenu);
        }
    }
}
