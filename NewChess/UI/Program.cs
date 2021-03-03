using ChessBoardAssets;
using System;
using System.Windows.Forms;

namespace Chess
{
    static class Program
    {
        public static Square[,] board = new Square[8, 8];
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUIView());
        }
    }
}
