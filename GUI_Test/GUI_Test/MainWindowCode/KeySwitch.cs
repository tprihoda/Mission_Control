using System;
using System.Windows;
using System.Windows.Media;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.IO.Ports.SerialPort sp = new System.IO.Ports.SerialPort("COM11", 115200, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
        enum Keystates { Ready, NotReady, Disconnected };
        Keystates Keystatus = Keystates.Disconnected;
        void initKeySwitch()
        {
            try
            {
                sp.Open();
            }
            catch (System.IO.IOException)
            {
                System.Windows.MessageBox.Show("Launch Keys Disconnected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void KeySwitchTick()
        {
            if (sp.IsOpen)
            {
                try
                {
                    var readData = sp.ReadExisting();
                    if (readData.EndsWith("1"))
                    {
                        Keystatus = Keystates.Ready;
                    }
                    else
                    {
                        Keystatus = Keystates.NotReady;
                    }
                }
                catch (InvalidOperationException)
                {
                    Keystatus = Keystates.Disconnected;
                    MessageBox.Show("Launch Keys Disconnected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            else
            {
                try
                {
                    sp.Open();
                }
                catch (System.IO.IOException)
                {
                    if (Keystatus != Keystates.Disconnected)
                    {
                        MessageBox.Show("Launch Keys Disconnected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                Keystatus = Keystates.Disconnected;
            }
            switch (Keystatus)
            {
                case Keystates.Ready:
                    Launch_Button.Background = Brushes.Green;
                    break;
                case Keystates.NotReady:
                    Launch_Button.Background = Brushes.Red;
                    break;
                case Keystates.Disconnected:
                    Launch_Button.Background = Brushes.Gold;
                    break;
            }
        }
    }
}