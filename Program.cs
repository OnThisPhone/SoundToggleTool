using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/***
 * Made by Victoria. Copyright 2024. You can change it however you want. Just credit me.
 * A very simple tool that lets you easily toggle between different sound output devices through a handy-dandy tray icon.
 * 
 * NOTE Code is a bit of a mess. I was struggling with sleepiness. That's my cope. Don't jump down my throat over some nonsense you may find.
 * NOTE The delay when changing the tray icon after pressing it could be faster.
 */

namespace SoundToggleTool
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
