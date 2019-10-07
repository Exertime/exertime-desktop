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
        private List<exerciesList> IMG;

        public delegate void Delegate();
        public event Delegate submit;
        public int value = 0;
        public int type = 0;

        public string id;

        public int s = 60;

       public string time;

        private DispatcherTimer timer;

        private ProcessCount processCount;
        private ProcessCount processCount1;

        public int CD = 0;

        public Exercise()
        {
            InitializeComponent();

            
            
          
            this.Loaded += new RoutedEventHandler(MainWin_Loaded);
        }
        public void vedio1()
        {
            IMG = DataAccess.Load(Int32.Parse(id));
            // Play Videos
            foreach (exerciesList exList in IMG)
            {
                
                var filename1 = exList.video;
                var filename2 = exList.img;
                Player1.Source = new Uri(@".\resources\" + filename1, UriKind.Relative);
                Player1.Close();
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(@".\resources\" + filename2, UriKind.Relative);
                src.EndInit();
                ImageBrush ib = new ImageBrush();
                ib.ImageSource = src;

                btn1.Background = ib;
               
            }
        }
        private void vedio(object sender, RoutedEventArgs e)
        {
            Player1.Play();
            btn1.Visibility = Visibility.Hidden;
        }
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWin_Loaded(object sender, RoutedEventArgs e)
        {
           
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(10000000);  
            timer.Tick += new EventHandler(timer_Tick);

            this.Player1.LoadedBehavior = MediaState.Manual;


            processCount = new ProcessCount();
            CountDown += new CountDownHandler(processCount.ProcessCountDown);


            stop.Visibility = Visibility.Hidden;
        }

        public void Stop(object sender, EventArgs e)
        {
            timer.Stop();
            stop.Visibility = Visibility.Hidden;
            cont.Visibility = Visibility.Visible;
            finish.Visibility = Visibility.Visible;
          
        }

        public void Start(object sender, EventArgs e)
        {
            timer.Start();
            stop.Visibility = Visibility.Visible;
            start.Visibility = Visibility.Hidden;
           
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

            this.time = "Total Exercise Time " + processCount.GetMinute() + ":" + processCount.GetSecond();
            submit();

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

       
        


   








