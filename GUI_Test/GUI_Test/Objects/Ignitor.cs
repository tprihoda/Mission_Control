using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace GUI
{
    public class Ignitor
    {

        public delegate void StateChanged(object sender, IgnEventArgs e);
        public event StateChanged OnStateChanged;
        public class IgnEventArgs : EventArgs
        {
            public bool isOn;
        }
        public Image image;
        private bool isOn_Value;
        public bool isOn
        {
            get { return isOn_Value; }
            set {
                isOn_Value = value;
                IgnEventArgs e = new IgnEventArgs();
                e.isOn = value;
                RaiseStateChange(e);
                }
        }

        public string Name;
        public string Description;
        public bool IsOverriden = false;
        public BitmapImage On = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Glow_Plug\Glow_Plug_Glowing.png"));
        public BitmapImage Off = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Glow_Plug\Glow_Plug_Off.png"));
   
        protected virtual void RaiseStateChange(IgnEventArgs e)
        {
            if (OnStateChanged != null) { OnStateChanged(this, e); }
        }

        public Ignitor(Image passed_Source, string name, string description)
        {
            Name = name;
            Description = description;
            image = passed_Source;
            image.Source = Off;           
            isOn_Value = false;

        }
        
        public void TurnOn()
        {
            image.Source = On;
            //send Ignition on command
            MainWindow.client.sendMessage("CMD", 1);
            isOn = true;
        }
        public void TurnOff()
        {
            image.Source = Off;
            //send Ignition off command
            MainWindow.client.sendMessage("CMD", 2);
            isOn = false;
        
        }
    }
}
