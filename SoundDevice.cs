
using AudioSwitcher.AudioApi;
using CoreAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/***
 * Manages Sound device operations (Playback devices. When you click the volume tray icon in Windows). Switching and enumerating
 */

namespace SoundToggleTool
{
    internal class SoundDevice
    {
        public static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();//Used in the Update function to make app run smoother

        //The current active device. Other is when the OS active audio output device is not set to either TO or FROM
        public enum ACTIVE_DEVICE
        {
            OTHER,
            TO,
            FROM
        }

        //Gets the current device set by the OS or app
        public static MMDevice GetCurrentDevice()
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator(Guid.NewGuid());
            return enumerator.GetDefaultAudioEndpoint(DataFlow.Render, (CoreAudio.Role)AudioSwitcher.AudioApi.DeviceState.Active);
        }

        //Sets the current device to a specified device name
        public static void SetCurrentDeviceFromName(List<MMDevice> devices, string deviceName)
        {
            //Read to and from from settings
            string from = Properties.Settings.Default.DeviceFrom;
            string to = Properties.Settings.Default.DeviceTo;

            //Try to get the MMDevice based on the name.
            var device = devices.FirstOrDefault(x => x.DeviceFriendlyName == deviceName);

            //Set playback device if it was found
            if(device != null)
            {
                SetPlaybackDevice(device);
            }
        }

        //Toggles the current device based on what's currently set.
        public static void Toggle(List<MMDevice> devices)
        {
            //Get current device
            var currentDevice = GetCurrentDevice();
            string currentDeviceName = currentDevice.DeviceFriendlyName;

            //Read to and from from settings
            string from = Properties.Settings.Default.DeviceFrom;
            string to = Properties.Settings.Default.DeviceTo;

            //Check if current device is either from or to or none of them and set them accordingly
            if (from == currentDeviceName)
            {
                SetCurrentDeviceFromName(devices, to);
            }
            else if(to == currentDeviceName)
            {
                SetCurrentDeviceFromName(devices, from);
            }
            if(currentDevice == null || (currentDeviceName != from && currentDeviceName != to))
            {
                SetCurrentDeviceFromName(devices, from);
            }
        }

        //Same as set controls, but it makes sure to run on the main UI thread.
        public static void SetControlsMainThread(Form1 f, ACTIVE_DEVICE currentActiveDevice, string currentDeviceName)
        {
            try
            {
                f.Invoke((Action)(() =>
                {
                    SetControls(f, currentActiveDevice, currentDeviceName);
                }));
            }
            catch
            {
                //Tries to run it on the main thread... Dangerous!
                SetControls(f, currentActiveDevice, currentDeviceName);
            }
        }

        //Changes controls, images, etc to appropriate ones.
        public static void SetControls(Form1 f, ACTIVE_DEVICE currentActiveDevice, string currentDeviceName)
        {
            //Only dynamically change the tray icon if it's been set in the settings.
            if (Properties.Settings.Default.DynamicIcon)
            {
                //Set the appropriate tray icon based on what was set
                if (currentActiveDevice == ACTIVE_DEVICE.FROM)
                    f.ntf.Icon = Properties.Resources.headset_mic_s;
                else if (currentActiveDevice == ACTIVE_DEVICE.TO)
                    f.ntf.Icon = Properties.Resources.speaker_s;
                else if (currentActiveDevice == ACTIVE_DEVICE.OTHER)
                    f.ntf.Icon = Properties.Resources.media_output_s;
            }

            //Set the hover text for the tray icon
            string trayText = $"Current audio device:\n{currentDeviceName}";
            f.ntf.Text = trayText.Length >= 64 ? trayText.Substring(0, 63) : trayText;

            //Set text of current device in the settings
            f.lblCurrentDevice.Text = GetCurrentDevice().DeviceFriendlyName;
        }

        //Checks current device and the current "to and from" and sets controls and variables accordingly
        public static void Update(List<MMDevice> devices, Form1 f)
        {
            //Cancel any other previous call to this function by canceling the thread it's running on.
            if (cancellationTokenSource != null && !cancellationTokenSource.IsCancellationRequested)
                cancellationTokenSource.Cancel();
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            //Run the function on a separate thread. Getting values from the "devices" list is a bit slow. Most likely because of some interop overhead. What do i know?
            Task.Run(() =>
            {
                try
                {
                    //Limit speed of execution for ultimate smoothness. :D
                    Thread.Sleep(100);
                    
                    //Read to and from from settings
                    string from = Properties.Settings.Default.DeviceFrom;
                    string to = Properties.Settings.Default.DeviceTo;

                    //Get current device name
                    var curDevice = GetCurrentDevice();
                    string curDeviceName = curDevice.DeviceFriendlyName;

                    //Throw the cancel error if cancel was called before this point
                    token.ThrowIfCancellationRequested();

                    //Try to get the MMDevice based on the name. If neither from or to is set, it's null
                    var deviceFoundFrom = devices.FirstOrDefault(x => x.DeviceFriendlyName == from);
                    var deviceFoundTo = devices.FirstOrDefault(x => x.DeviceFriendlyName == to);

                    //Set images and other controls and variables based on if to or from is the current audio device set in the OS.
                    if (deviceFoundFrom != null && deviceFoundTo != null)
                    {
                        if (curDeviceName == deviceFoundFrom.DeviceFriendlyName || curDeviceName == deviceFoundTo.DeviceFriendlyName)
                        {
                            if (curDeviceName == deviceFoundFrom.DeviceFriendlyName)
                                SetControlsMainThread(f, ACTIVE_DEVICE.FROM, curDeviceName);
                            if (curDeviceName == deviceFoundTo.DeviceFriendlyName)
                                SetControlsMainThread(f, ACTIVE_DEVICE.TO, curDeviceName);
                        }
                        else
                        {
                            SetControlsMainThread(f, ACTIVE_DEVICE.OTHER, curDeviceName);
                        }
                    }
                    else
                    {
                        SetControlsMainThread(f, ACTIVE_DEVICE.OTHER, curDeviceName);
                    }
                }
                catch(OperationCanceledException e)
                {
                    Console.WriteLine($"Intended behavior: {e.Message}");
                }
            }, token);
        }

        //Sets the current playback device
        public static void SetPlaybackDevice(MMDevice device)
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator(Guid.NewGuid());
            enumerator.SetDefaultAudioEndpoint(device);
        }

        /// <summary>
        /// Lists all the available playback devices
        /// </summary>
        /// <returns>A list of MMDevice objects</returns>
        public static List<MMDevice> ListDevices()
        {
            //Initialize and list all devices with state "active"
            List<MMDevice> list = new List<MMDevice>();
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator(Guid.NewGuid());
            MMDeviceCollection devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, (CoreAudio.DeviceState)AudioSwitcher.AudioApi.DeviceState.Active);

            //Step through the device list and add it to an MMDevice List object instead
            foreach(var device in devices)
            {
                list.Add(device);
            }

            return list;
        }
    }
}
