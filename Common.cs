using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/***
 * Common functionality for the app. Useful non-specific functions that the whole app uses
 */

namespace SoundToggleTool
{
    internal class Common
    {
        /// <summary>
        /// Changes whether the app should auto run when the system starts or not
        /// </summary>
        /// <param name="autoRun">True adds a regedit key that makes the app auto run at startup</param>
        public static void ChangeAppAutoRun(bool autoRun)
        {
            //Open the specified key in the registry
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                //Set some strings to use for the key
                string name = Application.ProductName + ".exe";
                string path = System.Reflection.Assembly.GetEntryAssembly().Location;

                //Add or remove the key depending on the autorun parameter
                if (autoRun) key.SetValue(name, "\"" + path + "\" -auto_open_window false");
                else key.DeleteValue(name, false);
            }
        }
    }
}
