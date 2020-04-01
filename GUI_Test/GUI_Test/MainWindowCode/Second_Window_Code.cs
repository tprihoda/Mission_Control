using System.Linq;
using System.Windows;
using System.Windows.Forms;
namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Window1 secondWindow;
        void initSecondWindow()
        {
            secondWindow = new Window1(this);
            SourceInitialized += (s, a) =>
            {
                secondWindow.Owner = this;
            };
            secondWindow.Show();
            var secondaryScreen = Screen.AllScreens.Where(s => !s.Primary).FirstOrDefault();

            if (secondaryScreen != null)
            {
                var workingArea = secondaryScreen.WorkingArea;
                secondWindow.Left = workingArea.Left;
                secondWindow.Top = workingArea.Top;
                secondWindow.Width = workingArea.Width;
                secondWindow.Height = workingArea.Height;

                if (IsLoaded)
                {
                    secondWindow.WindowState = WindowState.Maximized;
                }
            }
        }
    }
}