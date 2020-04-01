using System.Windows;
using System.Windows.Input;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        void initClickHandlers()
        {
            Caution_Button.Click += delegate (object sender, RoutedEventArgs e) { Caution_Button_Click(sender, e); };
            Warning_Button.Click += delegate (object sender, RoutedEventArgs e) { Warning_Button_Click(sender, e); };

            Approach_Button.Click += delegate (object sender, RoutedEventArgs e) { Approach_Button_Click(sender, e); };
            Break_Button.Click += delegate (object sender, RoutedEventArgs e) { Break_Button_Click(sender, e); };

            Fill_Button.Click += delegate (object sender, RoutedEventArgs e) { State_Change_Button_Click(sender, e, Fill_State); };
            Fill_Disconnect_Button.Click += delegate (object sender, RoutedEventArgs e) { State_Change_Button_Click(sender, e, Fill_Disconnect_State); };
            Door_Button.Click += delegate (object sender, RoutedEventArgs e) { State_Change_Button_Click(sender, e, Door_Close_State); };
            Launch_Button.Click += delegate (object sender, RoutedEventArgs e) { State_Change_Button_Click(sender, e, Launch_State); };

            Pad_Connect_Button.Click += delegate (object sender, RoutedEventArgs e) { Connect_Button_Click(sender, e); };
        }

        void Valve_Click(object sender, RoutedEventArgs e, Valve passed)
        {
            Popup_Valve newWindow = new Popup_Valve(passed, passed.Description);
            newWindow.Owner = this;
            newWindow.Top = PointToScreen(Mouse.GetPosition(this)).Y - 150;
            newWindow.Left = PointToScreen(Mouse.GetPosition(this)).X - 100;

            newWindow.Show();
        }
        void Glow_Click(object sender, RoutedEventArgs e, Ignitor passed)
        {
            Popup_Ignitor newWindow = new Popup_Ignitor(passed, passed.Description);
            newWindow.Owner = this;
            newWindow.Top = PointToScreen(Mouse.GetPosition(this)).Y - 150;
            newWindow.Left = PointToScreen(Mouse.GetPosition(this)).X - 100;

            newWindow.Show();
        }
        void Sensor_Click(object sender, RoutedEventArgs e, DataObject passed)
        {
            Popup_Sensor newWindow = new Popup_Sensor(passed, "PlaceHolder");
            newWindow.Owner = this;
            newWindow.Top = PointToScreen(Mouse.GetPosition(this)).Y - 150;
            newWindow.Left = PointToScreen(Mouse.GetPosition(this)).X - 100;

            newWindow.Show();
        }

        void Connect_Button_Click(object sender, RoutedEventArgs e)
        {
            if (client.connected == false)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure you wish to Connect?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    client.init();
                    if (client.connected == true)
                    {
                        //client.sendMessage(0);
                        System.Windows.MessageBox.Show("Connection Established", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Connection Already Established", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private bool Caution_Acknowledged = false;
        void Caution_Button_Click(object sender, RoutedEventArgs e)
        {
            Caution_Acknowledged = true;
        }
        private bool Warning_Acknowledged = false;
        void Warning_Button_Click(object sender, RoutedEventArgs e)
        {
            Warning_Acknowledged = true;
        }
        private int counter = 0;
        void Approach_Button_Click(object sender, RoutedEventArgs e)
        {
            //replace with send Approach command
            //Current.UpdateState("Increment");
            fill_Arm_Contact.Open();
        }
        void Break_Button_Click(object sender, RoutedEventArgs e)
        {
            //replace with send abort command
            //Current.UpdateState("Failure");
            fill_Arm_Contact.Close();
        }

        void State_Change_Button_Click(object sender, RoutedEventArgs e, State passed)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure you wish to Begin this Seqeuence?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Sequence_Stack.Children.Clear();
                Current.Reset();
                Current = passed;
                State_Display.Text = passed.Start_Text;
                for (int i = 0; i < passed.text_count; i++)
                {
                    Sequence_Stack.Children.Add(passed.stackPanels[i].stackpanel);
                    //Sequence_Stack.Children.Add(passed.grids[i].grid);
                }
            }
        }
    }
}