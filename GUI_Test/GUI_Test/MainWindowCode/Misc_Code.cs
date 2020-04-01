using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Threading;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        void initMainTimer()
        {
            DispatcherTimer mainTimer = new DispatcherTimer();
            mainTimer.Interval = TimeSpan.FromSeconds(.05);
            mainTimer.Tick += MainTimerTick;
            mainTimer.Start();
        }
        void MainTimerTick(object sender, EventArgs e)
        {
            
            P1.Value += 0.5;
            P2.Value += 1;
            P3.Value += 2;
            P4.Value += 4;

            T1.Value -= 0.5;
            T2.Value -= 1;
            T3.Value -= 2;
            T4.Value -= 4;
            T5.Value -= 8;
            T6.Value -= 10;
            
            Altitude.Value += 1;
            CautionWarningTick();
            KeySwitchTick();
        }
        void initLogging()
        {
            string fileName = "log.txt";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, @"Logs\", fileName);
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
        }
        public static void EnsureBrowserEmulationEnabled(string exename = "GUI.exe", bool uninstall = false)
        {

            try
            {
                using (
                    var rk = Registry.CurrentUser.OpenSubKey(
                            @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true)
                )
                {
                    if (!uninstall)
                    {
                        dynamic value = rk.GetValue(exename);
                        if (value == null)
                            rk.SetValue(exename, (uint)11001, RegistryValueKind.DWord);
                    }
                    else
                        rk.DeleteValue(exename);
                }
            }
            catch
            {
            }
        }
    }
}