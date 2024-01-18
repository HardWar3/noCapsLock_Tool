using System.Configuration;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows;
using System.Timers;

using NotifyIcon = System.Windows.Forms.NotifyIcon;
using System.Windows.Input;

namespace noCapsLock_Tool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVK,byte bScan,uint dwFlags,UIntPtr dwExtraInfo);
        const int KEYEVENTF_EXTEMDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;
        const int KEY_CAPSLOCK = 0x14;
        protected override void OnStartup(StartupEventArgs e)
        {
            Add_System_Tray();

            Interval();

            base.OnStartup(e);

        }

        private void Add_System_Tray()
        {
            NotifyIcon icon = new()
            {
                Icon = noCapsLock_Tool.Properties.Resources.GeileSocke,
                Visible = true
            };

            icon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            icon.ContextMenuStrip.Items.Add("Exit", null, On_Exit_Clicked);
        }

        private void On_Exit_Clicked(object? sender, EventArgs e)
        {
                base.Shutdown();
        }

        private void Interval()
        {
            System.Timers.Timer timer = new System.Timers.Timer();

            timer.Interval = 50;

            timer.Elapsed += Turn_off_capslock;

            timer.Enabled = true;
        }

        private void Turn_off_capslock(object? sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                Switch_key(KEY_CAPSLOCK);
            }
        }

        private void Switch_key(byte key)
        {
            keybd_event(key, 0x45, KEYEVENTF_EXTEMDEDKEY, (UIntPtr)0);
            keybd_event(key, 0x45, KEYEVENTF_EXTEMDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
        }
    }
}
