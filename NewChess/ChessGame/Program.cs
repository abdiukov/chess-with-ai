using System;
using System.Windows.Forms;
using UI;

namespace View
{
    static class Program
    {
        public static MainMenu mainMenu = new();
        public static GUIView gameWindow;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainMenu);
        }
    }
}
