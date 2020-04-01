using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Valve Fill_Valve;
        public static Valve Tank_Valve;
        public static Valve Propane_Valve;
        public static Valve Fill_Vent_Valve;
        public static Valve Servo_Valve;
        public static Tank_Level tank_Level;
        public static Fill_Arm_Contact fill_Arm_Contact;
        public static Ignitor ignitor;
        void initPandID()
        {
            Rocket_Image.Source = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Rocket_flipped_propane.png"));
            Glow_Plug_Image.Source = new BitmapImage(new Uri(MainWindow.symbol_path + @"\Glow_Plug\Glow_Plug_Off.png"));

            Fill_Valve = new Valve(Fill_Valve_Image, "Fill Valve", false, "Valve used to control the fill process");
            Tank_Valve = new Valve(Tank_Vent_Image, "Tank Vent Valve", true, "Valve used to vent the Tank");
            Propane_Valve = new Valve(Propane_Valve_Image, "Propane Valve", true, "Valve used to control propane flow");
            Fill_Vent_Valve = new Valve(Fill_Vent_Valve_Image, "Fill Vent Valve", true, "Valve used to vent the fill line");
            Servo_Valve = new Valve(Servo_element, "Servo Valve", true, "Valve used to control nitrous into the motor");
            fill_Arm_Contact = new Fill_Arm_Contact(Contact, "Fill Arm Contactor", "Contactor used to contect fill arm to the rocket");
            tank_Level = new Tank_Level(Tank_Level_Image);
            ignitor = new Ignitor(Glow_Plug_Image, "Glow Plug", "Ignites Propane in the combustion chamber to begin combustion of the fuel grain");

            Fill_Valve.image.MouseLeftButtonDown += new MouseButtonEventHandler((sender, e) => Valve_Click(sender, e, Fill_Valve));
            Tank_Valve.image.MouseLeftButtonDown += new MouseButtonEventHandler((sender, e) => Valve_Click(sender, e, Tank_Valve));
            Propane_Valve.image.MouseLeftButtonDown += new MouseButtonEventHandler((sender, e) => Valve_Click(sender, e, Propane_Valve));
            Fill_Vent_Valve.image.MouseLeftButtonDown += new MouseButtonEventHandler((sender, e) => Valve_Click(sender, e, Fill_Vent_Valve));
            Servo_Valve.image.MouseLeftButtonDown += new MouseButtonEventHandler((sender, e) => Valve_Click(sender, e, Servo_Valve));
            Glow_Plug_Image.MouseLeftButtonDown += new MouseButtonEventHandler((sender, e) => Glow_Click(sender, e, ignitor));
        }
    }
}