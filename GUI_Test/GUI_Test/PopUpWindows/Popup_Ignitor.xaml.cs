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
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Popup_Ignitor : Window
    {
        public Popup_Ignitor(Ignitor passed, string description)
        {
            InitializeComponent();
            this.DataContext = passed;
            Name.Text = passed.Name;
            Description.Text = description;
            Description.TextWrapping = TextWrapping.Wrap;
            if (passed.isOn) { Command.Text = "On"; }
            else { Command.Text = "Off"; }
            if (passed.IsOverriden)
            {
                Override.Content = "ON";
                Override.Background = Brushes.Green;
                Override_On.Opacity = 1.00;
                Override_Off.Opacity = 1.00;
                if (passed.isOn)
                {
                    Override_On.Background = Brushes.Green;
                    Override_Off.Background = Brushes.Red;
                }
                else
                {
                    Override_Off.Background = Brushes.Green;
                    Override_On.Background = Brushes.Red;
                }

            }
            else
            {
                Override.Content = "OFF";
                Override.Background = Brushes.LightGray;
                Override_On.Background = Brushes.LightGray;
                Override_Off.Background = Brushes.LightGray;
                Override_On.Opacity = 0.50;
                Override_Off.Opacity = 0.50;
            }
            

            Override.Click += delegate (object sender, RoutedEventArgs e) { Override_Click(sender, e, passed); };
            Override_On.Click += delegate (object sender, RoutedEventArgs e) { Override_State_Click(sender, e, passed); };
            Override_Off.Click += delegate (object sender, RoutedEventArgs e) { Override_State_Click(sender, e, passed); };
            passed.OnStateChanged += new Ignitor.StateChanged(Passed_OnStateChanged);
            }

        private void Passed_OnStateChanged(object sender, Ignitor.IgnEventArgs e)
        {
            if (e.isOn)
            {
                Override_On.Background = Brushes.Green;
                Override_Off.Background = Brushes.Red;
                Command.Text = "On";
            }
            else
            {
                Override_Off.Background = Brushes.Green;
                Override_On.Background = Brushes.Red;
                Command.Text = "Off";
            }
        }

        private void Override_Click(object sender, RoutedEventArgs e, Ignitor passed)
        {
            if (passed.IsOverriden)
            {
                passed.IsOverriden = false;
                Override.Content = "OFF";
                Override.Background = Brushes.LightGray;
                Override_On.Background = Brushes.LightGray;
                Override_Off.Background = Brushes.LightGray;
                Override_On.Opacity = 0.50;
                Override_Off.Opacity = 0.50;
                
            }
            else
            {
                passed.IsOverriden = true;
                Override.Content = "ON";
                Override.Background = Brushes.Green;
                Override_On.Opacity = 1.00;
                Override_Off.Opacity = 1.00;
                if (passed.isOn)
                {
                    Override_On.Background = Brushes.Green;
                    Override_Off.Background = Brushes.Red;
                }
                else
                {
                    Override_Off.Background = Brushes.Green;
                    Override_On.Background = Brushes.Red;
                }
            }
        }
        private void Override_State_Click(object sender, RoutedEventArgs e, Ignitor passed)
        {
            if (passed.IsOverriden)
            {
                if (sender == Override_On)
                {
                    passed.TurnOn();
                    Override_On.Background = Brushes.Green;
                    Override_Off.Background = Brushes.Red;

                }
                else if (sender == Override_Off)
                {
                    passed.TurnOff();
                    Override_Off.Background = Brushes.Green;
                    Override_On.Background = Brushes.Red;
                }

            }
        }
    }
}
