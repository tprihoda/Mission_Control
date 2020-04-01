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
    public class Valve
    {

        public delegate void StateChanged(object sender, ValveEventArgs e);
        public event StateChanged OnStateChanged;
        public class ValveEventArgs : EventArgs
        {
            public Valve passed;
        }
        public enum State { Nominal, Failure, Unknown };
        public Image image;
        private bool isOpen_Value;
        public bool isOpen
        {
            get { return isOpen_Value; }
            set {
                isOpen_Value = value;
                ValveEventArgs e = new ValveEventArgs();
                e.passed = this;
                RaiseStateChange(e);
                }
        }

        public string Name;
        public string Description;
        public bool IsOverriden = false;
        private State Feedback_Value = State.Unknown;
        public State Feedback
        {
            get { return Feedback_Value; }
            set
            {
                Feedback_Value = value;
                ValveEventArgs e = new ValveEventArgs();
                e.passed = this;
                RaiseStateChange(e);
            }
        }
        double rotation = 0;
        public BitmapImage Black = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Valve\Black.png"));
        public BitmapImage Red = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Valve\Red.png"));
        public BitmapImage Yellow = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Valve\Yellow.png"));
        public BitmapImage Green = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Valve\Green.png"));
        public BitmapImage Blue = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Valve\Blue.png"));
   
        protected virtual void RaiseStateChange(ValveEventArgs e)
        {
            if (OnStateChanged != null) { OnStateChanged(this, e); }
        }

        public Valve(Image passed_Source, string name, bool rotate, string description)
        {
            Name = name;
            Description = description;
            image = passed_Source;
            image.Source = Black;
            image.RenderTransformOrigin = new Point(0.5, 0.5);
            if (rotate)
            {
                image.RenderTransform = new RotateTransform(90);
                rotation = 90;
            }
            image.Width = 47;
            image.Height = 47;
            
            isOpen_Value = true;

        }
        
        public void Open()
        {
            //image.Source = Black;
            image.RenderTransform = new RotateTransform(rotation);
            ChangeColor();
            isOpen = true;
        }
        public void Close()
        {
            //image.Source = Black;
            image.RenderTransform = new RotateTransform(rotation + 90);
            ChangeColor();
            isOpen = false;
        }
        public void Toggle()
        {
            image.Source = Black;
            if (isOpen)
            {
                image.RenderTransform = new RotateTransform(rotation + 90);
                isOpen = false;
            }
            else
            {               
                image.RenderTransform = new RotateTransform(rotation);
                isOpen = true;
            }
        }

        public void ChangeColor()
        {
            if (isOpen)
            {
                switch (Feedback)
                {
                    case State.Nominal:
                        image.Source = Green;
                        break;
                    case State.Failure:
                        image.Source = Red;
                        break;
                    case State.Unknown:
                        image.Source = Yellow;
                        break;
                }
            }
            else
            {
                switch (Feedback)
                {
                    case State.Nominal:
                        image.Source = Blue;
                        break;
                    case State.Failure:
                        image.Source = Red;
                        break;
                    case State.Unknown:
                        image.Source = Yellow;
                        break;
                }
            }
        }
    }
}
