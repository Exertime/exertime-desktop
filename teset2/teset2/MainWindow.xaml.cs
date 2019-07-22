using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Threading;

namespace teset2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            // time_lbl.Content();
            //     Thread thread = new Thread(schedule_Timer);
            //      thread.Start();
            //     schedule_Timer();
            /*
                   new Thread(() =>
                   {
                       Thread.Sleep(1000);
                       Window1 w1 = new Window1();
                       w1.Top = 573;
                       w1.Left = 980;
                       w1.Show();
                   }).Start();
                   */

            Thread t = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(5000);
                Window1 w1 = new Window1();
                w1.Top = 573;
                w1.Left = 980;
                w1.Show();
                System.Windows.Threading.Dispatcher.Run(); // for solving STA problem..
            }));
            t.SetApartmentState(ApartmentState.STA);  // for solving STA problem..
            t.IsBackground = true;
            t.Start();

        }

    

        public void schedule_Timer()
        {
         /*   
            Task.Delay(2000).ContinueWith(_ =>
            {
                Window1 w1 = new Window1();
               // w1.Top = 573;
                //w1.Left = 980;
                w1.Show();
            });
            */

       //     Thread.Sleep(1000);
            DateTime nowTime = DateTime.Now;
            DateTime scheduledTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 11, 48, 00); //Specify your time HH,MM,SS
            if (nowTime > scheduledTime)
            {
                scheduledTime = scheduledTime.AddSeconds(1);
                Window1 w1 = new Window1();
                w1.Top = 573;
                w1.Left = 980;
                w1.Show();
            }
            else
            {
                this.Close();
            }
            
            //  this.time_lbl.Content = nowTime.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

         

        }


    }
}
