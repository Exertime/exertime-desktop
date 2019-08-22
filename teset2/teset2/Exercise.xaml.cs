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

        public delegate void ExitDelegate();
        public event ExitDelegate exitEvent;
        public int value = 0;
        public int type = 0;

        public int s = 60;

        private DispatcherTimer timer;

        private ProcessCount processCount;
        private ProcessCount processCount1;

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
          
        }

        public void Continue(object sender, EventArgs e)
        {
            timer.Start();
            cont.Visibility = Visibility.Hidden;
            stop.Visibility = Visibility.Visible;
            finish.Visibility = Visibility.Hidden;


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
            contents.Children.Clear();
            teset2.submit sub = new submit();
            processCount1 = new ProcessCount(CD);
            sub.Tital.Text = "Total Exercise Time " + processCount1.GetMinute() + ":" + processCount1.GetSecond();
            sub.exitEvent += new submit.ExitDelegate(AppearButton);
            if(value == 1)
            {
                sub.EX.Visibility = Visibility.Visible;
                sub.value = 1;
            }
            sub.type = this.type;
            if(type == 1)
            {
                sub.repetition.Visibility = Visibility.Visible;
                sub.Rep.Visibility = Visibility.Visible;
            }
            contents.Children.Add(sub);
        }

        

     private void AppearButton()
        {
        exitEvent();
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

       
        


   








