using RealTimeGraphX.DataPoints;
using RealTimeGraphX.Renderers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using RealTimeGraphX.WPF;


namespace GUI
{
    public class MainWindowVM
    {
        public WpfGraphController<TimeSpanDataPoint, DoubleDataPoint> Controller { get; set; }

        public WpfGraphController<TimeSpanDataPoint, DoubleDataPoint> MultiController { get; set; }
        private DataObject[] Objects;
        private DoubleDataPoint[] y;

        public void OnDataChanged_Handler(object sender, DataEventArgs e)
        {
            for (int i = 0; i < Objects.Length; i++)
            {
                if (sender.Equals(Objects[i]))
                {
                    y[i] = e.passed;
                }
            }
        }

        public MainWindowVM(string _name, DataObject[] _Objects)
        {
            Objects = _Objects;
            Controller = new WpfGraphController<TimeSpanDataPoint, DoubleDataPoint>();
            Controller.Range.MinimumY = 0;
            Controller.Range.MaximumY = 1080;
            Controller.Range.MaximumX = TimeSpan.FromSeconds(10);
            Controller.Range.AutoY = true;

            Controller.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = _name,
                Stroke = Colors.DodgerBlue,
            });

            MultiController = new WpfGraphController<TimeSpanDataPoint, DoubleDataPoint>();
            MultiController.Range.MinimumY = 0;
            MultiController.Range.MaximumY = 1080;
            MultiController.Range.MaximumX = TimeSpan.FromSeconds(10);
            MultiController.Range.AutoY = true;

            Color[] color_list = { Colors.Red, Colors.Green, Colors.Blue, Colors.Yellow, Colors.Gray, Colors.Purple, Colors.White, Colors.Silver, Colors.Orange, Colors.GreenYellow};
            y = new DoubleDataPoint[Objects.Length]; 
            for (int i = 0; i < Objects.Length; i++)
            {
                MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
                {
                    Name = _name + " " + (i+1).ToString(),
                    Stroke = color_list[i],
                });
                y[i] = 0;
            }
            /*
            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = _name + " 1",
                Stroke = Colors.Red,
            });

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = _name + " 2",
                Stroke = Colors.Green,
            });

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = _name + " 3",
                Stroke = Colors.Blue,
            });

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = _name + " 4",
                Stroke = Colors.Yellow,
            });

            MultiController.DataSeriesCollection.Add(new WpfGraphDataSeries()
            {
                Name = _name + " 5",
                Stroke = Colors.Gray,
            });
            */

            Stopwatch watch = new Stopwatch();
            watch.Start();

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    List<DoubleDataPoint> yy = new List<DoubleDataPoint>();

                for (int i = 0; i < Objects.Length; i++)
                    {
                        yy.Add(y[i]);
                    }


                    var x = watch.Elapsed;

                    List<TimeSpanDataPoint> xx = new List<TimeSpanDataPoint>();
                    for (int i = 0; i < Objects.Length; i++)
                    {
                        xx.Add(x);
                    }

                    Controller.PushData(x, y[0]);
                    MultiController.PushData(xx, yy);

                    Thread.Sleep(30);
                }
            });

        }
        
    }
}
