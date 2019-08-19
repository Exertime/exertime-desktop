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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

namespace teset2
{
   
    public partial class Exercise : UserControl


    {

    
        public int s = 60;

        private DispatcherTimer timer;

        private ProcessCount processCount;

        public int CD = 0;

        public Exercise()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainWin_Loaded);
        }

       
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWin_Loaded(object sender, RoutedEventArgs e)
        {
           
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(10000000);  
            timer.Tick += new EventHandler(timer_Tick);

            

            
            processCount = new ProcessCount(s);
            CountDown += new CountDownHandler(processCount.ProcessCountDown);
            
          
            timer.Start();
        }

        public void Stop(object sender, EventArgs e)
        {
            timer.Stop();
            stop.Visibility = Visibility.Hidden;
            cont.Visibility = Visibility.Visible;
            finish.Visibility = Visibility.Visible;
           // finish.Content = CD;
        }

        public void Continue(object sender, EventArgs e)
        {
            timer.Start();
            cont.Visibility = Visibility.Hidden;
            stop.Visibility = Visibility.Visible;
          
        }

        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (OnCountDown())
            {
                CD++;
                MinuteArea.Text = processCount.GetMinute();
                SecondArea.Text = processCount.GetSecond();
            }
            else
            {
                timer.Stop();
               
                finish.Visibility = Visibility.Visible;
            }
        }

        public void Finish(object sender, EventArgs e)
        {

        }



        public event CountDownHandler CountDown;
        public bool OnCountDown()
        {
            if (CountDown != null)
                return CountDown();

            return false;
        }
    }

   
    public delegate bool CountDownHandler();
}

       
        


   








