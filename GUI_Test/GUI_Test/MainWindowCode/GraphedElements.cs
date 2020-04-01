using System.Windows;
using System.Windows.Input;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DataObject Altitude = new DataObject("Altitude", 800000, 800000);
        public static DataObject[] Altitude_Objects = { Altitude };
        MainWindowVM Graph_Object = new MainWindowVM("Altitude", Altitude_Objects);

        public static DataObject P1 = new DataObject("P1", 100, 200);
        public static DataObject P2 = new DataObject("P2", 100, 200);
        public static DataObject P3 = new DataObject("P3", 100, 200);
        public static DataObject P4 = new DataObject("P4", 100, 200);
        public static DataObject[] Pressure_Objects = { P1, P2, P3, P4 };

        public static DataObject T1 = new DataObject("T1", 200, 300);
        public static DataObject T2 = new DataObject("T2", 200, 300);
        public static DataObject T3 = new DataObject("T3", 200, 300);
        public static DataObject T4 = new DataObject("T4", 200, 300);
        public static DataObject T5 = new DataObject("T5", 200, 300);
        public static DataObject T6 = new DataObject("T6", 200, 300);
        public static DataObject[] Temperature_Objects = { T1, T2, T3, T4, T5, T6 };

        private void initDataObjects()
        {
            P1_Display.MouseLeftButtonDown += new MouseButtonEventHandler((sender, e) => Sensor_Click(sender, e, P1));
            P1.textBlock = P1_Display;
            P1.OnDataCaution += new DataObject.DataCaution(OnDataCaution_Handler);
            P1.OnDataWarning += new DataObject.DataWarning(OnDataWarning_Handler);
            P2_Display.MouseLeftButtonDown += new MouseButtonEventHandler((sender, e) => Sensor_Click(sender, e, P2));
            P2.textBlock = P2_Display;
            P2.OnDataCaution += new DataObject.DataCaution(OnDataCaution_Handler);
            P2.OnDataWarning += new DataObject.DataWarning(OnDataWarning_Handler);
            P3_Display.MouseLeftButtonDown += new MouseButtonEventHandler((sender, e) => Sensor_Click(sender, e, P3));
            P3.textBlock = P3_Display;
            P3.OnDataCaution += new DataObject.DataCaution(OnDataCaution_Handler);
            P3.OnDataWarning += new DataObject.DataWarning(OnDataWarning_Handler);
            P4_Display.MouseLeftButtonDown += new MouseButtonEventHandler((sender, e) => Sensor_Click(sender, e, P4));
            P4.textBlock = P4_Display;
            P4.OnDataCaution += new DataObject.DataCaution(OnDataCaution_Handler);
            P4.OnDataWarning += new DataObject.DataWarning(OnDataWarning_Handler);
            T1_Display.MouseLeftButtonDown += new MouseButtonEventHandler((sender, e) => Sensor_Click(sender, e, T1));
            T1.textBlock = T1_Display;
            T1.OnDataCaution += new DataObject.DataCaution(OnDataCaution_Handler);
            T1.OnDataWarning += new DataObject.DataWarning(OnDataWarning_Handler);
            T2_Display.MouseLeftButtonDown += new MouseButtonEventHandler((sender, e) => Sensor_Click(sender, e, T2));
            T2.textBlock = T2_Display;
            T2.OnDataCaution += new DataObject.DataCaution(OnDataCaution_Handler);
            T2.OnDataWarning += new DataObject.DataWarning(OnDataWarning_Handler);
            T3_Display.MouseLeftButtonDown += new MouseButtonEventHandler((sender, e) => Sensor_Click(sender, e, T3));
            T3.textBlock = T3_Display;
            T3.OnDataCaution += new DataObject.DataCaution(OnDataCaution_Handler);
            T3.OnDataWarning += new DataObject.DataWarning(OnDataWarning_Handler);
            T4_Display.MouseLeftButtonDown += new MouseButtonEventHandler((sender, e) => Sensor_Click(sender, e, T4));
            T4.textBlock = T4_Display;
            T4.OnDataCaution += new DataObject.DataCaution(OnDataCaution_Handler);
            T4.OnDataWarning += new DataObject.DataWarning(OnDataWarning_Handler);
            T5_Display.MouseLeftButtonDown += new MouseButtonEventHandler((sender, e) => Sensor_Click(sender, e, T5));
            T5.textBlock = T5_Display;
            T5.OnDataCaution += new DataObject.DataCaution(OnDataCaution_Handler);
            T5.OnDataWarning += new DataObject.DataWarning(OnDataWarning_Handler);
            T6_Display.MouseLeftButtonDown += new MouseButtonEventHandler((sender, e) => Sensor_Click(sender, e, T6));
            T6.textBlock = T6_Display;
            T6.OnDataCaution += new DataObject.DataCaution(OnDataCaution_Handler);
            T6.OnDataWarning += new DataObject.DataWarning(OnDataWarning_Handler);

            Graph.DataContext = Graph_Object;
            Altitude.OnDataChanged += new DataObject.DataChanged(Graph_Object.OnDataChanged_Handler);
        }
    }
}