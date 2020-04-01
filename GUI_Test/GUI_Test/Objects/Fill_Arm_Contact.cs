using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace GUI
{
    public class Fill_Arm_Contact
    {

        public delegate void StateChanged(object sender, ContactEventArgs e);
        public event StateChanged OnStateChanged;
        public class ContactEventArgs : EventArgs
        {
            public Fill_Arm_Contact passed;
        }
        public enum State { Nominal, Failure, Unknown };
        public Image image;
        private bool isOpen_Value;
        public bool isOpen
        {
            get { return isOpen_Value; }
            set
            {
                isOpen_Value = value;
                ContactEventArgs e = new ContactEventArgs();
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
            set { Feedback_Value = value; }
        }
        public BitmapImage Open_Black = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Contact_Open\Contact_Open_Black.png"));
        public BitmapImage Closed_Black = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Contact_Closed\Contact_Closed_Black.png"));
        public BitmapImage Open_Red = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Contact_Open\Contact_Open_Red.png"));
        public BitmapImage Closed_Red = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Contact_Closed\Contact_Closed_Red.png"));
        public BitmapImage Open_Yellow = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Contact_Open\Contact_Open_Yellow.png"));
        public BitmapImage Closed_Yellow = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Contact_Closed\Contact_Closed_Yellow.png"));
        public BitmapImage Open_Green = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Contact_Open\Contact_Open_Green.png"));
        public BitmapImage Closed_Blue = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Contact_Closed\Contact_Closed_Blue.png"));

        protected virtual void RaiseStateChange(ContactEventArgs e)
        {
            if (OnStateChanged != null) { OnStateChanged(this, e); }
        }

        public Fill_Arm_Contact(Image passed_Source, string name, string description)
        {
            Name = name;
            Description = description;
            image = passed_Source;
            image.Source = Open_Black;

            image.Width = 35;
            image.Height = 35;

            isOpen_Value = true;

        }

        public void Open()
        {
            image.Source = Open_Black;
            isOpen = true;
        }
        public void Close()
        {
            image.Source = Closed_Black;
            isOpen = false;

        }
        public void Toggle()
        {

            if (isOpen)
            {
                image.Source = Closed_Black;
            }
            else
            {
                image.Source = Open_Black;
            }
        }

        public void ChangeColor()
        {
            if (isOpen)
            {
                switch (Feedback)
                {
                    case State.Nominal:
                        image.Source = Open_Green;
                        break;
                    case State.Failure:
                        image.Source = Open_Red;
                        break;
                    case State.Unknown:
                        image.Source = Open_Yellow;
                        break;
                }
            }
            else
            {
                switch (Feedback)
                {
                    case State.Nominal:
                        image.Source = Closed_Blue;
                        break;
                    case State.Failure:
                        image.Source = Closed_Red;
                        break;
                    case State.Unknown:
                        image.Source = Closed_Yellow;
                        break;
                }
            }
        }
    }
}
