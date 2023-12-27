using System.Configuration;
using System.Data;
using System.Windows;

using NotifyIcon = System.Windows.Forms.NotifyIcon;

namespace noCapsLock_Tool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NotifyIcon icon = new()
            {
                Icon = noCapsLock_Tool.Properties.Resources.Icon1,
                Visible = true
            };

            icon.MouseClick += Icon_MouseClick;

            base.OnStartup(e);

        }

        private void Icon_MouseClick(object? sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    System.Windows.MessageBox.Show("KEKSE LEFT");
                    break;
                case MouseButtons.Right:
                    System.Windows.MessageBox.Show("KEKSE RIGHT");
                    break;
                default:
                    break;
            }

        }

    }

}
