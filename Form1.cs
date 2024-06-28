using CoreAudio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundToggleTool
{
    public partial class Form1 : Form
    {
        private bool firstTimeStartUp = true;               //Used to make sure that the app doesn't show the form when it first starts
        List<MMDevice> devices = SoundDevice.ListDevices(); //Contains all the devices that got enumerated in the constructor

        public Form1()
        {
            InitializeComponent();

            //Check the setting for if the app should start with windows or not and set the registry key accordingly
            if (Properties.Settings.Default.AutoStartWithWindows)
                Common.ChangeAppAutoRun(true);

            //Set tray icon properties
            ntf.ContextMenuStrip = AppContextMenu();
            ntf.Click += (o, e) =>
            {
                //Only accept left clicks
                if(((MouseEventArgs)e).Button == MouseButtons.Left)
                    ToggleSoundDevices();
            };

            //Put all available devices in the combo boxes
            foreach ( var device in devices )
            {
                cmbDevices1.Items.Add(device.DeviceFriendlyName);
                cmbDevices2.Items.Add(device.DeviceFriendlyName);
            }

            //Set previously chosen values for each combo box
            cmbDevices1.Text = Properties.Settings.Default.DeviceFrom;
            cmbDevices2.Text = Properties.Settings.Default.DeviceTo;

            //Update the relevant controls and variables based on the current active device
            SoundDevice.Update(devices, this);
        }

        //This makes sure that the app doesn't show itself and immediately hides itself
        protected override void SetVisibleCore(bool value)
        {
            //Makes sure that it only auto hides the main form once when starting the app.
            //FirstTimeStartup settings means first time app has ever started. It should show the form window the first time ever you start the app
            if (firstTimeStartUp && !Properties.Settings.Default.FirstTimeStartup)
            {
                value = false;
                firstTimeStartUp = false;
                base.SetVisibleCore(value);
                return;
            }
            base.SetVisibleCore(value);

            //Make the FirstTimeStartup false.
            if(Properties.Settings.Default.FirstTimeStartup)
            {
                Properties.Settings.Default.FirstTimeStartup = false;
                Properties.Settings.Default.Save();
            }

            //Check current device and show it in the settings.
            //lblCurrentDevice.Text = SoundDevice.GetCurrentDevice().DeviceFriendlyName;

            //Update the relevant controls and variables based on the current active device
            //SoundDevice.Update(devices, this);
        }

        //When form tries to close through normal means
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Visible = false;
            e.Cancel = true;
        }

        //When clicking the auto start with windows checkbox.
        private void chkAutoStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            //Make the change to the property key in settings, save it and set the registry key (Or delete it if it's unchecked)
            bool isChecked = ((CheckBox)sender).Checked;
            Common.ChangeAppAutoRun(isChecked);
            Properties.Settings.Default.AutoStartWithWindows = isChecked;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Toggles between the set sound devices
        /// </summary>
        private void ToggleSoundDevices()
        {
            //Check to see that From and To has been set.
            if(cmbDevices1.Text == "" || cmbDevices2.Text == "")
            {
                MessageBox.Show("You have to set 'From' and 'To' in the settings window. Right click the tray icon and choose 'Settings' (Unless the settings window is already opened. Which it might be)", "Error");
                return;
            }

            //Update and toggle
            SoundDevice.Toggle(devices);
            SoundDevice.Update(devices, this);
        }

        /// <summary>
        /// Creates the app's context menu. When you right click on the tray icon
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ContextMenuStrip AppContextMenu()
        {
            //Declare some values
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem itemSettings = new ToolStripMenuItem("Settings");
            ToolStripMenuItem itemExit = new ToolStripMenuItem("Exit App");

            //Set what happens when each respective item is clicked
            itemSettings.Click += (o, e) =>
            {
                Visible = true;
            };
            itemExit.Click += (o, e) =>
            {
                Application.Exit();
            };

            //Add items to the app's context menu
            contextMenu.Items.Add(itemSettings);
            contextMenu.Items.Add(itemExit);

            //Return the menu
            return contextMenu;
        }

        //When close button is pressed. Hides the window.
        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        //Select first device to toggle from
        private void cmbDevices1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change settings variable and save
            Properties.Settings.Default.DeviceFrom = ((ComboBox)sender).Text;
            Properties.Settings.Default.Save();

            //Update the relevant controls and variables based on the current active device. But limit so it doesn't update at first time startup
            if (!firstTimeStartUp)
                SoundDevice.Update(devices, this);
        }

        //Select second device to toggle to
        private void cmbDevices2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change settings variable and save
            Properties.Settings.Default.DeviceTo = ((ComboBox)sender).Text;
            Properties.Settings.Default.Save();

            //Update the relevant controls and variables based on the current active device. But limit so it doesn't update at first time startup
            if(!firstTimeStartUp)
                SoundDevice.Update(devices, this);
        }

        //Help button
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The settings screen lets you set the two 'playback devices' the app will toggle between. From and To.\n\nTo toggle between the two 'devices' that you've set, simply click the app tray icon (The one to the bottom right of your screen next to the clock, volume, network, etc)\n\nDynamic Icon means that the app's tray icon will change depending on which device is currently being used. Start App with Windows means the app will start with Windows (Duh..).\n\nThe bottom right 'switch' icon toggles the audio output device.", "Help");
        }

        //Bottom right "toggle" button. Toggles between the two devices
        private void btnToggle_Click(object sender, EventArgs e)
        {
            SoundDevice.Toggle(devices);
            SoundDevice.Update(devices, this);
        }

        //Dynamic icon checkbox
        private void chkDynamicIcon_CheckedChanged(object sender, EventArgs e)
        {
            //Get the checked status of the checkbox
            bool isChecked = ((CheckBox)sender).Checked;

            //Change settings variable and save
            Properties.Settings.Default.DynamicIcon = isChecked;
            Properties.Settings.Default.Save();

            //Reset the tray icon to the initial one if this checkbox is unchecked. Update it to the right one if it gets checked.
            if (!isChecked)
            {
                SoundDevice.cancellationTokenSource.Cancel();//Cancel the current Update before setting the Icon.
                ntf.Icon = Properties.Resources.media_output_s;
            }
            else
            {
                SoundDevice.Update(devices, this);
            }
        }
    }
}
