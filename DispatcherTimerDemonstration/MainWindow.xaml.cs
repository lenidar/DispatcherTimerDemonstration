using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DispatcherTimerDemonstration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int num = 0;
        DispatcherTimer dt = new DispatcherTimer();
        DispatcherTimer dt2 = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            dt.Interval = new TimeSpan(0,0,0,1,0);
            dt.Tick += Dt_Tick;

            dt2.Interval = new TimeSpan(0, 0, 0, 0, 5);
            dt2.Tick += Dt2_Tick;

            Rectangle r = new Rectangle();
            r.Width = 100;
            r.Height = 100;

            r.StrokeThickness = 0;
            r.Stroke = new SolidColorBrush(Colors.Black);
            r.HorizontalAlignment = HorizontalAlignment.Left;
            r.VerticalAlignment = VerticalAlignment.Top;
            //r.Margin = new Thickness(0, 0, 0, 0);
            r.Margin = new Thickness(myWindow.Width, myWindow.Height, 0, 0);
            myGrid.Children.Add(r);
        }

        private void Dt2_Tick(object sender, EventArgs e)
        {
            double[] tempLoc = { eMove.Margin.Top, eMove.Margin.Left };
            if (eMove.Margin.Top >= 0 && eMove.Margin.Top <= (450 - eMove.Height)
                && eMove.Margin.Left >= 0 && eMove.Margin.Left <= (800 - eMove.Width))
            {
                tempLoc[0] += eMove.Height / 100;
                tempLoc[1] += eMove.Width / 100;

                eMove.Margin = new Thickness(tempLoc[1], tempLoc[0], 0, 0);
            }
            else
                dt2.Stop();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            if (num < 10)
            {
                lblDemo.Content = numToString(num);
                num++;
            }
            else
                dt.Stop();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Counting has begun!");
            dt.Start();
            //while(num < 10)
            //{
            //    lblDemo.Content = numToString(num);
            //    //MessageBox.Show(lblDemo.Content.ToString());
            //    num++;
            //    Thread.Sleep(500);
            //}

            dt2.Start();
        }

        private string numToString(int x)
        {
            string temp = x + "";

            while(temp.Length < 3)
            {
                temp = "0" + temp;
            }

            return temp;
        }
    }
}
