using System;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using teset2;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.Data.SQLite;

namespace teset2
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>

    public partial class Window3 : Window
    {
        public int id;
        private UserAll UA;


        private UserAll temp = new UserAll();
        private Original temp1 = new Original();
        private List<recentList> IMGR;


        private HookKeyBoard hkb = null;
        private Grid CON;
        public Window3()
        {
            InitializeComponent();
           

            //MediaCall();

            Loaded += new RoutedEventHandler(Window3_Loaded);
            CON = this.contents;

            
        }

        public void MediaCall(int id)
        {

            IMGR = DataAccess.Recent(id);
            int IDD = 0;

            int n = 0;


            foreach (recentList e in IMGR)
            {
                int i = 0;
               
                List<exerciesList> ex = new List<exerciesList>();
                ImageBrush ib = new ImageBrush();
                string datasource1 = "Data Source=.\\Test.db;Version=3;";
                    string sql1 = "select Img, Video, Caption, Calculation, Id from tt where Caption = '" + e.name + "'";
                    SQLiteConnection conn = new SQLiteConnection(datasource1);
                    SQLiteCommand cmd = new SQLiteCommand(sql1, conn);
                    SQLiteDataReader rdr;

                    conn.Open();
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ex.Add(new exerciesList
                        {
                            img = rdr.GetString(0),
                            video = rdr.GetString(1),
                            caption = rdr.GetString(2),
                            calculation = rdr.GetString(3),
                            id = rdr.GetInt32(4)
                        });

                    }



                    foreach (exerciesList exc in ex)
                    {
                    if (n == 5)
                    {
                        break;
                    }
                    BitmapImage src = new BitmapImage();
                        src.BeginInit();
                        var filename = exc.img;
                        src.UriSource = new Uri(@"..\resources\" + filename, UriKind.Relative);
                        src.EndInit();

                        ib.ImageSource = src;
                        ib.Stretch = Stretch.Fill;
                        System.Windows.Controls.Button btn = new System.Windows.Controls.Button();        // Create button
                        btn.Name = "btn_" + exc.id.ToString();  //Put name on each button
                                                                //btn.Uid = e.caption;
                        n += 1;    // as many as the number of data in database
                        btn.Click += new RoutedEventHandler(doCall);  //for button event

                        btn.Background = ib;
                        btn.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        btn.VerticalAlignment = VerticalAlignment.Top;
                        btn.Margin = new Thickness(10);
                        btn.Height = 150;
                        btn.Width = 250;
                        wp_img.Children.Add(btn);  //Put buttons into Wrap panel
                        IDD = exc.id;
                 
                    }
                  
                }
            
          
        }

   
        public string sid;
        public string type;

        private void doCall(object sender, RoutedEventArgs e)
        {

            System.Windows.Controls.Button btn = (sender as System.Windows.Controls.Button);
            string strId = null;

            if (btn != null)
            {
                strId = btn.Name.Substring((btn.Name.IndexOf('_') + 1), btn.Name.Length - (btn.Name.IndexOf('_') + 1));
                sid = strId;
               
                List<exerciesList> CAP;
                temp.id = sid;
                CAP = DataAccess.Load(Int32.Parse(sid));
                foreach (exerciesList exList in CAP)
                {
                    var exercise = exList.calculation;
                    if (exercise == "Timed")
                    {
                       
                        exercisePage1();

                    }
                    else
                    {
                       
                        exercisePage2();
                    }
                    type = exercise;
                }


            

            }
            Back.Visibility = Visibility.Visible;
        }
        private void Window3_Loaded(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
            //DisabledMouseKey();
        }



        private void DisabledMouseKey()
        {
            hkb = new HookKeyBoard();
            hkb.keyeventhandler += new KeyEventHandler(keyhandler);
            hkb.InstallHook(this);
            HookKeyBoard.tagMSG Msgs;
            while (HookKeyBoard.GetMessage(out Msgs, IntPtr.Zero, 0, 0) > 0)
            {
                HookKeyBoard.TranslateMessage(ref Msgs);
                HookKeyBoard.DispatchMessage(ref Msgs);
            }
        }

        public void EnableMouseKey()
        {
            hkb.Hook_Clear();
        }

        /// <summary>
        /// an exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyhandler(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "a" || e.KeyData.ToString() == "A")
            {
                hkb.Hook_Clear();
            }
        }

        Thread t = new Thread(new ThreadStart(() =>
        {

            Thread.Sleep(5000);
            Window1 w1 = new Window1();
            // w1.window += new Window1.Delegate(win3);
            w1.WindowStartupLocation = WindowStartupLocation.Manual;


            w1.Show();
            System.Windows.Threading.Dispatcher.Run(); // for solving STA problem..
        }));
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // window();


            Thread t = new Thread(new ThreadStart(() =>
            {

                Thread.Sleep(5000);
                Window1 w1 = new Window1();
                //w1.window += new Window1.Delegate(win3);
                w1.WindowStartupLocation = WindowStartupLocation.Manual;
                w1.id = id;

                w1.Show();
                System.Windows.Threading.Dispatcher.Run(); // for solving STA problem..
            }));

        

                t.SetApartmentState(ApartmentState.STA);  // for solving STA problem..
                t.IsBackground = true;
                t.Start();

            this.Close();
        }
        private void button1_Click1(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {

            contents.Children.Clear();
            teset2.UserAll all = new UserAll();
            all.exercise1 += new UserAll.Delegate(exercisePage1);
            all.exercise2 += new UserAll.Delegate(exercisePage2);
            temp = all;
            contents.Children.Add(all);
            Level.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Visible;
        }

        private void OAll()
        {
            contents.Children.Clear();
            teset2.UserAll all = new UserAll();
            all.exercise1 += new UserAll.Delegate(exercisePage1);
            all.exercise2 += new UserAll.Delegate(exercisePage2);
            temp = all;
            contents.Children.Add(all);
            Level.Visibility = Visibility.Visible;
            Back.Visibility = Visibility.Visible;
        }




        private void Back_Click(object sender, RoutedEventArgs e)
        {
            contents.Children.Clear();
            teset2.Original original = new Original();
            original.all += new Original.Delegate(OAll);
            original.back += new Original.Delegate(AppearButton2);
            original.exercise1 += new Original.Delegate(exercisePage11);
            original.exercise2 += new Original.Delegate(exercisePage22);
            contents.Children.Add(original);
            temp1 = original;
            original.id = id;
            original.MediaCall(id);
    

            
            Level.Visibility = Visibility.Hidden;
            //exit.Visibility = Visibility.Hidden;
            Back.Visibility = Visibility.Hidden;
        }

        public delegate void Delegate();
       // public event Delegate window;

        private void AppearButton1()
        {
            //window();
            Thread t = new Thread(new ThreadStart(() =>
               {

                   Thread.Sleep(5000);
                   Window1 w1 = new Window1();
                   //w1.window += new Window1.Delegate(win3);
                   w1.WindowStartupLocation = WindowStartupLocation.Manual;
                   w1.id = id;

                   w1.Show();
                   System.Windows.Threading.Dispatcher.Run(); // for solving STA problem..
               }));
            t.SetApartmentState(ApartmentState.STA);  // for solving STA problem..
            t.IsBackground = true;
            t.Start();
            this.Close();
        }

        private void AppearButton2()
        {
            Back.Visibility = Visibility.Visible;
        }
        private string time;
        private Exercise Ex;

        private void exercisePage11()
        {

            contents.Children.Clear();
            Exercise ex = new Exercise();
            ex.submit += new Exercise.Delegate(submitPage1);

            ex.id = temp1.sid;
            Ex = ex;
            ex.vedio1();
            contents.Children.Add(ex);
            Level.Visibility = Visibility.Hidden;
        }

        private void exercisePage22()
        {
            contents.Children.Clear();
            Exercise ex = new Exercise();
            ex.submit += new Exercise.Delegate(submitPage2);
            ex.id = temp1.sid;
            Ex = ex;
            ex.vedio1();
            ex.tital.Visibility = Visibility.Visible;
            contents.Children.Add(ex);
            Level.Visibility = Visibility.Hidden;
        }

        private void exercisePage1()
        {

            contents.Children.Clear();
            Exercise ex = new Exercise();
            ex.submit += new Exercise.Delegate(submitPage1);
            
            ex.id = temp.id;
            Ex = ex;
            ex.vedio1();
            contents.Children.Add(ex);
            Level.Visibility = Visibility.Hidden;
        }

        private void exercisePage2()
        {
            contents.Children.Clear();
            Exercise ex = new Exercise();
            ex.submit += new Exercise.Delegate(submitPage2);
            ex.id = temp.id;
            Ex = ex;
            ex.vedio1();
            ex.tital.Visibility = Visibility.Visible;
            contents.Children.Add(ex);
            Level.Visibility = Visibility.Hidden;
        }


        private submit subtext;

        private void submitPage1()
        {
            contents.Children.Clear();
            teset2.submit sub = new submit();
            sub.Statistics.Visibility = Visibility.Visible;

            sub.Tital.Text = Ex.time;
            sub.EX.Visibility = Visibility.Visible;
            this.Dispatcher.Invoke(new Action(() => {
               sub.Rep.Visibility = Visibility.Hidden;
                sub.add.Visibility = Visibility.Visible;
                sub.minus.Visibility = Visibility.Visible;
            }));
            sub.exitEvent += new submit.ExitDelegate(AppearButton1);
            sub.STAT += new submit.ExitDelegate(statisticsPage);
            sub.sub += new submit.ExitDelegate(Sub);
            subtext = sub;
            contents.Children.Add(sub);
        }

        private void submitPage2()
        {
            contents.Children.Clear();
            teset2.submit sub = new submit();
       
            sub.Tital.Text = Ex.time;
            sub.repetition.Visibility = Visibility.Visible;
            this.Dispatcher.Invoke(new Action(() => {
                sub.Rep.Visibility = Visibility.Visible;
                sub.add.Visibility = Visibility.Visible;
                sub.minus.Visibility = Visibility.Visible;
            }));
            sub.EX.Visibility = Visibility.Visible;
            sub.exitEvent += new submit.ExitDelegate(AppearButton1);
            sub.sub += new submit.ExitDelegate(Sub);
            subtext = sub;
            
            contents.Children.Add(sub);
        }


        private void AppearButton()
        {
         //   exit.Visibility = Visibility.Visible;
        }

        private void statisticsPage()
        {
            contents.Children.Clear();
            teset2.UserStatistics statistics = new UserStatistics();
            statistics.exitEvent += new UserStatistics.ExitDelegate(AppearButton1);
          
                statistics.EX.Visibility = Visibility.Visible;
            
            contents.Children.Add(statistics);

        }

        List<exerciesList> CAP;
        private void Sub()
        {
            CAP = DataAccess.Load(Int32.Parse(temp.id));
            foreach (exerciesList exList in CAP)
            {
                var exercise = exList.caption;
                DataAccess.Submit(id,exercise, Ex.CD, subtext.text,temp.type);
                this.Close();
            }

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            temp.wp_img.Children.Clear();
            temp.easy();


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            temp.wp_img.Children.Clear();
            temp.moderate();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            temp.wp_img.Children.Clear();
            temp.challenge();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            temp.wp_img.Children.Clear();
            temp.all();
        }
    }
}
