using System;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static string symbol_path = System.IO.Path.Combine(Environment.CurrentDirectory, @"P_and_ID_Symbols\");
        static public TCPSocket client = new TCPSocket("192.168.7.53", 8080);     

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            initWindow();
        }
        void initWindow()
        { 
            EnsureBrowserEmulationEnabled();
            initKeySwitch();
            initSecondWindow();
            initLogging();
            initWarnings();
            initPandID();
            initStates();
            initClickHandlers();
            initDataObjects();
            initMainTimer();
        }
    }

}
